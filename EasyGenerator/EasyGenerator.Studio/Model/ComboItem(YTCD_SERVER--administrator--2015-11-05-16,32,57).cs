using System;
using System.Collections.Generic;
using System.Text;

namespace EasyGenerator.Studio.Model
{
    public struct ComboItem
    {
        private object key;

        public object Key
        {
            get { return key; }
            set { key = value; }
        }
        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
