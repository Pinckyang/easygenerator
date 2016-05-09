using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Windows.Forms;
using EasyGenerator.Studio.Model;

namespace EasyGenerator.Studio.PropertyTools
{
    public class CheckedListFromLookupTableEditor : UITypeEditor
    {
        private IWindowsFormsEditorService edSvc=null;

        public override UITypeEditorEditStyle  GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context,IServiceProvider provider, object value)
        {

            edSvc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            CheckedListBox listBox = new CheckedListBox();
            listBox.BorderStyle = BorderStyle.None;
            listBox.CheckOnClick = true;
            List<string> checkeditems = value as List<string>;

            DBLookupListBox control= context.Instance as DBLookupListBox;
            ContextObject contextObject=control.GetRoot();
            if (contextObject is Project)
            {
                Project project = contextObject as Project;
                TableInfo entityInfo;
                entityInfo= project.Database.Tables.Find(e=>e.Name==control.LookupTable);
                if (entityInfo == null)
                {
                    return null;
                }

                foreach (ColumnInfo column in entityInfo.Columns)
                {
                    if (checkeditems.Contains(column.Name))
                    {
                        listBox.Items.Add(column.Name,true);
                        continue;
                    }
                    listBox.Items.Add(column.Name);
                }
            }

  
            //foreach (string v in caption as List<string>)
            //{
            //    listBox.Items[.Add(v,true);
               
            //}
            this.edSvc.DropDownControl(listBox);

            List<string> items=new List<string>();

            foreach(object item in listBox.CheckedItems)
            {
                items.Add(item.ToString());
            }
            return items;
        }

    }
}
