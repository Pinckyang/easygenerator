using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace EasyGenerator.Studio.PropertyTools
{
    public class PropertyHelper
    {
        public static void SetPropertyVisibility(object obj, string propertyName, bool visible)
        {
            Type type = typeof(BrowsableAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("browsable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            if (fld == null)
            {
                return;
            }
            fld.SetValue(attrs[type], visible);
        }

        public static void SetPropertyReadOnly(object obj, string propertyName, bool readOnly)
        {
            Type type = typeof(ReadOnlyAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("isReadOnly", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            if (fld == null)
            {
                return;
            }
            fld.SetValue(attrs[type], readOnly);
        }

        public static void SetPropertyDefaultValue(object obj, string propertyName, object value)
        {
            Type type = typeof(DefaultValueAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("caption", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            if (fld == null)
            {
                return;
            }
            fld.SetValue(attrs[type], value);
        }
    }
}
