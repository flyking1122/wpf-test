// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// Avalon Timing Verification Test Automation 
//  

/* 
 * Description: Verify invoking Stop() via CurrentGlobalSpeedInvalidated - Grow

*/

//Instructions:
//  1. Create a TimeManager
//  2. Create a Timeline tree, containing a parent Timeline and a child Timeline that will slip,
//  from 2 to 8 msec.
//  3. Create a Clock, associated with the parent Timeline
//  4. Start the TimeManager


//Pass Verification:
//  The output of this test should match the expected output in SBStop2Expect.txt.

//Warnings:
//  Any changes made in the output should be reflected SBStop2Expect.txt file

//Dependencies:
//  TestRuntime.dll, Timing\Common\GlobalClasses.cs

using System;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Test.Logging;

namespace Microsoft.Test.Animation
{
    class SBStop2 :ITimeBVT
    {
        private Clock _clock;
        
        /*
        *  Function:   Test
        *  Arguments:  Framework
        */
        public override string Test()
        {
            // Intialize output String
            outString = "";
            
            // Define the Slip period.
            slipBegin    = 2d;
            slipDuration = 6d;

            // Verify events by listing them at the end.
            eventsVerify = true;

            TimeManagerInternal tManager = EstablishTimeManager(this);
            DEBUG.ASSERT(tManager != null, "Cannot create TimeManager" , " Created TimeManager ");

            // Create a container Timeline
            ParallelTimeline parent = new ParallelTimeline();
            DEBUG.ASSERT(parent != null, "Cannot create TimeContainer", " Created TimeContainer ");
            parent.BeginTime        = TimeSpan.FromMilliseconds(0);
            parent.Duration         = new Duration(TimeSpan.FromMilliseconds(20));
            parent.Name             = "Parent";
            parent.SlipBehavior     = SlipBehavior.Grow;

            SyncTimeline syncTimeline = EstablishSyncTimeline(this);
            syncTimeline.Name       = "SlippingTimeline";
            syncTimeline.BeginTime  = TimeSpan.FromMilliseconds(0);
            syncTimeline.Duration   = TimeSpan.FromMilliseconds(10);

            ParallelTimeline child2 = new ParallelTimeline();
            child2.Name             = "Child2ndTimeline";
            child2.BeginTime        = TimeSpan.FromMilliseconds(0);
            child2.Duration         = TimeSpan.FromMilliseconds(10);

            AttachAllHandlers( parent );
            AttachAllHandlers( syncTimeline );
            AttachAllHandlers( child2 );

            // Attach TimeNodes to the Container
            parent.Children.Add(syncTimeline);
            parent.Children.Add(child2);
            DEBUG.LOGSTATUS(" Attached Children to Parent ");

            // Create a Clock, connected to the Timeline.
            _clock = parent.CreateClock();          
            DEBUG.ASSERT(_clock != null, "Cannot create Clock " , " Created Clock " );
            
            // Run the Timer
            TimeGenericWrappers.EXECUTE( this, _clock, tManager, 0, 31, 1, ref outString);

            WriteAllEvents();

            return outString;
        }
        
        public override void OnProgress( Clock subject )
        {
            outString += "  " + ((Clock)subject).Timeline.Name + ": CurrentProgress     = " + subject.CurrentProgress + "\n";
            outString += "  " + ((Clock)subject).Timeline.Name + ": CurrentState        = " + subject.CurrentState + "\n";
        }
        
        public override void OnCurrentTimeInvalidated(object subject, EventArgs args)
        {    
        }
        
        public override void OnCurrentGlobalSpeedInvalidated(object subject, EventArgs args)
        {
            if ( ((Clock)subject).Timeline.Name == "Parent" )
            {
                Nullable<double> currentGlobalSpeed = (Nullable<double>)((Clock)subject).CurrentGlobalSpeed;

                if ( currentGlobalSpeed == 0 )
                {
                    _clock.Controller.Stop();
                }
            }
        }
    }
}
