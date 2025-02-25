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
    /// Verify CommandBindingCollection Remove works for element with multiple CommandBindings to same Command.
    /// </summary>
    /// <description>
    /// This is part of a collection of unit tests for commanding.
    /// </description>
    /// <author>Microsoft</author>
 
    [CoreTestsLoader(CoreTestsTestType.ClassBase)]
    [TestCasePriority("1")]
    [TestCaseArea(@"Commanding\Collections")]
    [TestCaseTitle(@"Verify CommandBindingCollection Remove works for element with multiple CommandBindings to same Command.")]
    [TestCaseMethod("LaunchTest")]
    [TestCaseDisabled("0")]
    [TestCaseSecurityLevel(TestCaseSecurityLevel.FullTrust)]
    public class CommandBindingCollectionRemoveApp: TestApp
    {
        /// <summary>
        /// Launch our test.
        /// </summary>
        public static void LaunchTest() 
        {
            CoreLogger.LogStatus("Creating app object...");
            TestApp app = new CommandBindingCollectionRemoveApp();
            Debug.Assert( app!=null, "App does not exist!");
            CoreLogger.LogStatus("App object: "+app.ToString());

            CoreLogger.LogStatus("Running app...");
            app.RunTestApp();
            CoreLogger.LogStatus("App run!");
        }

        /// <summary>
        /// How many command links on our root element?
        /// </summary>
        private const int NUMCOMMANDLINKS = 2;
       
        CommandBinding[] _sampleCommandBindings = null;

        /// <summary>
        /// Setup the test.
        /// </summary>
        /// <param name="sender">App sending the callback.</param>
        /// <returns>Null object.</returns>
        public override object DoSetup(object sender) 
        {
            CoreLogger.LogStatus("Constructing window....");
            
            {
                // Construct test element
                _rootElement = new InstrPanel();

                // Set up commands
                RoutedCommand sampleCommand = new RoutedCommand("Sample", this.GetType(), null);
                CoreLogger.LogStatus("Command constructed: Command="+sampleCommand.ToString());
                
                // Create multiple command links to the samme command.
                _sampleCommandBindings = new CommandBinding[NUMCOMMANDLINKS];
                for (int i=0; i<_sampleCommandBindings.Length; i++) 
                {
                    // Create the link
                    _sampleCommandBindings[i] = new CommandBinding(sampleCommand);
                    CoreLogger.LogStatus("Command link constructed: CommandBinding="+_sampleCommandBindings[i].ToString());

                    // Attach events to the link
                    _sampleCommandBindings[i].Executed += new ExecutedRoutedEventHandler(OnSample);
                    _sampleCommandBindings[i].CanExecute += new CanExecuteRoutedEventHandler(OnQuery);

                    // Add link to test element
                    _rootElement.CommandBindings.Add(_sampleCommandBindings[i]); 
                }
            }

            return null;
        }

        /// <summary>
        /// Identify test operations to run.
        /// </summary>
        /// <param name="hwnd">Window handle.</param>
        /// <returns>Array of test operations.</returns>
        protected override InputCallback[] GetTestOps(HandleRef hwnd) 
        {
            InputCallback[] ops = new InputCallback[] 
            {
                new InputCallback(DoBeforeExecute)
            };
            return ops;
        }

        /// <summary>
        /// Execute stuff right before the test operations.
        /// </summary>
        private void DoBeforeExecute() 
        {
            CoreLogger.LogStatus("Removing all links....");
            for (int i=0; i<NUMCOMMANDLINKS; i++)
            {
                _rootElement.CommandBindings.Remove (_sampleCommandBindings[i]);
            }
        }

        /// <summary>
        /// Validate the test.
        /// </summary>
        /// <param name="sender">App sending the callback.</param>
        /// <returns>Null object.</returns>
        public override object DoValidate(object sender) 
        {
            CoreLogger.LogStatus("Validating...");

            // expect no command links
            int actual = (_rootElement.CommandBindings.Count);
            int expected = 0;
            bool eventFound = (actual == expected);
            CoreLogger.LogStatus("Command link count = " + actual);

            CoreLogger.LogStatus("Setting log result to " + eventFound);
            this.TestPassed = eventFound;
            
            CoreLogger.LogStatus("Validation complete!");
            
            return null;
        }

        /// <summary>
        /// Store record of our fired events.
        /// </summary>
        private ArrayList _commandLog = new ArrayList();
        
        /// <summary>
        /// If we are in this CommandEvent Handler, the case passes.
        /// </summary>
        /// <param name="target">Element that is the target of the event.</param>
        /// <param name="args">Arguments pertaining to the command event.</param>
        private void OnSample(object target, ExecutedRoutedEventArgs args) 
        {
            // We are executing a command!
            _commandLog.Add(args);

            CoreLogger.LogStatus("In command event:");
            CoreLogger.LogStatus(" Command:            " + args.Command.ToString());
            if (target!=null) 
            {
                CoreLogger.LogStatus(" command target Name: " + target.ToString());
            }
            CoreLogger.LogStatus(" Events found: "+_commandLog.Count);

            
        }
        
        /// <summary>
        /// If we are in this event handler, we are being queried.
        /// </summary>
        /// <param name="target">Element that is the target of the event.</param>
        /// <param name="args">Arguments pertaining to the command event.</param>
        private void OnQuery(object target, CanExecuteRoutedEventArgs args) 
        {
            // if we are in this handler, the case passes!
            CoreLogger.LogStatus("In query event:");
            CoreLogger.LogStatus(" Command:            " + args.Command.ToString());
            if (target!=null) 
            {
                CoreLogger.LogStatus(" command target Name: " + target.ToString());
            }
         
            // Show we are handled and we wish to accept commands!
            
        }
    }
}
