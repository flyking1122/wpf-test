// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Avalon.Test.CoreUI.Trusted;
using Avalon.Test.CoreUI;
using System.Windows;
using System.Windows.Controls;
using Avalon.Test.CoreUI.Common;
using System.Windows.Media;
using System.Windows.Documents;
using System.Collections;
using Avalon.Test.CoreUI.Parser;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace Avalon.Test.CoreUI.Serialization
{
    /// <summary>
    /// Verify xaml files for Animation
	/// Verification method for Dockpanel.xaml from Animation group
	/// Author: Microsoft
    /// </summary>
	public class ICollectionSerializationVerifier
    {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uie"></param>
		/// <param name="IDedObjects"></param>
		public static void Verify(UIElement uie, Hashtable IDedObjects)
        {
			DockPanel myPanel = uie as DockPanel;
			
			CoreLogger.LogStatus("Verifying Item ...");
			CustomItem1 myItem = IDedObjects["item1"] as CustomItem1;
			VerifyElement.VerifyBool(null != myItem, true);

			
			CoreLogger.LogStatus("Verifying IistProp ...");
			ArrayList prop1 = myItem.ListProp as ArrayList;
			VerifyElement.VerifyBool(null != prop1, true);
			VerifyElement.VerifyInt(prop1.Count, 3);
			
			CoreLogger.LogStatus("Verifying ListDP1 ...");
			ArrayList prop2 = myItem.ListDP1 as ArrayList;
			VerifyElement.VerifyBool(null != prop2, true);
			VerifyElement.VerifyInt(prop2.Count, 2);			

			CoreLogger.LogStatus("Verifying ListDP2 ...");
			IEnumerable prop3 = myItem.ListDP2 as IEnumerable;
			VerifyElement.VerifyBool(null != prop3, true);

			CoreLogger.LogStatus("Verifying DictionaryProp ...");
			Hashtable prop4 = myItem.DictionaryProp as Hashtable;
			VerifyElement.VerifyBool(null != prop4, true);
			VerifyElement.VerifyInt(prop4.Count, 2);	

			CoreLogger.LogStatus("Verifying DictionaryDP1 ...");
			Hashtable prop5 = myItem.DictionaryDP1 as Hashtable;
			VerifyElement.VerifyBool(null != prop5, true);
			VerifyElement.VerifyInt(prop5.Count, 2);

			CoreLogger.LogStatus("Verifying DictionaryDP2 ...");
			Hashtable prop6 = myItem.DictionaryDP2 as Hashtable;
			VerifyElement.VerifyBool(null != prop6, true);
			VerifyElement.VerifyInt(prop6.Count, 2);
			
		}

    }
}
