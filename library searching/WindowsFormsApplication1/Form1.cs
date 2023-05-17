using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        DataTable dtBook = new DataTable("Book");
        string FileName = @"C:\Users\ALI\Desktop\MyLibrary.xml";
        public Form1()
        {
            InitializeComponent();

            dtBook.Columns.Add("Name", typeof(string));
            dtBook.Columns.Add("Year", typeof(int));
            dtBook.Columns.Add("Writer", typeof(string));
            dtBook.Columns.Add("NumberCount", typeof(int));

            bindingSource1.DataSource = dtBook;

            dataGridView1.DataSource = bindingSource1;

            txtName.DataBindings.Add("Text", bindingSource1, "Name");
            txtYear.DataBindings.Add("Text", bindingSource1, "Year");
            txtWriter.DataBindings.Add("Text", bindingSource1, "Writer");
            txtNumber.DataBindings.Add("Text", bindingSource1, "NumberCount");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(FileName))
                dtBook.ReadXml(FileName);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow arow = dtBook.NewRow();
            arow["Name"] = "";
            arow["Year"] = 0;
            arow["Writer"] = "";
            arow["NumberCount"] = 0;
            dtBook.Rows.Add(arow);
            bindingSource1.MoveLast();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtBook.GetChanges() != null)
                dtBook.AcceptChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
              if (bindingSource1.Count > 0 &&
                MessageBox.Show("آیا مطمئن هستید میخواهید حذف کنید؟","Warning!",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
              {
                  dtBook.Rows.RemoveAt(bindingSource1.Position);
              }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
