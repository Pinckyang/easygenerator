using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace EasyGenerator.Studio.Model
{
    [Serializable()]
    public abstract class ContextObject:INotifyPropertyChanged
    {
        private ContextObject owner = null;

        [BrowsableAttribute(false)]
        [DbNodeInvisibleAttribute()]
        [UiNodeInvisibleAttribute()]
        public virtual ContextObject Owner
        {
            get { return owner; }
            set
            {
                owner = value;
            }
        }

        public static ContextObject GetRoot(ContextObject contextObject)
        {
            if (contextObject.owner != null)
            {
                return GetRoot(contextObject.owner); 
            }
            return contextObject.owner;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(object obj,string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(obj, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
