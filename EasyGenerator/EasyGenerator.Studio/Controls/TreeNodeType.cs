/*
 * Copyright ?2005-2006 Danilo Mendez <danilo.mendez@kontac.net>
 * Adolfo Socorro <ajs@esolutionspr.com>
 * www.kontac.net 
 * All rights reserved.
 * Released under both BSD license and Lesser GPL library license.
 * Whenever there is any discrepancy between the two licenses,
 * the BSD license will take precedence.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace EasyGenerator.Studio.Controls
{
    public enum TreeNodeType
    {
        Project,
        LoginModule,
        CommonModule,
        SystemModule,
        Module,
        Window,
        Table,
        View,
        Column,
        PrimaryKey,
        ForeignKey,
        Reference,
        ReferenceJoin
    }
}
