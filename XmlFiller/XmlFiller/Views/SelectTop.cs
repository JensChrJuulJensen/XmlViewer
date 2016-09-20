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
    public partial class SelectTop : Form
    {
        public SelectTop()
        {
            InitializeComponent();
        }

        public void VisListe(List<String> oversigt)
        {
            topkandidater.Items.Clear();
            foreach (var x in oversigt)
            {
                topkandidater.Items.Add(x);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal string ValgtKandidat()
        {
            return topkandidater.SelectedItem.ToString();
        }
    }
}
