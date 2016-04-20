/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace EasyGenerator.Studio.Controls
{
    public class MirroredTreeView : System.Windows.Forms.TreeView
    {
        const int WS_EX_LAYOUTRTL = 0x400000;
        const int WS_EX_NOINHERITLAYOUT = 0x100000;
        private bool mirrored = false;
        [Description("Change to the right-to-left layout."), DefaultValue(false),
        Localizable(true), Category("Appearance"), Browsable(true)]
        public bool Mirrored
        {
            get
            {
                return this.mirrored;
            }
            set
            {
                if (this.mirrored != value)
                {
                    this.mirrored = value;
                    base.OnRightToLeftChanged(EventArgs.Empty);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP;
                CP = base.CreateParams;
                if (this.mirrored)
                {
                    CP.ExStyle = CP.ExStyle | WS_EX_LAYOUTRTL | WS_EX_NOINHERITLAYOUT;
                }
                return CP;
            }
        }

    }
}
