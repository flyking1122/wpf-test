// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

using Avalon.Test.CoreUI;
using Avalon.Test.CoreUI.Events;
using Avalon.Test.CoreUI.Trusted;

using Microsoft.Test;
using Microsoft.Test.Discovery;
using Microsoft.Test.Logging;
using Microsoft.Test.TestTypes;


namespace Avalon.Test.CoreUI.Events
{
    /// <summary>
    /// Ensure the classhandlers of subclass are invoked before classhandlers of base class
    /// </summary>
    /// <remarks>
    /// <para />
    /// Area: Events\Tunnel
    /// <para />
    /// <para />
    /// <para />
    /// FileName:  TunnelingSubclassClasshandlersSequence.cs
    /// <para />
    /// <ol>Scenarios covered:
    /// <li>Fetch RoutedEvent for Tunnel event</li>
    /// <li>Register 1 class handler for CustomControl1 and 1 class handler for CustomControl2, CustomControl2 inherit CustomControl1</li>
    /// <li>Create a new instance of CustomControl2</li>
    /// <li>Raise the Tunnel event</li>
    /// <li>Ensure that Handler registered for CustomControl2 is invoked before Handler registered for CustomControl1. </li>
    /// <li>Ensure the total number of handlers evoked is correct</li>
    /// </ol>
    /// </remarks>
    /// <seealso cref="TestCaseType"/>
    [Test(0, "Events.Tunnel", "TunnelingSubclassClasshandlersSequence")]
    public class TunnelingSubclassClasshandlersSequence : EventHelper
    {
        #region Constructor
        public TunnelingSubclassClasshandlersSequence()
        {
            RunSteps += new TestStep(StartTest);
        }
        #endregion


        #region Test Steps
        /// <summary>
        /// Entry Method for the test case
        /// </summary>
        TestResult StartTest()
        {
            CoreLogger.LogStatus ("This is a BVT scenario for Tunnel Event: class handlers for subclass are invoke before classhandlers for base class");
            CoreLogger.LogStatus ("Tests attach tunneling event");

            // Local Varables
            // Create the objects to build a tree later and test Events
            CustomControl2 myControl = null;

            // Create a routedEvent to get EventManager.GetRoutedEventFromName
            RoutedEvent routedEvent;

            // Create size of three object array to contain three CustomAvalonControl
            RouteTarget[] targets = new RouteTarget[2];

            // Create a CustomRoutedEventArgs for later RaiseEvent use
            CustomRoutedEventArgs args;

            // Create Dispatcher        
            Dispatcher context = MainDispatcher;

            // Enter Dispatcher
            
            using (CoreLogger.AutoStatus ("Creating custom controls"))
            {
                myControl = new CustomControl2 ();
            }

            using (CoreLogger.AutoStatus ("Fetch RoutedEvent for Tunnel event"))
            {
                routedEvent = EventHelper.RoutedEvent1;
            }
            using (CoreLogger.AutoStatus ("Register ClassHandlers"))
            {
                EventManager.RegisterClassHandler (typeof(CustomControl1), routedEvent, new CustomRoutedEventHandler (BaseHandler));
                EventManager.RegisterClassHandler (typeof(CustomControl2), routedEvent, new CustomRoutedEventHandler (SubClassHandler));
            }

            using (CoreLogger.AutoStatus ("Raise the Tunnel event"))
            {
                targets[0].Sender = myControl;
                targets[0].Source = myControl;
                targets[1].Sender = myControl;
                targets[1].Source = myControl;
                args = new CustomRoutedEventArgs (routedEvent, targets);
                myControl.RaiseEvent (args);
            }

            using (CoreLogger.AutoStatus ("Validation for event"))
            {
                if (2 != args.HandlersCalledCount)
                {
                    throw new Microsoft.Test.TestValidationException ("Incorrect HandlersCalledCount");
                }
            }

            //Any test failures will be caught by throwing an Exception during verification.
            return TestResult.Pass;
            
            // Exit Dispatcher
        }
        #endregion


        #region Public Members
        /// <summary>
        /// Handler for Base Class
        /// </summary>
        /// <param name="sender">Pass the object to it</param>
        /// <param name="args">Pass the CustomRoutedEventArgs to it</param>
        public void BaseHandler (object sender, CustomRoutedEventArgs args)
        {
            CoreLogger.LogStatus ("ClassHandler for Base class is running");

            // Verify sender, Source, and handler count.
            this.VerifyRoutedEvent (sender, args, 1);
        }

        /// <summary>
        /// Handler called
        /// </summary>
        /// <param name="sender">Pass the object to it</param>
        /// <param name="args">Pass the CustomRoutedEventArgs to it</param>
        public void SubClassHandler (object sender, CustomRoutedEventArgs args)
        {
            CoreLogger.LogStatus ("ClassHandler for Subclass is running");

            // Verify sender, Source, and handler count.
            this.VerifyRoutedEvent (sender, args, 0);
        }


        private class CustomControl1 : CustomControl
        {
            public CustomControl1 () : base() { }
        }
        private class CustomControl2 : CustomControl1
        {
            public CustomControl2 () : base() { }
        }
        #endregion
    }
}
