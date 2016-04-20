using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using EasyGenerator.Studio.Controls;
using System.Windows.Forms;
using EasyGenerator.Studio.Builder;

namespace EasyGenerator.Studio.Utils
{
    internal class Common
    {

        internal static void CreateAndWriteToFile(string sPath, string sFileName, string sCode)
        {
            string[] pathArray = (sPath + @"\" + sFileName).Split(new char[] { '\\' });
            string parentDir = "";
            for (int i = 0; i < (pathArray.Length - 1); i++)
            {
                parentDir = parentDir + pathArray[i] + @"\";
            }
            parentDir = parentDir.Substring(0, parentDir.Length - 1);
            if (!Directory.Exists(parentDir))
            {
                Directory.CreateDirectory(parentDir);
            }
            try
            {
                StreamWriter writer = new StreamWriter(sPath + @"\" + sFileName);
                writer.Write(sCode);
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Build the Treeview from Domain
        /// </summary>
        /// <param name="domain"></param>
        internal static void BuildTreeFromDomain(TreeView treeView, Domain domain, bool loadReferences)
        {
            //treeView.Nodes.Clear();
            
            //ExplorerTreeNode domainNode = new ExplorerTreeNode(domain.Name, 3, 3, domain, null);
            //treeView.Nodes.Add(domainNode);

            //TreeNode tablesNode = new TreeNode("Tables");
            //tablesNode.Tag = "Tables";

            //TreeNode viewsNode = new TreeNode("Views");
            //viewsNode.Tag = "Views";

            //TreeNode controlsNode = new TreeNode("Controls");
            //controlsNode.Tag = "Controls";

            //domainNode.ExpandAll();

            //domainNode.Nodes.Add(tablesNode);
            //domainNode.Nodes.Add(viewsNode);
            //domainNode.Nodes.Add(controlsNode);

            //ArrayList allTables = domain.ConnectionInfo.GetAllTables();
            //foreach (Table table in allTables)
            //{
            //    ExplorerTreeNode newTableNode = new ExplorerTreeNode(table.Name, 1, 1, table, tablesNode);
            //    tablesNode.Nodes.Add(newTableNode);

            //    foreach (KeyValuePair<string, Column> pair in table.Columns)
            //    {
            //        ExplorerTreeNode columnNode = new ExplorerTreeNode(pair.Value, 2, 2, pair.Caption, newTableNode);
            //        newTableNode.Nodes.Add(columnNode);
            //    }

            //    if (loadReferences)
            //    {
            //        foreach (Reference outReference in table.OutReferences)
            //        {
            //            ExplorerTreeNode outReferenceNode = new ExplorerTreeNode(outReference.Name, 4, 4, outReference, newTableNode);
            //            newTableNode.Nodes.Add(outReferenceNode);

            //            foreach (ReferenceJoin join in outReference.Joins)
            //            {
            //                ExplorerTreeNode joinNode = new ExplorerTreeNode(join.Name, 5, 5, join, outReferenceNode);
            //                outReferenceNode.Nodes.Add(joinNode);
            //            }
            //        }
            //    }
            //}

            //ArrayList allViews = domain.ConnectionInfo.GetAllViews();
            //foreach (Table view in allViews)
            //{
            //    ExplorerTreeNode newViewNode = new ExplorerTreeNode(view.Name, 6, 6, view, viewsNode);
            //    viewsNode.Nodes.Add(newViewNode);

            //    foreach (KeyValuePair<string, Column> pair in view.Columns)
            //    {
            //        ExplorerTreeNode columnNode = new ExplorerTreeNode(pair.Value, 6, 6, pair.Caption, newViewNode);
            //        newViewNode.Nodes.Add(columnNode);
            //    }

            //}

            //foreach (KeyValuePair<string, ControlBase> pair in domain.Controls)
            //{
            //    ExplorerTreeNode controlNode = new ExplorerTreeNode(pair.Caption.Name, 7, 7, pair.Caption, controlsNode);
            //    controlsNode.Nodes.Add(controlNode);
            //}
        }
    }
}
