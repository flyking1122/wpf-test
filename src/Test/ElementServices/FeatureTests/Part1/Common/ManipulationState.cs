﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.Test.Input.MultiTouch
{
    public enum ManipulationState
    {
        None,
        ManipulationStarting,
        ManipulationStarted,
        ManipulationDelta,        
        ManipulationCompleted
    }
}