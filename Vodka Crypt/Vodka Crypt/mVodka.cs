using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Vodka_Crypt
{
    public partial class mVodka : Form
    {
        public mVodka()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Welcome to Vodka Crypt!");
            this.txtKey.Text = Helper.GenKey(32);
            txtKeyName.Enabled = false;
            cbFileName.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtKey.Text = Helper.GenKey(32);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var open = new OpenFileDialog())
            {
                open.Title = "Select file";
                open.Filter = ".exe|*.exe";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = open.FileName;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://xakfor.net/forum/");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtKeyName.Enabled = checkBox1.Checked;
            cbFileName.Enabled = checkBox1.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var save = new SaveFileDialog())
            {
                save.Title = "Save File";
                save.Filter = ".exe|*.exe";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        listBox1.Items.Add("Start encrypting file...");
                        Helper.PreCompiler(txtName.Text, txtKey.Text, save.FileName, "", txtKeyName.Text, cbFileName.SelectedItem.ToString(), checkBox1.Checked);
                        listBox1.Items.Add("File crypted!");
                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Add("Error occurred, please try again!");
                        listBox1.Items.Add(ex.Message);
                    }
                }
            }
        }
    }
}
