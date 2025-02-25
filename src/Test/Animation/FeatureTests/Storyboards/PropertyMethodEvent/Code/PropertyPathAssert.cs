// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

using Microsoft.Test;
using Microsoft.Test.Logging;
using Microsoft.Test.TestTypes;
using Microsoft.Test.Discovery;

namespace Microsoft.Test.Animation
{
    /// <summary>
    /// <area>Storyboards.PropertyMethodEvent.Regressions</area>

    [Test(2, "Storyboards.PropertyMethodEvent.Regressions", "PropertyPathAssertTest")]
    public class PropertyPathAssertTest : XamlTest
    {
        #region Test case members

        private DispatcherTimer     _aTimer = null;
        
        #endregion


        #region Constructor

        /******************************************************************************
        * Function:          PropertyPathAssertTest Constructor
        ******************************************************************************/
        public PropertyPathAssertTest() : base(@"PropertyPathAssert.xaml")
        {
            InitializeSteps += new TestStep(StartTimer);
            RunSteps += new TestStep(Verify);
        }

        #endregion


        #region Test Steps
        
        /******************************************************************************
        * Function:          StartTimer
        ******************************************************************************/
        /// <summary>
        /// Starts a Timer to control the timing of the verification.
        /// </summary>
        /// <returns>Returns TestResult</returns>
        TestResult StartTimer()
        {
            _aTimer = new DispatcherTimer(DispatcherPriority.Normal);
            _aTimer.Tick += new EventHandler(OnTick);
            _aTimer.Interval = new TimeSpan(0,0,0,0,1000);
            _aTimer.Start();
            GlobalLog.LogStatus("----DispatcherTimer Started----");

            return TestResult.Pass;
        }
        
        /******************************************************************************
        * Function:          OnTick
        ******************************************************************************/
        /// <summary>
        /// Invoked every time the DispatcherTimer ticks. Used to control the timing of verification.
        /// </summary>
        /// <returns></returns>
        private void OnTick(object sender, EventArgs e)          
        {
            Signal("AnimationDone", TestResult.Pass);
            _aTimer.Stop();
        }

        /******************************************************************************
        * Function:          Verify
        ******************************************************************************/
        /// <summary>
        /// Verifies the result of the test case, and returns a Pass/Fail result.
        /// </summary>
        /// <returns></returns>
        TestResult Verify()
        {
            //The .xaml file loaded consists of markup that caused an Assert, but now fails
            //silently.  Therefore, there is no workable animation involved.  The test case will
            //automatically pass if no Assert occurs on a debug build.  It will automatically pass
            // on a retail build.
            WaitForSignal("AnimationDone");
            
            return TestResult.Pass;
        }

        #endregion
    }
}
