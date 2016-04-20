using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EasyGenerator.Studio.PropertyTools;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    [DbNodeAttribute(ImageIndex = 3)]
    [UiNodeAttribute(ImageIndex = 6)]
    public class ViewInfo : EntityInfo,ICloneable
    {
        public object Clone()
        {
            //MemoryStream stream = new MemoryStream();
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(stream, this);
            //stream.Position = 0;
            //return formatter.Deserialize(stream);
            return this.MemberwiseClone();
        }
    }
}
