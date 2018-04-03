using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LoginForm
{
    public partial class Form2 : Form
    {
        SQLite sql;
        string permissions;
        public string a { get; set; }
        public Form2()
        {
            InitializeComponent();
            sql = new SQLite();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) permissions = "Guest";
            else if (radioButton2.Checked == true) permissions = "User";
            if (permissions == "Guest" || permissions == "User")
            {
                MessageBox.Show(sql.Add_SQLite(textBox1.Text, textBox2.Text, permissions), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql.Close_SQLite();
                a = "";
                Close();
            }
        }
    }
}
