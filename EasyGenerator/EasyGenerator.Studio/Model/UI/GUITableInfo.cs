using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Model.DB;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [UiNodeAttribute(ImageIndex = 5)]
    public class GUITableInfo : GUIEntityInfo
    {
        public GUITableInfo(ContextObject owner)
            : base(owner)
        {
        }

        public TableInfo TableInfo
        {
            get { return (TableInfo)base.EntityInfo; }
            set {base.EntityInfo = value;}
        }

        public override string ToString()
        {
            return TableInfo.ToString();
        }
    }
}
