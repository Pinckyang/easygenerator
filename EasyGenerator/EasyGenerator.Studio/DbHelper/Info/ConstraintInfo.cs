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

namespace EasyGenerator.Studio.DbHelper.Info
{
    /// <summary>
    /// Describes a single foreign keyField of a table.
    /// </summary>
    public struct ConstraintInfo
    {
        /// <summary>
        /// Name of constraint.
        /// </summary>
        public string Name;
        /// <summary>
        /// Name of table containing coressponding primary keyField. 
        /// </summary>
        public string PrimaryKeyTable;
        /// <summary>
        /// Column names in the primary keyField table.
        /// </summary>
        public string[] PrimaryKeyTableColumns;
        /// <summary>
        /// Foreign keyField column names in the table having foreign keys.
        /// </summary>
        public string[] Columns;
        /// <summary>
        /// if foreign keyField is cascade on delete;
        /// </summary>
        public bool OnDeleteCascade;
        /// <summary>
        /// if foreign keyField is cascade on update;
        /// </summary>
        public bool OnUpdateCascade;
    }
}
