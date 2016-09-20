using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace XmlFiller
{
    public static class TreeNodeExtension
    {
        public static bool ErNill(this TreeNode value)
        {

            if (value.Tag != null && ((tagBag)value.Tag).DataIndhold != null && ((tagBag)value.Tag).DataIndhold.ToString().Length > 0)
            {
                return false;
            }

            //if (!svar)
            {
                foreach (TreeNode n in value.Nodes)
                {
                    if (!n.ErNill())
                    {
                        return false;
                    }
                }
            }


            return true;
        }


        public static bool ErArray(this TreeNode value)
        {
            if (value != null && value.Tag != null)
            {
                return ((tagBag)value.Tag).FeltType.IsArray;
            }
            return false;
        }


        public static TreeNode AddNode(this TreeNode value, PropertyInfo p)
        {
            TreeNode res = value.Nodes.Add(p.Name + (p.PropertyType.IsArray ? " *" : ""));
            res.Tag = new tagBag(p.PropertyType);
            res.Name = value.Name + "/" + p.Name;
            ((tagBag)res.Tag).Navn = p.Name;
            return res;
        }

        public static TreeNode AddNode(this TreeNode value, Type p, int index=0)
        {
            TreeNode res = value.Nodes.Add(p.Name + (p.IsArray ? " *" : ""));
            res.Tag = new tagBag(p);
            res.Name = value.Name + "/" + res.Text + "[" + index.ToString() + "]"; ;
            ((tagBag)res.Tag).Navn = p.Name;

            return res;
        }

        public static string IndholdSet(this TreeNode value, string indhold)
        {
            tagBag bag = (tagBag)value.Tag;
            bag.DataIndhold = indhold;
            value.Text = value.Text.Split(':')[0] + ": " + indhold;
            return indhold;
        }

        public static string TextNavn(this TreeNode value)
        {
            if (value != null && value.Tag != null)
            {
                return ((tagBag)value.Tag).Navn;
            }
            return "";
        }

    }
}
