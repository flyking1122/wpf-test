// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Avalon.Test.CoreUI.Trusted;

using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using System.Windows.Threading;

using Avalon.Test.CoreUI.Common;
using Avalon.Test.CoreUI.CoreInput.Common;
using Avalon.Test.CoreUI.CoreInput.Common.Controls;
using Microsoft.Test.Win32;
using Microsoft.Test.Discovery;
using Microsoft.Test;
using Microsoft.Test.Logging;

namespace Avalon.Test.CoreUI.Commanding
{
    /// <summary>
    /// Verify CommandBindingCollection Remove method succeeds if collection is initialized with multiple bindings array.
    /// </summary>
    /// <description>
    /// This is part of a collection of unit tests for commanding.
    /// </description>
    /// <





    [CoreTestsLoader(CoreTestsTestType.ClassBase)]
    [TestCaseTitle(@"Verify CommandBindingCollection Remove method succeeds if collection is initialized with multiple bindings array.")]
    [TestCasePriority("2")]
    [TestCaseArea(@"Commanding\CoreCommanding")]
    [TestCaseMethod("LaunchTest")]
    [TestCaseDisabled("0")]
    [TestCaseSecurityLevel(TestCaseSecurityLevel.FullTrust)]
    public class CommandBindingCollectionRemoveFromArrayApp: TestApp
    {
        /// <summary>
        /// Launch our test.
        /// </summary>
        public static void LaunchTest() 
        {
            
            CoreLogger.LogStatus("Creating app object...");
            TestApp app = new CommandBindingCollectionRemoveFromArrayApp();
            Debug.Assert( app!=null, "App does not exist!");
            CoreLogger.LogStatus("App object: "+app.ToString());

            CoreLogger.LogStatus("Running app...");
            app.RunTestApp();
            CoreLogger.LogStatus("App run!");
        }

        /// <summary>
        /// Setup the test.
        /// </summary>
        /// <param name="sender">App sending the callback.</param>
        /// <returns>Null object.</returns>
        public override object DoSetup(object sender) 
        {
            // Set up commands, Bindings
            RoutedCommand sampleCommand = new RoutedCommand("Sample", this.GetType(), null);
            CoreLogger.LogStatus("Command constructed: Command="+sampleCommand.ToString());

            _sampleCommandBinding = new CommandBinding(sampleCommand);
            CoreLogger.LogStatus("Command Binding constructed: CommandBinding="+_sampleCommandBinding.ToString());
            CommandBinding sampleCommandBinding2 = new CommandBinding(sampleCommand);
            CoreLogger.LogStatus("Command Binding constructed: CommandBinding=" + sampleCommandBinding2.ToString());

            // Set up Binding collection
            CommandBinding[] defaultBindings = new CommandBinding[] { _sampleCommandBinding, sampleCommandBinding2 };
            _readwriteCommandBindings = new CommandBindingCollection(defaultBindings);

            CoreLogger.LogStatus("Readonly RoutedCommand Binding collection constructed: " + _readwriteCommandBindings.ToString());
            CoreLogger.LogStatus("Commmand Bindings count: " + _readwriteCommandBindings.Count);

            return null;
        }

        /// <summary>
        /// Execute stuff.
        /// </summary>
        /// <param name="arg">Not used.</param>
        /// <returns>Null object.</returns>
        protected override object DoExecute(object arg) 
        {
            // Remove the Binding
            CoreLogger.LogStatus("Removing command Binding:");
            _readwriteCommandBindings.Remove(_sampleCommandBinding);
        
            base.DoExecute(arg);

            return null;
        }

        /// <summary>
        /// Validate the test.
        /// </summary>
        /// <param name="sender">App sending the callback.</param>
        /// <returns>Null object.</returns>
        public override object DoValidate(object sender) 
        {
            CoreLogger.LogStatus("Validating...");

            // For this test we want to know if exactly one command binding

            CoreLogger.LogStatus("Commmand Bindings count: "+_readwriteCommandBindings.Count);
            this.TestPassed = (_readwriteCommandBindings.Count == 1);

            CoreLogger.LogStatus("Validation complete!");
            return null;
        }

        /// <summary>
        /// Stores a readonly collection of Bindings.
        /// </summary>
        private CommandBindingCollection _readwriteCommandBindings;

        private CommandBinding _sampleCommandBinding = null;
}
}
