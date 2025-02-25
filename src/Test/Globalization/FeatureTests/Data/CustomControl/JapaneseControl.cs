﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#define DEBUG  //Workaround - This allows Debug.Write to work.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Globalization;
using System.Threading; 
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.IO;
using System.Windows.Markup;
namespace Microsoft.Test.Globalization.MultiLangControl
{
    [Localizability(LocalizationCategory.None, Readability=Readability.Readable)]
    public class 窓ガラス : Panel, IAddChild
    {
        public 窓ガラス() : base()
        {
        }
        public Color Color = Color.FromRgb(0xff, 0xff, 0x00);
        public Typeface Typeface = new Typeface("Microsoft Sans Serif");
        protected override void OnRender(DrawingContext ctx)
        {

            ctx.DrawLine(
                new Pen(new SolidColorBrush(Color), 2.0f),
                new Point(0, 0),
                new Point(100, 100));
            ctx.DrawLine(
                new Pen(new SolidColorBrush(Color), 2.0f),
                new Point(0, 100),
                new Point(100, 0));
            string a = System.Globalization.CultureInfo.CurrentCulture.ToString();
            ctx.DrawText(
                new System.Windows.Media.FormattedText("窓ガラス " + a, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.RightToLeft, Typeface, 10, Brushes.Red),
                new Point(10, 10));
        }
    }
    [Localizability(LocalizationCategory.Button, Readability=Readability.Readable, Modifiability=Modifiability.Unmodifiable)]
    public class ボタン : Button
    {
        public static readonly DependencyProperty MagicStringProperty = DependencyProperty.Register("楽器の", typeof(string), typeof(ボタン));

        static ボタン()
        {
            PropertyMetadata myMeta = new PropertyMetadata();

            myMeta.DefaultValue = "の所有格";
            MagicStringProperty.OverrideMetadata(typeof(ボタン), myMeta);
        }

        [Localizability(LocalizationCategory.Text)]
        public string 楽器の
        {
            get { return (string) GetValue(MagicStringProperty); }
            set { SetValue(MagicStringProperty, value); }
        }
    }
    [Localizability(LocalizationCategory.Text, Readability=Readability.Unreadable, Modifiability=Modifiability.Unmodifiable)]
    public class 起源を持つ
    {
        public static readonly DependencyProperty NumberProperty = DependencyProperty.RegisterAttached("抽象概念の", typeof(int), typeof(起源を持つ), new PropertyMetadata(0));

        public static void SetNumber(DependencyObject d, int 抽象概念の)
        {
            d.SetValue(NumberProperty, 抽象概念の); //Boxing
        }

        public static int GetNumber(DependencyObject d)
        {
            return (int)d.GetValue(NumberProperty);  //Unboxing
        }
    }
    [Localizability(LocalizationCategory.Text, Readability=Readability.Readable)]
    public class クラスの : DependencyObject
    {
        static クラスの()
        {
            起源を持つ.NumberProperty.AddOwner(typeof(クラスの));

            PropertyMetadata myMeta = new PropertyMetadata();

            myMeta.DefaultValue = 100;
            起源を持つ.NumberProperty.OverrideMetadata(typeof(クラスの), myMeta);
        }

        //Provide CLR Accessors and local caching
        public int 抽象概念の
        {
            get { return (int) GetValue(起源を持つ.NumberProperty); }
            set { SetValue(起源を持つ.NumberProperty, value); }
        }
    }
}
