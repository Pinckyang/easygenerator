﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EasyGenerator.Studio.Model.Ui
{
    [Serializable()]
    public class DBFileUploadField : UIColumnInfo, ICloneable
    {
        public DBFileUploadField(ContextObject owner)
            : base(owner)
        {
            this.ColSpan = 2;
        }

        [DefaultValue(2)]
        [XmlAttribute("ColSpan")]
        public override int ColSpan
        {
            get
            {
                return base.ColSpan;
            }
            set
            {
                base.ColSpan = value;
            }
        }

        [DefaultValue(1)]
        [XmlAttribute("RowSpan")]
        public override int RowSpan
        {
            get
            {
                return base.RowSpan;
            }
            set
            {
                base.RowSpan = value;
            }
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
