using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestXML
{
    public partial class Form1 : Form
    {
        private XDocument xdoc;

        public Form1()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------- XML LOGICS ------------------------------------------------------------
        public void LoadXmlFile()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                Title = "Выберите XML-файл"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                xdoc = XDocument.Load(dlg.FileName);
                BuildCustomTree();
            }
        }

        // +Parse
        private void BuildCustomTree()
        {
            treeView1.Nodes.Clear();

            // Parcels
            TreeNode parcelsNode = new TreeNode("Parcels");
            var parcels = xdoc.Descendants("land_record");
            foreach (var parcel in parcels)
            {
                string cad = parcel.Descendants("cad_number").FirstOrDefault()?.Value;
                if (!string.IsNullOrEmpty(cad))
                {
                    TreeNode cadNode = new TreeNode(cad);
                    cadNode.Tag = parcel; // сохраним XML
                    parcelsNode.Nodes.Add(cadNode);
                }
            }
            treeView1.Nodes.Add(parcelsNode);

            // ObjectRealty (build_records + construction_record)
            TreeNode realtyNode = new TreeNode("ObjectRealty");
            var realtyRecords = xdoc.Descendants("build_record").Concat(xdoc.Descendants("construction_record"));
            foreach (var obj in realtyRecords)
            {
                string cad = obj.Descendants("cad_number").FirstOrDefault()?.Value;
                if (!string.IsNullOrEmpty(cad))
                {
                    TreeNode cadNode = new TreeNode(cad);
                    cadNode.Tag = obj;
                    realtyNode.Nodes.Add(cadNode);
                }
            }
            treeView1.Nodes.Add(realtyNode);

            // SpatialData
            TreeNode spatialNode = new TreeNode("SpatialData");
            var spatialRecords = xdoc.Descendants("entity_spatial");
            foreach (var entity in spatialRecords)
            {
                string skid = entity.Descendants("sk_id").FirstOrDefault()?.Value;
                if (!string.IsNullOrEmpty(skid))
                {
                    TreeNode skNode = new TreeNode(skid);
                    skNode.Tag = entity;
                    spatialNode.Nodes.Add(skNode);
                }
            }
            treeView1.Nodes.Add(spatialNode);

            // Bounds
            TreeNode boundsNode = new TreeNode("Bounds");
            var boundsRecords = xdoc.Descendants("municipal_boundary_record");
            foreach (var rec in boundsRecords)
            {
                string reg = rec.Descendants("reg_numb_border").FirstOrDefault()?.Value;
                if (!string.IsNullOrEmpty(reg))
                {
                    TreeNode regNode = new TreeNode(reg);
                    regNode.Tag = rec;
                    boundsNode.Nodes.Add(regNode);
                }
            }
            treeView1.Nodes.Add(boundsNode);

            // Zones
            TreeNode zonesNode = new TreeNode("Zones");
            var zoneRecords = xdoc.Descendants("zones_and_territories_record");
            foreach (var rec in zoneRecords)
            {
                string reg = rec.Descendants("reg_numb_border").FirstOrDefault()?.Value;
                if (!string.IsNullOrEmpty(reg))
                {
                    TreeNode regNode = new TreeNode(reg);
                    regNode.Tag = rec;
                    zonesNode.Nodes.Add(regNode);
                }
            }
            treeView1.Nodes.Add(zonesNode);

            treeView1.CollapseAll();
        }

        // Save XML file
        private void SaveCheckedNodesToXml(string fileName)
        {
            XElement root = new XElement("SelectedNodes");

            void Traverse(TreeNodeCollection nodes, XElement parentXml)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Checked && node.Tag is XElement element)
                    {
                        parentXml.Add(new XElement(element));
                    }

                    if (node.Nodes.Count > 0)
                    {
                        Traverse(node.Nodes, parentXml);
                    }
                }
            }

            Traverse(treeView1.Nodes, root);

            XDocument doc = new XDocument(root);
            doc.Save(fileName);

            MessageBox.Show("Отмеченные элементы сохранены в " + fileName, "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool HasCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked) return true;
                if (node.Nodes.Count > 0 && HasCheckedNodes(node.Nodes))
                    return true;
            }
            return false;
        }



        //--------------------------------------------------------------------------- HELP FORM ------------------------------------------------------------
        private void OpenDownlaodForm()
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        //--------------------------------------------------------------------------- UI/EVENTS ------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            LoadXmlFile();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is XElement element)
            {
                richTextBox1.Text = element.ToString();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenDownlaodForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!HasCheckedNodes(treeView1.Nodes))
            {
                MessageBox.Show("Никаой элемент не был выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                Title = "Сохранить выбранные узлы"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveCheckedNodesToXml(dlg.FileName);
            }
        }
    }
}
