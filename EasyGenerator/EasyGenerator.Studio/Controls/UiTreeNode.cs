using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using EasyGenerator.Studio.PropertyTools;
using System.Collections;
using EasyGenerator.Studio.Model;
using System.Reflection;
using System.ComponentModel;
using EasyGenerator.Studio.Model.DB;

namespace EasyGenerator.Studio.Controls
{
    [Serializable]
    public class UiTreeNode:TreeNode
    {
        private object contextObject;
        public object ContextObject
        {
          get { return contextObject; }
          set { contextObject = value; }
        }

        public UiTreeNode(object contextObject,string propertyName,Type typeObject)
            : base(string.Empty, 0, 0)
        {
            this.contextObject = contextObject;

            if (contextObject is ContextObject)
            {
                (contextObject as ContextObject).PropertyChanged += new PropertyChangedEventHandler(contextObject_PropertyChanged);
            }

            object[] o = typeObject.GetProperty(propertyName).GetCustomAttributes(typeof(UiNodeAttribute), false);
            if (o != null && o.Length > 0)
            {
                UiNodeAttribute attribute = o[0] as UiNodeAttribute;
                this.Text = string.IsNullOrEmpty(attribute.Text) ? contextObject.ToString() : attribute.Text;
                this.ImageIndex = attribute.ImageIndex;
                this.SelectedImageIndex = attribute.ImageIndex;
            }
            if (contextObject is IDictionary)
            {
                ICollection values = (contextObject as IDictionary).Values;
                foreach (object value in values)
                {
                    ContextObject xobject = (ContextObject)value;
                    UiTreeNode node= new UiTreeNode((ContextObject)value);
                    
                    this.Nodes.Add(node);
                }

            }

           // AddProperty();

        }



        void contextObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Text = sender.ToString();
        }
        public UiTreeNode(ContextObject contextObject)
            : base(string.Empty, 0, 0)
        {
            this.contextObject = contextObject;

            contextObject.PropertyChanged += new PropertyChangedEventHandler(contextObject_PropertyChanged);


            object [] o =this.contextObject.GetType().GetCustomAttributes(typeof(UiNodeAttribute), false);
            if (o != null && o.Length > 0)
            {
                UiNodeAttribute attribute = o[0] as UiNodeAttribute;
                this.Text = string.IsNullOrEmpty(attribute.Text) ? this.contextObject.ToString() : attribute.Text;
                this.ImageIndex = attribute.ImageIndex;
                this.SelectedImageIndex = attribute.ImageIndex;
            }

            if (contextObject is ReferencedInfo)
            {
                ReferencedInfo referenceInfo = (ReferencedInfo)contextObject;
                if (referenceInfo.TableName == referenceInfo.ReferencedTableName)
                {
                    return;
                }

            }

            AddProperty();
        }

        private void AddProperty()
        {
            foreach (PropertyInfo propertyInfo in this.contextObject.GetType().GetProperties())
            {
                object[] attributeInvisible = propertyInfo.GetCustomAttributes(typeof(UiNodeInvisibleAttribute), false);
                if (attributeInvisible != null && attributeInvisible.Length > 0)
                {
                    continue;
                }

                object[] attributeNode = propertyInfo.GetCustomAttributes(typeof(UiNodeAttribute), false);
                if (attributeNode != null && attributeNode.Length > 0)
                {
                    object propertyValue = propertyInfo.GetValue(this.contextObject, null);
                    this.Nodes.Add(new UiTreeNode(propertyValue, propertyInfo.Name, this.contextObject.GetType()));

                }
                else if (attributeNode == null || attributeNode.Length < 1)
                {
                    object propertyValue = propertyInfo.GetValue(this.contextObject, null);
                    if (propertyValue is IDictionary)
                    {

                        ICollection values = (propertyValue as IDictionary).Values;
                        foreach (object value in values)
                        {
                            ContextObject xobject = (ContextObject)value;

                            this.Nodes.Add(new UiTreeNode(xobject));
                        }
                    }
                    else if (propertyValue is ContextObject)
                    {
                        ContextObject xobject = (ContextObject)propertyValue;
                        this.Nodes.Add(new UiTreeNode(xobject));

                    }
                }
            }
        }
    }
}
