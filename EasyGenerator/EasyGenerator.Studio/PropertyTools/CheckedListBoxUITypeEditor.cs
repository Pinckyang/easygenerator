using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;

namespace EasyGenerator.Studio.PropertyTools
{
    public class CheckedListBoxUITypeEditor : UITypeEditor
    {
        public CheckedListBox checklisbox = new CheckedListBox();
        private IWindowsFormsEditorService es;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }
    }
}
