using System;
using System.Collections.Generic;
using System.Text;

namespace EasyGenerator.Studio.PropertyTools
{
    public class DbNodeAttribute : Attribute
    {

        private string text;
        private int imageIndex;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }
    }

    public class UiNodeAttribute : Attribute
    {

        private string text;
        private int imageIndex;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }
    }
}
