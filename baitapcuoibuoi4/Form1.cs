using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitapcuoibuoi4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormMain_Load);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lvNhanVien.View = View.Details;
            lvNhanVien.GridLines = true;
            lvNhanVien.FullRowSelect = true;

            lvNhanVien.Columns.Add("MSNV", 100);
            lvNhanVien.Columns.Add("Tên nhân viên", 200);
            lvNhanVien.Columns.Add("Lương CB", 120);

            AddNhanVien("NV001", "Nguyễn Văn Trí", 8500000);
            AddNhanVien("NV002", "Trần Thị Hoa", 9000000);
            AddNhanVien("NV003", "Lê Minh Tuyền", 7800000);
        }

        private void AddNhanVien(string msnv, string ten, int luong)
        {
            ListViewItem item = new ListViewItem(msnv);
            item.SubItems.Add(ten);
            item.SubItems.Add(luong.ToString());

            lvNhanVien.Items.Add(item);
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            Nhân_viên f = new Nhân_viên(false); 

            f.sendDataCallback = (msnv, ten, luong) =>
            {
                ListViewItem item = new ListViewItem(msnv);
                item.SubItems.Add(ten);
                item.SubItems.Add(luong.ToString());
                lvNhanVien.Items.Add(item);
            };

            f.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn nhân viên cần sửa.");
                return;
            }

            ListViewItem item = lvNhanVien.SelectedItems[0];

            string msnv = item.SubItems[0].Text;
            string ten = item.SubItems[1].Text;
            double luong = double.Parse(item.SubItems[2].Text);

            Nhân_viên f = new Nhân_viên(true, msnv, ten, luong);

            f.sendDataCallback = (newMSNV, newTen, newLuong) =>
            {
                item.SubItems[1].Text = newTen;
                item.SubItems[2].Text = newLuong.ToString();
            };

            f.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn nhân viên để xóa.");
                return;
            }

            lvNhanVien.Items.Remove(lvNhanVien.SelectedItems[0]);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
