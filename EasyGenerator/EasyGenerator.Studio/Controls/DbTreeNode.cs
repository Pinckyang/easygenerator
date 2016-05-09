using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using EasyGenerator.Studio.Model;
using EasyGenerator.Studio.PropertyTools;
using System.Reflection;
using System.Collections;
using EasyGenerator.Studio.Utils;

namespace EasyGenerator.Studio.Controls
{
    public class DbTreeNode : TreeNode
    {
        private TreeNodeType nodeType;
        private object contextObject;

        public TreeNodeType NodeType
        {
          get { return nodeType; }
          set { nodeType = value; }
        }

        public object ContextObject
        {
          get { return contextObject; }
          set { contextObject = value; }
        }


        public DbTreeNode(string text, int imageIndex, int selectedImageIndex, ContextObject contextObject, TreeNodeType nodeType)
            : base(text, imageIndex, selectedImageIndex)
        {
            this.nodeType=nodeType;
            this.contextObject=contextObject;
        }
        public DbTreeNode(object contextObject,string propertyName,Type typeObject)
            : base(string.Empty, 0, 0)
        {
            this.contextObject = contextObject;

            object[] o = typeObject.GetProperty(propertyName).GetCustomAttributes(typeof(DbNodeAttribute), false);
            if (o != null && o.Length > 0)
            {
                DbNodeAttribute attribute = o[0] as DbNodeAttribute;
                this.Text = string.IsNullOrEmpty(attribute.Text) ? propertyName : attribute.Text;
                this.ImageIndex = attribute.ImageIndex;
                this.SelectedImageIndex = attribute.ImageIndex;
            }
            if (contextObject is IList)
            {
                ICollection values = contextObject as IList;
                foreach (object value in values)
                {
                    this.Nodes.Add(new DbTreeNode((ContextObject)value));
                }
                
            }
        }
        public DbTreeNode(ContextObject contextObject)
            : base(string.Empty, 0, 0)
        {
            this.contextObject = contextObject;

            object [] o =this.contextObject.GetType().GetCustomAttributes(typeof(DbNodeAttribute), false);
            if (o != null && o.Length > 0)
            {
                DbNodeAttribute attribute = o[0] as DbNodeAttribute;
                this.Text = string.IsNullOrEmpty(attribute.Text) ? this.contextObject.ToString() : attribute.Text;
                this.ImageIndex = attribute.ImageIndex;
                this.SelectedImageIndex = attribute.ImageIndex;
            }

            foreach (PropertyInfo propertyInfo in this.contextObject.GetType().GetProperties())
            {
                object[] attributeInvisible=propertyInfo.GetCustomAttributes(typeof(DbNodeInvisibleAttribute), false);
                if (attributeInvisible != null && attributeInvisible.Length >0)
                {
                    continue;
                }

                object[] attributeNode = propertyInfo.GetCustomAttributes(typeof(DbNodeAttribute), false);
                if (attributeNode != null && attributeNode.Length > 0)
                {
                    this.Nodes.Add(new DbTreeNode(propertyInfo.GetValue(this.contextObject, null), propertyInfo.Name, this.contextObject.GetType()));
                }
                else if (attributeNode == null || attributeNode.Length <1)
                {
                    object propertyValue = propertyInfo.GetValue(this.contextObject, null);
                    if (propertyValue is IList)
                    {

                        ICollection values = propertyValue as IList;
                        foreach (object value in values)
                        {
                            this.Nodes.Add(new DbTreeNode((ContextObject)value));
                        }
                    }
                }
            }
        }
    }
}
