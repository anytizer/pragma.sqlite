using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pragma
{
    public partial class Form1 : Form
    {
        public string database = "database.db";
        pragma p = new pragma();

        public Form1()
        {
            InitializeComponent();

            decorator d = new decorator();
            d.decorate(this);

            p.ConnectTo(database);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            reload();
        }

        public void reload()
        {
            List<ComboItemDTO> tables = p.get_tables();

            this.comboBox1.DataSource = tables;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Value";
            //this.comboBox1.SelectedIndex = 0;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;
            string tablename = ((ComboItemDTO)c.Items[c.SelectedIndex]).Value;

            string info = p.get_info(tablename);

            this.textBox1.Text = info;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".\\";
                openFileDialog.Filter = "SQLite Database Files|*.db";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    this.LoadDB(filePath);
                }
            }
        }

        private void LoadDB(string filePath)
        {
            p.ConnectTo(filePath);
            this.reload();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
