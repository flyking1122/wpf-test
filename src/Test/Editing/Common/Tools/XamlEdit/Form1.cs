// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XamlPadEdit
{
    public partial class Form1 : Form
    {
        public WebBrowser browser;
        public bool bDoneOnce = false;

        public Form1()
        {
            InitializeComponent();
        }
    }
}