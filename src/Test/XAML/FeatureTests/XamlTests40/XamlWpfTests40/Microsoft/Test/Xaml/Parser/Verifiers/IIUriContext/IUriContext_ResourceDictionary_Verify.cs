﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using System.Windows.Markup;
using Microsoft.Test.Logging;

namespace Microsoft.Test.Xaml.Parser.Verifiers.IIUriContext
{
    /// <summary>
    /// Verification class for Xaml File
    /// \src\wpf\Test\XAML\FeatureTests\Data\Parser\IUriContext\IUriContext_ResourceDictionary.xaml
    /// </summary>  
    public static class IUriContext_ResourceDictionary_Verify
    {
        /// <summary>
        /// This method verifies that the BaseUri of the IUriContext_ResourceDictionary is set correctly
        /// </summary>
        /// <param name="obj"> The object. </param>
        /// <returns> bool value </returns>
        public static bool Verify(object obj)
        {
            bool result = true;
            if (obj == null)
            {
                GlobalLog.LogStatus("No Root Element in IUriContext_ResourceDictionary is Found");
                return result = false;
            }

            ResourceDictionary resourceDict = obj as ResourceDictionary;
            IUriContext iUriCntxt = resourceDict;
            string path = Environment.CurrentDirectory + @"/IUriContext_ResourceDictionary.xaml";
            //// Adding file and replacing the \\ with / in path to compare the BaseUri
            path = @"file:///" + path.Replace("\\", "/");
            if (iUriCntxt == null)
            {
                GlobalLog.LogStatus("The IUriContext is Null");
                return result = false;
            }
            else if (iUriCntxt.BaseUri == null)
            {
                GlobalLog.LogStatus("The Base Uri of IUriContext_ResourceDictionary is Null");
                return result = false;
            }
            else
            {
                if (path != iUriCntxt.BaseUri.ToString())
                {
                    GlobalLog.LogStatus("The Base Uri of IUriContext_ResourceDictionary is Invalid");
                    return result = false;
                }
            }

            GlobalLog.LogStatus("The Base Uri of IUriContext_ResourceDictionary is Valid");
            return result;
        }
    }
}
