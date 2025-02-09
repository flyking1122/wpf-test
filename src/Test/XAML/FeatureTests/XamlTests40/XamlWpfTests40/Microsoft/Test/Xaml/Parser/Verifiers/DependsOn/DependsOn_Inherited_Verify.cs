﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Test.Xaml.CustomTypes;
using Microsoft.Test.Xaml.CustomTypes.Attributes;
using Microsoft.Test.Logging;

namespace Microsoft.Test.Xaml.Parser.Verifiers.DependsOn
{
    /// <summary>
    /// Verification class for Xaml File
    /// \src\wpf\Test\XAML\FeatureTests\Data\Parser\DependsOn\DependsOn_Inherited.xaml
    /// </summary>
    public static class DependsOn_Inherited_Verify
    {
        /// <summary>
        /// Verifies DependsOn is respected for inherited properties
        /// </summary>
        public static bool Verify(object rootElement)
        {
            bool result = true;
            CustomRootWithCollection root = (CustomRootWithCollection)rootElement;
            Custom_DependsOn_Inherited targetElement1 = (Custom_DependsOn_Inherited)root.Content[0];

            if (targetElement1.DependsOnInheritedStringProperty != "DependentOn_Inherited")
            {
                GlobalLog.LogEvidence("targetElement1.DependsOnInheritedStringProperty was not \"DependentOn_Inherited\"");
                GlobalLog.LogEvidence("targetElement1.DependsOnInheritedStringProperty was: " + targetElement1.DependsOnInheritedStringProperty);
                result = false;
            }

            return result;
        }
    }
}
