using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pragma.sqlite
{
    public partial class Form1 : Form
    {
        public string database = "database.db";
        Pragma p = new Pragma();

        public Form1()
        {
            InitializeComponent();

            p.ConnectTo(database);
        }

        private void Decorate()
        {
            Decorator d = new Decorator();
            d.Decorate(this);
            d.Decorate(this.comboBox1);
            d.Decorate(this.menuStrip1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Decorate();
            this.Reload();
        }

        private void Reload()
        {
            List<ComboItemDTO> tables = p.get_tables();

            this.comboBox1.DataSource = tables;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Value";
            //this.comboBox1.SelectedIndex = 0;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private string selected_value()
        {
            //ComboBox c = (ComboBox)comboBox1 as ComboBox;
            //string tablename = ((ComboItemDTO)c.Items[c.SelectedIndex]).Value;
            string tablename = "unknown";
            
            if(comboBox1.Items.Count>0)
            {
                tablename = ((ComboItemDTO)comboBox1.Items[comboBox1.SelectedIndex]).Value;
            }

            return tablename;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tablename = this.selected_value();

            string info = p.create(tablename);

            this.textBox1.Text = info;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".\\";
                openFileDialog.Filter = "SQLite Database Files|*.db;*.sqlite";
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
            this.Reload();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string version = p.version();
            MessageBox.Show(version);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tablename = this.selected_value();
            textBox1.Text = p.insert(tablename);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tablename = this.selected_value();
            textBox1.Text = p.delete(tablename);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tablename = this.selected_value();
            textBox1.Text = p.flag(tablename);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tablename = this.selected_value();
            textBox1.Text = p.update(tablename);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tablename = this.selected_value();
            textBox1.Text = p.purge(tablename);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string tablename = this.selected_value();
            textBox1.Text = p.create(tablename);
        }
    }
}
