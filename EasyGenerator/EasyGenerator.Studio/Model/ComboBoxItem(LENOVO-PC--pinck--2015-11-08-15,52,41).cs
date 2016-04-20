using System;
using System.Collections.Generic;
using System.Text;

namespace EasyGenerator.Studio.Model
{
    public struct ComboBoxItem
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set { value = value; }
        }
        private string caption;

        public string Caption
        {
            get { return this.caption; }
            set { this.caption = value; }
        }
    }
}
