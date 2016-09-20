using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XmlFiller.Views
{
    public partial class VisSomTabel : Form
    {
        TreeNode myData = null;
        public VisSomTabel()
        {
            InitializeComponent();
        }
        public VisSomTabel(TreeNode data)
        {
            myData = data;
            InitializeComponent();
        }

        private void VisSomTabel_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + ": " + myData.Text;
            DataTable dt = new DataTable();
            foreach (TreeNode r in myData.Nodes[0].Nodes)
            {
                dt.Columns.Add(r.TextNavn(), typeof(string));
            }
            foreach (TreeNode d in myData.Nodes)
            {
                DataRow row = dt.NewRow();
                foreach (TreeNode c in d.Nodes)
                {
                    if (c.Tag!=null && ((tagBag)c.Tag).DataIndhold != null)
                    {
                        row[c.TextNavn()] = ((tagBag)c.Tag).DataIndhold.ToString();
                    }
                }
                dt.Rows.Add(row);
            }

            dgView.DataSource = dt;
            
        }
    }
}
