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
    public partial class Nhân_viên : Form
    {
        public delegate void SendData(string msnv, string ten, double luong);
        public SendData sendDataCallback;

        bool isEdit = false;

        public Nhân_viên(bool edit, string msnv = "", string ten = "", double luong = 0)
        {
            InitializeComponent();
            isEdit = edit;

            if (isEdit)
            {
                txtMSNV.Text = msnv;
                txtTenNV.Text = ten;
                txtLuongCB.Text = luong.ToString();
                txtMSNV.Enabled = false; // Không cho sửa mã nhân viên
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string msnv = txtMSNV.Text;
            string ten = txtTenNV.Text;
            double luong = double.Parse(txtLuongCB.Text);

            sendDataCallback?.Invoke(msnv, ten, luong);

            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
