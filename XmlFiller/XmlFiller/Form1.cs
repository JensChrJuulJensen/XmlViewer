using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using XmlFiller.Views;
using System.Xml.Serialization;
using System.IO;

namespace XmlFiller
{
    public partial class Form1 : Form
    {
        Assembly assembly = null;
        string topKandidat = "";
        Type topType = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadDllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dllLokation = new OpenFileDialog() { DefaultExt = ".dll" };
            dllLokation.Filter = "DLL fil (.dll)|*.dll";
            dllLokation.ShowDialog();
            if (dllLokation.FileName != null && !string.IsNullOrEmpty(dllLokation.FileName))
            {
                assembly = Assembly.LoadFrom(dllLokation.FileName);
                SelectTop vælg = new SelectTop();
                vælg.VisListe(assembly.GetModules()[0].GetTypes().OrderBy(p => p.FullName).Select(p => p.FullName).ToList<string>());
                vælg.ShowDialog();
                topKandidat = vælg.ValgtKandidat();

                var data = DataTree.Nodes.Add("Data");
                topType = assembly.GetModules()[0].GetType(topKandidat);
                fillTræet(data, topType);

            }
        }

        private void fillTræet(TreeNode data, Type valgtType, int index=0)
        {
            if (!valgtType.IsClass) return;
            if (valgtType.FullName == "System.String") return;
            if (valgtType.IsArray)
            {
                var underliggendeType = valgtType.GetElementType();
                TreeNode nyNode = data.AddNode(underliggendeType, index);
                fillTræet(nyNode, underliggendeType);
                return;
            }

            var toptype = valgtType;
            foreach (var m in toptype.GetProperties())
            {
                TreeNode nyNode= data.AddNode(m);
                fillTræet(nyNode, m.PropertyType);
            }
        }

        private void DataTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (DataTree.SelectedNode != null && DataTree.SelectedNode.Tag != null && DataTree.SelectedNode.Tag is tagBag)
            {
                var t = ((tagBag)DataTree.SelectedNode.Tag).FeltType;
                var propertyType = Nullable.GetUnderlyingType(t) ?? t;
                lblDatatype.Text = propertyType.Name;
                lblDatatype.Tag = propertyType;
                lblName.Text = DataTree.SelectedNode.Name;
            }


