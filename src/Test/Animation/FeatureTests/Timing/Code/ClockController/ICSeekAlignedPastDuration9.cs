// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// Avalon Timing Verification Test Automation 
//  

/* 
 * Description: Verify Seeking via SeekAlignedToLastTick into an AutoReverse period (TimeSeekOrigin.Duration)
 */


//Pass Verification:
//   The output of this test should match the expected output in ICSeekAlignedPastDuration9Expect.txt

//Warnings:
//  Any changes made in the output should be reflected ICSeekAlignedPastDuration9Expect.txt file

//Dependencies:
//  TestRuntime.dll, Timing\Common\GlobalClasses.cs

using System;
using System.Windows;
using System.Windows.Media.Animation;

using Microsoft.Test.Logging;
using Microsoft.Test.TestTypes;
using Microsoft.Test.Discovery;

namespace Microsoft.Test.Animation
{
    class ICSeekAlignedPastDuration9 :ITimeBVT
    {
        ParallelTimeline    _tNode;
        Clock               _tClock;
        
        /*
         *  Function:   Test
         *  Arguments:  Framework
         */
        public override string Test()
        {
            TimeManagerInternal tManager = EstablishTimeManager(this);
            DEBUG.ASSERT(tManager != null, "Cannot create TimeManager" , " Created TimeManager ");
            
            // Create a TimeNode
            _tNode = new ParallelTimeline();
            DEBUG.ASSERT(_tNode != null, "Cannot create Timeline" , " Created Timeline " );
            _tNode.BeginTime     = TimeSpan.FromMilliseconds(0);
            _tNode.Duration      = new Duration(TimeSpan.FromMilliseconds(10));
            _tNode.AutoReverse   = true;
            _tNode.Name          = "TimeNode";           
            
            // Create a Clock, connected to the Timeline.
            _tClock = _tNode.CreateClock();     
            DEBUG.ASSERT(_tClock != null, "Cannot create Clock" , " Created Clock " );
            
            AttachCurrentStateInvalidatedTC(_tClock);
            AttachCurrentTimeInvalidatedTC(_tClock);

            //Intialize output String
            outString = "";
            
            //Run the Timer         
            TimeGenericWrappers.EXECUTE( this, _tClock, tManager, 0, 35, 1, ref outString);
            
            return outString;
        }

        public override void PostTick( int i )
        {
            if ( i == 12 )
            {
                _tClock.Controller.SeekAlignedToLastTick( TimeSpan.FromMilliseconds(-10), TimeSeekOrigin.Duration );
            }
        }

        public override void OnProgress( Clock subject )
        {
            outString += "------CurrentState        = " + ((ClockGroup)subject).CurrentState       + "\n";
            outString += "------CurrentTime         = " + ((ClockGroup)subject).CurrentTime        + "\n";
            outString += "------CurrentProgress     = " + ((ClockGroup)subject).CurrentProgress    + "\n";
            outString += "------CurrentGlobalSpeed  = " + ((ClockGroup)subject).CurrentGlobalSpeed + "\n";
            outString += "------CurrentIteration    = " + ((ClockGroup)subject).CurrentIteration   + "\n";
        }

        public override void OnCurrentTimeInvalidated(object subject, EventArgs args)
        {
        }
    }
}
