using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Book
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                phoneBookBindingSource.Filter = $"Email like '*{txtSearch.Text}*' or TK = '{txtSearch.Text}' or LastName = '{txtSearch.Text}' or Phone = '{txtSearch.Text}'";
        }
         private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists($"{Application.StartupPath}/data.dat"))
                dataSet1.ReadXml($"{Application.StartupPath}/data.dat");
        }
        private void phoneBookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            phoneBookBindingSource.EndEdit();
            dataSet1.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Data Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void stateLabel_Click(object sender, EventArgs e)
        {

        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tKTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a right value");
            }
        }

        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char phn = e.KeyChar;
            if (!Char.IsDigit(phn) && phn != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid Phone Number");
            }
        }

 

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (emailTextBox.Text.Length > 0)

            {

                if (!rEMail.IsMatch(emailTextBox.Text))

                {

                    MessageBox.Show("Please enter a valid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    emailTextBox.SelectAll();

                    e.Cancel = true;
                   

                }

            }
        }

      
    }
}
