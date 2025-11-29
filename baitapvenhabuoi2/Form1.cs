using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace baitapvenhabuoi2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            InitializeListView();

        }



        private void InitializeListView()
        {
            listViewStudents.Enabled = true;

            listViewStudents.View = View.Details;
            listViewStudents.GridLines = true;
            listViewStudents.FullRowSelect = true;
            listViewStudents.MultiSelect = false;

            listViewStudents.Columns.Clear();

            listViewStudents.Columns.Add("Last Name", 120);
            listViewStudents.Columns.Add("First Name", 120);
            listViewStudents.Columns.Add("Phone", 100);


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listViewStudents.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListViewItem newItem = new ListViewItem(txtLastName.Text.Trim());
            newItem.SubItems.Add(txtFirstName.Text.Trim());
            newItem.SubItems.Add(txtPhone.Text.Trim());

            listViewStudents.Items.Add(newItem);

            ClearTextboxes();
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewStudents.SelectedItems[0];

                txtLastName.Text = selectedItem.SubItems[0].Text;
                txtFirstName.Text = selectedItem.SubItems[1].Text;
                txtPhone.Text = selectedItem.SubItems[2].Text;
            }
        }

        private void ClearTextboxes()
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtPhone.Text = "";
        }


        private void listViewStudents_DoubleClick(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewStudents.SelectedItems[0];

                txtLastName.Text = item.SubItems[0].Text;
                txtFirstName.Text = item.SubItems[1].Text;
                txtPhone.Text = item.SubItems[2].Text;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc muốn thoát không?",
        "Thông báo",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Thoát chương trình?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form
            }
        }
    }
}
