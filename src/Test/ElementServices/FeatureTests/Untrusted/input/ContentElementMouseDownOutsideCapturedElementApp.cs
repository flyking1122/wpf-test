// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Avalon.Test.CoreUI.Trusted;
using Avalon.Test.CoreUI;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Markup;
using System.Threading;
using Avalon.Test.CoreUI.Common;

using Avalon.Test.CoreUI.CoreInput.Common;
using Avalon.Test.CoreUI.CoreInput.Common.Controls;
using Microsoft.Test.Win32;
using Microsoft.Test.Discovery;
using Microsoft.Test;
using Microsoft.Test.Logging;

namespace Avalon.Test.CoreUI.CoreInput
{
    /// <summary>
    /// Verify MouseDownOutsideCapturedElement and MouseDownOutsideCapturedElement events work as expected over ContentElement.
    /// </summary>
    /// <description>
    /// This is part of a collection of unit tests for input events.
    /// </description>
    /// <author>Microsoft</author>
 
    [CoreTestsLoader(CoreTestsTestType.MethodBase)]
    public class ContentElementMouseDownOutsideCapturedElementApp: TestApp
    {
        /// <summary>
        /// Launch our test.
        /// </summary>
        [TestCase("2",@"CoreInput\Mouse","HwndSource",@"Compile and Verify MouseDownOutsideCapturedElement and MouseDownOutsideCapturedElement events work as expected over ContentElement in HwndSource.")]
        [TestCase("2",@"CoreInput\Mouse","Browser",@"Compile and Verify MouseDownOutsideCapturedElement and MouseDownOutsideCapturedElement events work as expected over ContentElement in Browser.")]
        [TestCase("2",@"CoreInput\Mouse","Window",@"Compile and Verify MouseDownOutsideCapturedElement and MouseDownOutsideCapturedElement events work as expected over ContentElement in window.")]        
        public static void LaunchTestCompile() 
        {
            HostType hostType = (HostType)Enum.Parse(typeof(HostType), DriverState.DriverParameters["TestParameters"]);


            GenericCompileHostedCase.RunCase(
                "Avalon.Test.CoreUI.CoreInput", 
                "ContentElementMouseDownOutsideCapturedElementApp",
                "Run", 
                hostType,null,null );
            
        }

        /// <summary>
        /// Launch our test.
        /// </summary>
        [TestCase("2",@"CoreInput\Mouse","HwndSource",@"Verify MouseDownOutsideCapturedElement and MouseDownOutsideCapturedElement events work as expected over ContentElement in HwndSource.")]
        [TestCase("2",@"CoreInput\Mouse","Window",@"Verify MouseDownOutsideCapturedElement and MouseDownOutsideCapturedElement events work as expected over ContentElement in window.")]               
        public static void LaunchTest() 
        {
            HostType hostType = (HostType)Enum.Parse(typeof(HostType),DriverState.DriverParameters["TestParameters"]);

            ExeStubContainerFramework exe = new ExeStubContainerFramework(hostType);
            exe.Run(new ContentElementMouseDownOutsideCapturedElementApp(),"Run");
            
        }

        /// <summary>
        /// Setup the test.
        /// </summary>
        /// <param name="sender">App sending the callback.</param>
        /// <returns>Null object.</returns>
        public override object DoSetup(object sender) 
        {
            // Construct test tree, add event handling to second content element.
            // The content host will return the first content element in the hit test, 
            // so the event PreviewMouseUp/DownOutsideCapturedElementEvent should be raised when
            // the second content element has capture.

            InstrContentPanelHost panel = new InstrContentPanelHost();

            // First content element -- will be returned in hit test.
            InstrContentPanel content1 = new InstrContentPanel("content1", "Sample1", panel);
            panel.AddChild(content1);

            // Second content element -- will have capture.
            _contentElement = new InstrContentPanel("content2", "Sample2", panel);
            _contentElement.AddHandler(Mouse.PreviewMouseDownOutsideCapturedElementEvent, new MouseButtonEventHandler(OnMouseButton), true);
            _contentElement.AddHandler(Mouse.PreviewMouseUpOutsideCapturedElementEvent, new MouseButtonEventHandler(OnMouseButton), true);
            panel.AddChild(_contentElement);

            // Put the test element on the screen
            DisplayMe(panel, 10, 10, 100, 100);

            CoreLogger.LogStatus("Window constructed: hwnd="+_hwnd.Handle);

            return null;
        }

