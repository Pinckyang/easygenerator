using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Windows.Forms;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.Model.UI;
using EasyGenerator.Studio.Model.DB;

namespace EasyGenerator.Studio.PropertyTools
{
    public class ListColumnsFromLookupTableEditor : UITypeEditor
    {
        private IWindowsFormsEditorService edSvc = null;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {

            edSvc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            ListBox listBox = new ListBox();
            listBox.BorderStyle = BorderStyle.None;
            listBox.SelectedValueChanged += new EventHandler(this.TextChanged);

            string keyfield = value as string;

            DBComboListBoxField control = context.Instance as DBComboListBoxField;
            if (control == null)
            {
                return null;
            }
            ContextObject contextObject = control.GetRoot();
            if (contextObject is Project)
            {
                Project project = contextObject as Project;
                TableInfo entityInfo;
                entityInfo = project.Database.Tables.Find(e=>e.Name==control.LookupTable);
                if (entityInfo == null)
                {
                    return null;
                }

                foreach (ColumnInfo column in entityInfo.Columns)
                {
                    if (keyfield == column.Name)
                    {
                        int index = listBox.Items.Add(column.Name);
                        listBox.SelectedIndex = index;
                        continue;
                    }
                    listBox.Items.Add(column.Name);
                }
            }


            this.edSvc.DropDownControl(listBox);

            return (listBox.SelectedItem == null) ? string.Empty : listBox.SelectedItem.ToString();
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (this.edSvc != null)
            {
                this.edSvc.CloseDropDown();
            }
        }
    }
}
