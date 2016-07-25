using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using EasyGenerator.Studio.Model;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace EasyGenerator.Studio.Utils
{

    [Serializable()]
    public class ContextObjectList<T> : List<T> where T : ContextObject
    {
        public ContextObject Owner
        {
            get;
            set;
        }

        public ContextObjectList()
        {

        }
        public ContextObjectList(ContextObject owner)
        {

        }
        public new void Add(T value)
        {
            value.Owner = Owner;
            base.Add(value);
        }
    }


}
