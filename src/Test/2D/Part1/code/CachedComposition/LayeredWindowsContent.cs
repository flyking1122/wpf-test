﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Test.Logging;

namespace Microsoft.Test.Graphics.CachedComposition
{
    /// <summary>
    /// Put the cached brush on a layered window - the test creating this will have to ensure that the window is layered.
    /// </summary>
    class LayeredWindowsContent : ChangeableContent
    {
        #region Public methods

        public override FrameworkElement Construct(Requirements req)
        {
            //create the animation so that we can change it later if requested
            CreateAnimation();

            //create and save a brush so that we can change it later to invalidate the cache
            B = new SolidColorBrush();
            B.Color = Colors.Red;
            
            //use the created brush inside a button
            DisplayButton = new Button();
            DisplayButton.Background = B;
            DisplayButton.Height = 100;
            DisplayButton.Width = 100;

            //this is the button that will have the BitmapCache on it
            cache = CreateCache(renderAtScale);
            DisplayButton.CacheMode = cache;                  

            Button OuterButton = DisplayButton;
            
            if (req.bitmapCacheBrush)
            {
                OuterButton = WrapUIElementInBCB(OuterButton, req.cacheOnBitmapCacheBrush);
            }

            return OuterButton;
        }

        public override TestResult Display() { return TestResult.Pass; }

        public override TestResult ChangeColor()
        {
            B.Color = Colors.Green;
            return TestResult.Pass;
        }

        public override void ChangeClearType()
        {
            if (cache is BitmapCache)
            {
                cache.EnableClearType = !cache.EnableClearType;
            }

        }

        #endregion
    }
}