            if (DataTree.SelectedNode != null && DataTree.SelectedNode.Tag != null && DataTree.SelectedNode.Tag is tagBag && ((tagBag)DataTree.SelectedNode.Tag).DataIndhold != null)
            {
                indtastningData.Text = ((tagBag)DataTree.SelectedNode.Tag).DataIndhold.ToString();
                indtastningData.Enabled = true;
            }
            else
            {
                indtastningData.Text = "";
                if (DataTree.SelectedNode.Nodes.Count > 0)
                {
                    indtastningData.Enabled = false;
                }
                else
                {
                    indtastningData.Enabled = true;
                }
            }

        }

        private void DataTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (DataTree.SelectedNode != null && DataTree.SelectedNode.Tag is tagBag)
            {
                DataTree.SelectedNode.IndholdSet(indtastningData.Text);
            }
        }

        private void contextMenuTreeNode_Opening(object sender, CancelEventArgs e)
        {
            if (DataTree.SelectedNode != null && (DataTree.SelectedNode.Nodes.Count == 0 || !DataTree.SelectedNode.ErArray()))
            {
                e.Cancel = true;
            }
        }

        private void Opret_Click(object sender, EventArgs e)
        {
            var t = ((tagBag)DataTree.SelectedNode.Tag).FeltType;
            fillTræet(DataTree.SelectedNode, t, DataTree.SelectedNode.Nodes.Count);
        }

        private void indtastningData_TextChanged(object sender, EventArgs e)
        {
            var t = ((tagBag)DataTree.SelectedNode.Tag).FeltType;
            try
            {
                if ((Nullable.GetUnderlyingType(t) ?? t).GetMethod("Parse", new Type[1] { typeof(System.String) }) != null)
                {
                    var resultat = (Nullable.GetUnderlyingType(t) ?? t).InvokeMember("Parse", BindingFlags.InvokeMethod, null,
                                                        t,
                                                        new object[1] { indtastningData.Text });
                }

                lblStatus.Text = "OK";
            }
            catch
            {
                lblStatus.Text = "(fejl)";
            }
        }

        private void gemXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = assembly.CreateInstance(topType.FullName);

            var topNode = DataTree.Nodes[0];
            KopierTilData(data, topNode);
            XmlSerializer serializer = new XmlSerializer(data.GetType());
            var sb = new StringBuilder();
            var skriver = new StringWriter(sb);
            serializer.Serialize(skriver, data);
            var x = sb.ToString();

            var sf = new SaveFileDialog();
            sf.Filter = "XML fil (.xml)|*.xml";
            sf.ShowDialog();

            if (!string.IsNullOrWhiteSpace(sf.FileName))
            {
                File.WriteAllText(sf.FileName, x);
            }

        }

        private void KopierTilData(object data, TreeNode topNode)
        {
            if (data == null) return;
            if (topNode == null) return;
            if (topNode.ErNill()) return;

            foreach (TreeNode n in topNode.Nodes)
            {
                if (n.ErNill()) continue;

                if (n.Tag != null && ((tagBag)n.Tag).FeltType.IsArray)
                {
                    var x = Array.CreateInstance(((tagBag)n.Tag).FeltType.GetElementType(), n.Nodes.Count);
                    data.GetType().GetProperty(((tagBag)(n.Tag)).FeltType.GetElementType().Name).SetValue(data, x, null);
                    int i = 0;
                    foreach (TreeNode arraynode in n.Nodes)
                    {
                        ((object[])x)[i] = assembly.CreateInstance(((tagBag)n.Tag).FeltType.GetElementType().FullName);
                        KopierTilData(((object[])x)[i], arraynode);
                        i++;
                    }
                }
                else
                {
                    foreach (var p in data.GetType().GetProperties())
                    {
                        if (n.Tag!=null && p.Name == ((tagBag)(n.Tag)).Navn)
                        {
                            data.GetType().GetProperty(p.Name).SetValue(data, assembly.CreateInstance(p.PropertyType.Name), null);
                            var v = data.GetType().GetProperty(p.Name).GetValue(data, null);
                            var t = data.GetType().GetProperty(p.Name).PropertyType;
                            if (n.Tag != null && ((tagBag)n.Tag).DataIndhold != null && !string.IsNullOrEmpty(((tagBag)n.Tag).DataIndhold.ToString()))
                            {
                                object indhold = ((tagBag)n.Tag).DataIndhold;

                                if ((Nullable.GetUnderlyingType(t) ?? t).GetMethod("Parse", new Type[1] { typeof(System.String) }) != null)
                                {
                                    if (indhold.GetType().Name.ToLower() == "string")
                                    {
                                        var resultat = (Nullable.GetUnderlyingType(t) ?? t).InvokeMember("Parse", BindingFlags.InvokeMethod, null,
                                                                            t,
                                                                            new object[1] { indhold });
                                        indhold = resultat;
                                    }
                                }

                                data.GetType().GetProperty(p.Name).SetValue(data, indhold, null);

                            }
                            KopierTilData(v, n);
                        }
                    }
                }
            }
        }

        private void hentXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "XML fil (.xml)|*.xml";
            openDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(openDialog.FileName))
            {
                var filData = File.ReadAllText(openDialog.FileName);
                var data = assembly.CreateInstance(topType.FullName);
                XmlSerializer serializer = new XmlSerializer(data.GetType());
                data = serializer.Deserialize(new StringReader(filData));

                opdaterData(data, "");
                displayData(DataTree.TopNode);
            }


        }

        private void displayData(TreeNode DataTree)
        {
            foreach (TreeNode t in DataTree.Nodes)
            {
                if (t.Nodes.Count > 0)
                {
                    displayData(t);
                }
                else
                {
                    if (t.Tag != null)
                    {
                        var d = t.Tag as tagBag;
                        if (d.DataIndhold != null)
                        {
                            t.Text += ": " + d.DataIndhold.ToString();
                        }
                    }
                }
            }
        }

        private void opdaterData(object data, string top)
        {

            // returnerer hvis der ikke er data
            if (data == null) return;

            // hvis det er en tekst eller ikke er en klasse, så skal et felt opdateres
            if (data.GetType().Name == "String" || !data.GetType().IsClass)
            {
                TreeNode nuvNode = DataTree.Nodes.Find(top,true).FirstOrDefault();
                ((tagBag)nuvNode.Tag).DataIndhold = data;
                return;
            }

            // array
            if (data.GetType().IsArray)
            {
                //top += " *";
                TreeNode nuvNode = DataTree.Nodes.Find(top, true).FirstOrDefault();

                int antalForekomster = Math.Max(0, ((object[])data).Length - nuvNode.Nodes.Count);
                int tllr = nuvNode.Nodes.Count;
                for (int i = 0; i < antalForekomster; i++)
                {
                    var t = ((tagBag)nuvNode.Tag).FeltType;
                    fillTræet(nuvNode, t,tllr++);
                }

                for (int i = 0; i < ((object[])data).Length; i++)
                {
                    opdaterData(
                                    ((object[])data)[i],
                                    top+"/"+nuvNode.FirstNode.Text+"["+i.ToString()+"]");
                }
                return;
            }


            // videre i træet
            foreach (var p in data.GetType().GetProperties())
            {
                string nyTop = top + "/" + p.Name;
                opdaterData(p.GetValue(data, null), nyTop);
            }
        }


        private void visSomTabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataTree.SelectedNode == null) return;
            var visning = new Views.VisSomTabel(DataTree.SelectedNode);
            visning.Show();
        }

    }
}
