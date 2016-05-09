using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Model.Db;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    [DefaultPropertyAttribute("Name")]
    [UiNodeAttribute(ImageIndex = 5)]
    public class UITableInfo : UIEntityInfo
    {
        public UITableInfo(ContextObject owner)
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