        /// <summary>
        /// Identify test operations to run.
        /// </summary>
        /// <param name="hwnd">Window handle.</param>
        /// <returns>Array of test operations.</returns>
        protected override InputCallback[] GetTestOps(HandleRef hwnd)
        {
            Mouse.Capture(_contentElement);

            InputCallback[] ops = new InputCallback[] 
            {
                delegate
                {
                    MouseHelper.Click(MouseButton.Middle, (UIElement)_rootElement);
                },
                delegate
                {
                    MouseHelper.Click(MouseButton.XButton1,(UIElement)_rootElement);
                },
                delegate
                {
                    MouseHelper.Click(MouseButton.XButton2, (UIElement)_rootElement);
                },
                delegate
                {
                    MouseHelper.Click(MouseButton.Right, (UIElement)_rootElement);
                }    
            };
            return ops;
        }

        /// <summary>
        /// Validate the test.
        /// </summary>
        /// <param name="arg">Not used.</param>
        /// <returns>Null object.</returns>
        public override object DoValidate(object arg) 
        {
            CoreLogger.LogStatus("Validating...");

            // Note: for this test we are concerned about whether events fire for each button press.
            // 4 MouseDownOutsideCapturedElement + 4 MouseUpOutsideCapturedElement = 8 events

            CoreLogger.LogStatus("Events found: (expect 8) "+_buttonLog.Count);
            bool eventFound;
            if (_buttonLog.Count == 8)
            {
                eventFound = true;
            }
            else
            {
                eventFound = false;
            }

            CoreLogger.LogStatus("Setting log result to " + eventFound);
            this.TestPassed = eventFound;
            
            CoreLogger.LogStatus("Validation complete!");
            
            return null;
        }

        /// <summary>
        /// Standard mouse event handler.
        /// </summary>
        /// <param name="sender">Source sending the event.</param>
        /// <param name="args">Event-specific arguments.</param>
        private void OnMouseButton(object sender, MouseButtonEventArgs args)
        {
            // Set test flag
            CoreLogger.LogStatus(" Handling event: "+args.ToString());

            // Log some debugging data
            CoreLogger.LogStatus(" ["+args.RoutedEvent.Name+"]");
            Point pt = args.GetPosition(null);
            CoreLogger.LogStatus("   Hello from: " + pt.X+","+pt.Y);
            CoreLogger.LogStatus("Button="+args.ChangedButton.ToString()+",State="+args.ButtonState.ToString()+",ClickCount="+args.ClickCount);
            CoreLogger.LogStatus("Left,Right,Middle,XButton1,XButton2: "+
                                args.LeftButton.ToString()+","+
                                args.RightButton.ToString()+","+
                                args.MiddleButton.ToString()+","+
                                args.XButton1.ToString()+","+
                                args.XButton2.ToString()
                                );

            // Store a record of our buttons pressed.
            _buttonLog.Add(args.ChangedButton);
            _stateLog.Add(args.ButtonState);

            // Don't route this event any more.
            args.Handled = true;
        }

        /// <summary>
        /// Store record of our fired buttons.
        /// </summary>
        private ArrayList _buttonLog = new ArrayList();
        
        /// <summary>
        /// Store record of our fired states.
        /// </summary>
        private ArrayList _stateLog = new ArrayList();

        private ContentElement _contentElement;
    }
}
