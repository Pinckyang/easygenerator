using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Model.Db;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    [UiNodeAttribute(ImageIndex = 6)]
    public class UIViewInfo : UIEntityInfo
    {
        public UIViewInfo(ContextObject owner)
            : base(owner)
        {
        }
        public TableInfo TableInfo
        {
            get { return (TableInfo)base.EntityInfo; }
            set { base.EntityInfo = value;}
        }

        public override string ToString()
        {
            return TableInfo.ToString();
        }
    }
}
