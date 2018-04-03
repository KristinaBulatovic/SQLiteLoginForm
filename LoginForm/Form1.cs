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
    public partial class Form1 : Form
    {
        SQLite sql;
        public Form1()
        {
            InitializeComponent();
            sql = new SQLite();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool t = sql.Read_SQLite(textBox1.Text,textBox2.Text,"login");
            string permissions = sql.Permissions_SQLite(textBox1.Text);
            if (t == true) MessageBox.Show("You are logged in as " + permissions + "!!!" , "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            sql.Close_SQLite();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            textBox1.Text = form2.a;
            textBox2.Text = form2.a;
        }
    }
}
