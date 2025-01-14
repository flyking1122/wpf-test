// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using Annotations.Test.Framework;
using System.Windows.Documents;
using Proxies.System.Windows.Annotations;
using Proxies.System.Windows.Controls;
using System.Collections.Generic;
using System.Reflection;
using Annotations.Test.Reflection;
using System.Windows.Media;

namespace Avalon.Test.Annotations
{
	/// <summary>
	/// Object that encapsulates the procedure of creating a Highlight.
	/// </summary>
	public class HighlightDefinition : AnnotationDefinition
	{
		public HighlightDefinition(ISelectionData anchor, Color color)
			: base(anchor)
		{
			_color = color;
            if (_color.A == byte.MaxValue)
                _color.A = 54;
			_author = "";
		}

        public override void Create(ATextControlWrapper target)
		{
			Create(target, false);
		}

        public override void Create(ATextControlWrapper target, bool goToSelection)
		{
			if (Anchor != null)
				Anchor.SetSelection(target.SelectionModule);
			if (goToSelection)
				target.BringIntoView(Anchor);

			AnnotationHelper.CreateHighlightForSelection(target.Service, _author, new SolidColorBrush(_color));
			DispatcherHelper.DoEvents();			
		}

        public override void Delete(ATextControlWrapper target)
		{
			Anchor.SetSelection(target.SelectionModule);
			AnnotationHelper.ClearHighlightsForSelection(target.Service);
			DispatcherHelper.DoEvents();
		}

		#region Fields

		private Color _color;
		private string _author;

		#endregion
	}
}	
