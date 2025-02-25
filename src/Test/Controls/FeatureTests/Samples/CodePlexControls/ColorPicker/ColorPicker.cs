using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Markup;
using System.ComponentModel;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Automation;

namespace WpfControlToolkit
{
    public class ColorPicker : Control
    {
        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }

        public ColorPicker()
        {
            SetupColorBindings();
        }


        public static DependencyProperty ColorProperty = DependencyProperty.Register(
                "Color",
                typeof(Color),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(Colors.Black, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault|FrameworkPropertyMetadataOptions.Journal,
                       new PropertyChangedCallback(OnColorChanged), new CoerceValueCallback(CoerceColor)));

        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        public static DependencyProperty RedProperty = DependencyProperty.Register(
            "Red",
            typeof(byte),
            typeof(ColorPicker));

        public static DependencyProperty GreenProperty = DependencyProperty.Register(
            "Green",
            typeof(byte),
            typeof(ColorPicker));

        public static DependencyProperty BlueProperty = DependencyProperty.Register(
            "Blue",
            typeof(byte),
            typeof(ColorPicker));

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }


        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, 
                typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        protected virtual void OnColorChanged(Color oldValue, Color newValue)
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = ColorPicker.ColorChangedEvent;
            RaiseEvent(args);
        }

        private static DependencyProperty InternalColorProperty = DependencyProperty.Register("InternalColor",
            typeof(Color), typeof(ColorPicker),
                new PropertyMetadata(Colors.Black, new PropertyChangedCallback(OnInternalColorChanged)));

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new ColorPickerAutomationPeer(this);
        }

        //until ColorPicker suppors Alpha, it is coerced to 100% opaque
        private static object CoerceColor(DependencyObject d, object value)
        {
            Color val = (Color)value;
            if (val.A != 255)
            {
                val.A = 255;
            }
            return val;
        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker picker = (ColorPicker)d;

            Color oldValue = (Color)e.OldValue;
            Color newValue = (Color)e.NewValue;

            picker.SetValue(InternalColorProperty, newValue);

            picker.OnColorChanged(oldValue, newValue);

            ColorPickerAutomationPeer peer = UIElementAutomationPeer.FromElement(picker) as ColorPickerAutomationPeer;
            if (peer != null)
            {
                peer.RaiseValueChangedAutomationEvent(oldValue, newValue);
            }
        }

        private static void OnInternalColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker picker = (ColorPicker)d;

            Color oldValue = (Color)e.OldValue;
            Color newValue = (Color)e.NewValue;

            picker.SetValue(ColorProperty, newValue);
        }

        private void SetupColorBindings()
        {
            MultiBinding binding = new MultiBinding();

            binding.Converter = new ByteColorMultiConverter();
            binding.Mode = BindingMode.TwoWay;

            Binding redBinding = new Binding("Red");
            redBinding.Source = this;
            redBinding.Mode = BindingMode.TwoWay;
            binding.Bindings.Add(redBinding);

            Binding greenBinding = new Binding("Green");
            greenBinding.Source = this;
            greenBinding.Mode = BindingMode.TwoWay;
            binding.Bindings.Add(greenBinding);

            Binding blueBinding = new Binding("Blue");
            blueBinding.Source = this;
            blueBinding.Mode = BindingMode.TwoWay;
            binding.Bindings.Add(blueBinding);

            this.SetBinding(InternalColorProperty, binding);
        }
    }

    public class ColorPickerAutomationPeer : FrameworkElementAutomationPeer, IValueProvider
    {
        public ColorPickerAutomationPeer(ColorPicker picker):base(picker)
        {
        }

        protected override string GetClassNameCore()
        {
            return "ColorPicker";
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Custom;
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            if (patternInterface == PatternInterface.Value)
            {
                return this;
            }
            return base.GetPattern(patternInterface);
        }

        internal void RaiseValueChangedAutomationEvent(Color oldColor, Color newColor)
        {
            base.RaisePropertyChangedEvent(ValuePatternIdentifiers.ValueProperty, oldColor.ToString(), newColor.ToString());
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public void SetValue(string value)
        {
            throw new NotSupportedException();
        }

        public string Value
        {
            get
            {
                return MyOwner.Color.ToString();
            }
        }

        private ColorPicker MyOwner
        {
            get
            {
                return (ColorPicker)base.Owner;
            }
        }
    }

    public class ByteColorMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length != 3)
            {
                throw new ArgumentException("need three values");
            }

            byte red = (byte)values[0];
            byte green = (byte)values[1];
            byte blue = (byte)values[2];

            return Color.FromRgb(red, green, blue);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;

            return new object[] { color.R, color.G, color.B };
        }
    }

    public class ByteDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)(byte)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (byte)(double)value;
        }
    }

    [ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    public class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
