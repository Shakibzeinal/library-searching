using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Flogin : Form
    {
        public Flogin()
        {
            InitializeComponent();
        }

        private void Flogin_Load(object sender, EventArgs e)
        {
            lpass2.Visible = PublicClass.DtUser.Rows.Count == 0;
            txtpass2.Visible = PublicClass.DtUser.Rows.Count == 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PublicClass.DtUser.Rows.Count == 0)//insert new user
            {
                if (txtpass.Text.Trim().Length < 4 || txtpass2.Text.Trim().Length < 4)
                {
                    errorProvider1.SetError(txtpass, "طول کلمه عبور کمتر از 4 حرف قابل قبول نیست");
                    return;
                }
                if (txtpass.Text.Equals(txtpass2.Text))
                {
                    DataRow arow = PublicClass.DtUser.NewRow();
                    arow["FLname"] = "";
                    arow["UName"] = txtUname.Text ;
                    arow["Pass"] = txtpass.Text ;
                    PublicClass.DtUser.Rows.Add(arow);

                    PublicClass.CurentUserName = txtUname.Text;
                    this.Hide();
                }
                else
                {
                    errorProvider1.SetError(txtpass, "عدم یکسان بودن کلمه عبور و تکرارآن");
                    return;
                }

            }
            else //check login user
            {
                int index = -1;
                for (int i = 0;index==-1 && i <PublicClass.DtUser.Rows.Count; i++)
                {
                    if (PublicClass.DtUser.Rows[i]["UName"].ToString().Equals(txtUname.Text) &&
                        PublicClass.DtUser.Rows[i]["Pass"].ToString().Equals(txtpass.Text))
                    {
                        index = i; 
                    }
                }
                if (index == -1)
                    MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است", "اخطار", MessageBoxButtons.OK);
                else
                {
                    PublicClass.CurentUserName = txtUname.Text;
                    this.Hide();
                }

            
            }
        }
    }
}
