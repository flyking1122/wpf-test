// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// Avalon Timing Verification Test Automation 
//  

/* 
 * Description:  Verify CurrentTimeInvalidated given a Seek using TimeSeekOrigin.Duration and an offset of 0

*/

//Pass Verification:
//  The output of this test should match the expected output in bug130Expect.txt.

//Warnings:
//  Any changes made in the output should be reflected bug130Expect.txt file

//Dependencies:
//  TestRuntime.dll, Timing\Common\GlobalClasses.cs
//***************************************************************************************************
using System;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Test.Logging;

namespace Microsoft.Test.Animation
{
    class bug130 :ITimeBVT
    {
        TimeManagerInternal   _tManager;
        ClockGroup            _tClock;

        /*
        *  Function:   Test
        *  Arguments:  Framework
        */
        public override string Test()
        {
            //Intialize output String
            outString = "";

            _tManager = EstablishTimeManager(this);
            DEBUG.ASSERT(_tManager != null, "Cannot create TimeManager" , " Created TimeManager ");

            // Create a TimeContainer
            ParallelTimeline timeline = new ParallelTimeline();
            DEBUG.ASSERT(timeline != null, "Cannot create Timeline", " Created Timeline ");
            timeline.BeginTime          = TimeSpan.FromMilliseconds(0);
            timeline.Duration           = new Duration(TimeSpan.FromMilliseconds(8));
            timeline.Name               = "Timeline";
            AttachCurrentStateInvalidated( timeline );
            
            // Create a Clock, connected to the Timeline.
            _tClock = timeline.CreateClock();          
            DEBUG.ASSERT(_tClock != null, "Cannot create Clock" , " Created Clock " );
            
            //Run the Timer               
            TimeGenericWrappers.EXECUTE( this, _tClock, _tManager, 0, 11, 1, ref outString );

            return outString;
        }

        public override void PostTick( int i )
        {
            if ( i == 4 )
            {
                _tClock.Controller.Seek( TimeSpan.FromMilliseconds(0), TimeSeekOrigin.Duration );
            }
        } 

        public override void OnCurrentStateInvalidated(object subject, EventArgs args)
        {
            outString += "----------CurrentStateInvalidated fired --- CurrentState: " + ((Clock)subject).CurrentState  + "\n";
        }
    }
}
