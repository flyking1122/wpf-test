// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

// Context ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("a89fe641-dfe6-4568-8e19-cf12fcd18437")]

//Xmlns defninitions
[assembly: System.Windows.Markup.XmlnsDefinition("http://XamlTestTypes", "Microsoft.Test.Xaml.Types")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://XamlTestTypes", "Microsoft.Test.Xaml.Types.Attributes")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://XamlTestTypes", "Microsoft.Test.Xaml.Types.ClrClasses")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://XamlTestTypes", "Microsoft.Test.Xaml.Types.Repro")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://XamlTestTypes", "Microsoft.Test.Xaml.Types.Schema")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://XamlTestTypes", "Microsoft.Test.Xaml.Types.SDX")]

[assembly: System.Windows.Markup.XmlnsDefinition("http://test.schemas.microsoft.com/winfx/2006/xaml/presentation", "Microsoft.Test.Xaml.Types")]
//[assembly: System.Windows.Markup.XmlnsPrefix("http://test.schemas.microsoft.com/winfx/2006/xaml/presentation", "avtest")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://test.schemas.microsoft.com/netfx/2007/xaml/presentation", "Microsoft.Test.Xaml.Types")]
//[assembly: System.Windows.Markup.XmlnsPrefix("http://test.schemas.microsoft.com/netfx/2007/xaml/presentation", "wpftest")]

[assembly: InternalsVisibleTo("XamlWpfTests40")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
#if VS_BUILD
[assembly: AssemblyVersionAttribute("4.0.0.0")]
#endif
