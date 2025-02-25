// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Avalon.Test.CoreUI.Trusted;
using Avalon.Test.CoreUI;
using System.ComponentModel;

using System.Globalization;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Markup;
using System.Threading;
using System.Windows.Threading;

using Avalon.Test.CoreUI.Common;

using Avalon.Test.CoreUI.CoreInput.Common;
using Avalon.Test.CoreUI.Parser.Common;
using Microsoft.Test.Win32;
using Microsoft.Test.Discovery;
using Microsoft.Test;
using Microsoft.Test.Logging;

namespace Avalon.Test.CoreUI.CoreInput
{
    /// <summary>
    /// Verify ModifierKeysConverter ConvertTo method for invalid keys.
    /// </summary>
    /// <description>
    /// This is part of a collection of unit tests for input events.
    /// </description>
    /// <author>Microsoft</author>
 
    /// <



    [CoreTestsLoader(CoreTestsTestType.MethodBase)]
    public class ModifierKeysConverterConvertToInvalidKeyApp : TestApp
    {
        /// <summary>
        /// Launch our test.
        /// </summary>
        [TestCase("2",@"CoreInput\TypeConverter","Window",@"Compile and Verify ModifierKeysConverter ConvertTo method for invalid keys in window.")]        
        public static void LaunchTestCompile() 
        {
            HostType hostType = (HostType)Enum.Parse(typeof(HostType), DriverState.DriverParameters["TestParameters"]);


            GenericCompileHostedCase.RunCase(
                "Avalon.Test.CoreUI.CoreInput", 
                "ModifierKeysConverterConvertToInvalidKeyApp",
                "Run", 
                hostType,null,null );
            
        }

        /// <summary>
        /// Launch our test.
        /// </summary>
        [TestCase("2",@"CoreInput\TypeConverter","HwndSource",@"KeyConverter and Verify KeyConverter ConvertTo method for invalid Key in HwndSource.")]
        public static void LaunchTest() 
        {
            HostType hostType = (HostType)Enum.Parse(typeof(HostType),DriverState.DriverParameters["TestParameters"]);

            ExeStubContainerFramework exe = new ExeStubContainerFramework(hostType);
            exe.Run(new ModifierKeysConverterConvertToInvalidKeyApp(),"Run");
            
        }

        /// <summary>
        /// Setup the test.
        /// </summary>
        /// <param name="sender">App sending the callback.</param>
        /// <returns>Null object.</returns>
        public override object DoSetup(object sender)
        {
            CoreLogger.LogStatus("Getting Converter....");
            _converter = TypeDescriptor.GetConverter(typeof(ModifierKeys));
            Debug.Assert(_converter is ModifierKeysConverter);

            // Tell the parser how to map XML namespaces to CLR namespaces and assemblies.
            CoreLogger.LogStatus("Getting Type Descriptor Context....");
            ParserContext pc = new ParserContext();
            pc.XamlTypeMapper = XamlTypeMapper.DefaultMapper;
            pc.XamlTypeMapper.AddMappingProcessingInstruction("inputcore", "System.Windows.Input", "PresentationCore");
            _typeDescriptorContext = new TestTypeDescriptorContext(pc);
            return null;
        }

        /// <summary>
        /// Validate the test.
        /// </summary>
        /// <param name="arg">Not used.</param>
        /// <returns>Null object.</returns>
        public override object DoValidate(object arg)
        {
            CoreLogger.LogStatus("Validating..."); ;

            // Note: for this test we are concerned about whether the proper conversion occurred.
            // If proper conversions, we get a Key combination.

            CoreLogger.LogStatus("Converting...");
            bool bExceptionThrown = false;
            object convertedKey;
            try {
                convertedKey = (_converter.ConvertTo(_typeDescriptorContext, CultureInfo.InvariantCulture,
                    (ModifierKeys)(-1), typeof(string)));
                string convertedString = convertedKey as string;
                CoreLogger.LogStatus("Result string: '" + convertedString + "'");
            } catch (InvalidEnumArgumentException e) {
                bExceptionThrown = true;
                CoreLogger.LogStatus(".. expected exception:\n" + e.ToString());
            }

            bool actual = bExceptionThrown;
            bool expected = true;

            CoreLogger.LogStatus("Exception thrown? " + actual + ", expected: " + expected);

            bool eventFound = (actual == expected);

            CoreLogger.LogStatus("Setting log result to " + eventFound);
            this.TestPassed = eventFound;

            CoreLogger.LogStatus("Validation complete!");

            return null;

        }

        private TypeConverter _converter;

        /// <summary>
        /// Store a type descriptor context, for use with the ConvertTo API.
        /// </summary>
        private ITypeDescriptorContext _typeDescriptorContext;
    }
}

