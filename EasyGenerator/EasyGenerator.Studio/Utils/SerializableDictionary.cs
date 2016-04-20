﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using EasyGenerator.Studio.Model;
using System.Runtime.Serialization;
using System.Xml;

namespace EasyGenerator.Studio.Utils
{
    [Serializable()]
    public class SerializableDictionary<TKey, TValue>:Dictionary<TKey, TValue>, IXmlSerializable
    {
        private ContextObject _owner = null;

        public ContextObject Owner
        {
          get { return _owner; }
          set { _owner = value; }
        }

        public SerializableDictionary()
            : base()
        {
        }

        public SerializableDictionary(ContextObject owner)  
            : base()  
        {
            Owner=owner;
        }  
  
        public SerializableDictionary(IDictionary<TKey, TValue> dictionary)  
            : base(dictionary)  
        { 
 
        }  
  
        public SerializableDictionary(IEqualityComparer<TKey> comparer)  
            : base(comparer)  
        {  

        }  
  
        public SerializableDictionary(int capacity)  
            : base(capacity)  
        {  

        }  
  
        public SerializableDictionary(int capacity, IEqualityComparer<TKey> comparer)  
            : base(capacity, comparer)  
        {  
        }  
  
        protected SerializableDictionary(SerializationInfo info, StreamingContext context)  
            : base(info, context)  
        {  
        }




 
        #region IXmlSerializable Members  
  
        public System.Xml.Schema.XmlSchema GetSchema()  
        {  
            return null;  
        }  
  
        /// <summary>  
        /// 从对象的 XML 表示形式生成该对象  
        /// </summary>  
        /// <param name="reader"></param>  
        public void ReadXml(XmlReader reader)  
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                TKey key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
              //  reader.ReadStartElement(typeof(TValue).Name);
                //reader.Read();
                //string v = reader.GetAttribute("xsi:type");
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                this.Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }  
  
        /**/  
  
        /// <summary>  
        /// 将对象转换为其 XML 表示形式  
        /// </summary>  
        /// <param name="writer"></param>  
        public void WriteXml(XmlWriter writer)  
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            foreach (TKey key in this.Keys)
            {

                writer.WriteStartElement("item");
                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                TValue value = this[key];
                valueSerializer.Serialize(writer, value);

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }  
 
        #endregion IXmlSerializable Members  
    }

    [Serializable()]
    public class ContextObjectDictionary<TKey, TValue> : SerializableDictionary<TKey, TValue> where TValue:ContextObject
    {

        private ContextObjectDictionary()
            : base()
        {
        }

        public ContextObjectDictionary(ContextObject owner)  
            : base(owner)  
        {

        }
        public void Add(TKey key, TValue value)
        {
            value.Owner = Owner;
            base.Add(key, value);
        }
    }


}
