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
using System.Windows.Threading;
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
    /// Verify that the focus has been set correctly for: the scenario:
    /// Root is not focusable, has not child, focus on one element and framework application.
    /// 
    /// </summary>
    /// <description>
    /// This is part of a collection of test case for dev work item: 
    /// : Input : Active Window should have focus, when there is no explicit focus
    /// </description>
    /// <author>Microsoft</author>
 
    /// <



    [CoreTestsLoader(CoreTestsTestType.MethodBase)]
    public class FrameworkApplicationNonFocusableRoot2 : TestApp
    {
        /// <summary>
        /// Launch our test.
        /// </summary>
        [TestCase("2", @"CoreInput\Focus", "HwndSource", @"Compile and Verify Initialize Focus case 2 in HwndSource.")]
        [TestCase("2", @"CoreInput\Focus", "Browser", @"1", @"Compile and Verify Initialize Focus case 2 in Browser.")]
        [TestCase("2", @"CoreInput\Focus", "Window", @"Compile and Verify Initialize Focus case 2 in window.")]
        public static void LaunchTestCompile()
        {
            HostType hostType = (HostType)Enum.Parse(typeof(HostType), DriverState.DriverParameters["TestParameters"]);


            GenericCompileHostedCase.RunCase(
                "Avalon.Test.CoreUI.CoreInput",
                "FrameworkApplicationNonFocusableRoot2",
                "Run",
                hostType, null, null);

        }

        /// <summary>
        /// Launch our test.
        /// </summary>
        [TestCase("1", @"CoreInput\Focus", "HwndSource", @"Verify Initialize Focus case 2 in HwndSource.")]
        [TestCase("1", @"CoreInput\Focus", "Window", @"Verify Initialize Focus case 2 in window.")]
        public static void LaunchTest()
        {
            HostType hostType = (HostType)Enum.Parse(typeof(HostType), DriverState.DriverParameters["TestParameters"]);

            ExeStubContainerFramework exe = new ExeStubContainerFramework(hostType);
            exe.Run(new FrameworkApplicationNonFocusableRoot2(), "Run");

        }


        /// <summary>
        /// Setup the test.
        /// </summary>
        /// <param name="sender">App sending the callback.</param>
        /// <returns>Null object.</returns>
        public override object DoSetup(object sender)
        {


            // Construct test element and child element
            InstrContentPanelHost host = new InstrContentPanelHost();
            host.Focusable = false;
            _frameworkContentElement = new InstrFrameworkContentPanel("rootLeaf", "Sample", host);
            host.AddChild(_frameworkContentElement);


            DisplayMe(host, 0, 0, 200, 200);



            return null;
        }


        /// <summary>
        /// Execute stuff.
        /// </summary>
        /// <param name="arg">Not used.</param>
        /// <returns>Null object.</returns>
        protected override object DoExecute(object arg)
        {
            // STEP 1
            CoreLogger.LogStatus("Saving startup focus values (on startup). Should not get focus since it's not focusable.");

            _bWasFocused = _rootElement.IsKeyboardFocused;

            if (InputHelper.GetFocusedElement() != null)
            {
                CoreLogger.LogStatus("Foucused on: " + InputHelper.GetFocusedElement().ToString());
            }
            base.DoExecute(arg);
            return null;
        }

        /// <summary>
        /// Validate the test.
        /// </summary>
        /// <param name="arg">Not used.</param>
        /// <returns>Null object.</returns>
        public override object DoValidate(object arg)
        {
            CoreLogger.LogStatus("Validating...");

            this.TestPassed = true;

            if (_bWasFocused)
            {
                CoreLogger.LogStatus("root element should not get the focus when there focus has not been set on any element, because it is not focusable.");
                this.TestPassed = false;
            }

            CoreLogger.LogStatus("Validation complete!");
            return null;
        }

        /// <summary>
        /// Store content element on our canvas.
        /// </summary>
        private InstrFrameworkContentPanel _frameworkContentElement;

        private bool _bWasFocused = false;

    }
}
