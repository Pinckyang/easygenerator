using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyGenerator.Studio.PropertyTools;
using EasyGenerator.Studio.Model.DB;

namespace EasyGenerator.Studio.Model.UI
{
    [Serializable()]
    [UiNodeAttribute(ImageIndex = 6)]
    public class GUIViewInfo : GUIEntityInfo
    {
        public GUIViewInfo(ContextObject owner)
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
