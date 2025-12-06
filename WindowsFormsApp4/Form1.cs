using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null; // theo dõi file đã lưu hay chưa

        public Form1()
        {
            InitializeComponent();
        }

        // Khi form load: cài đặt font, size, mặc định
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load fonts hệ thống
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cmbFonts.Items.Add(font.Name);
            }
            cmbFonts.SelectedItem = "Tahoma";

            // Load size 8 → 72 (theo danh sách đề bài)
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
            {
                cmbSizes.Items.Add(size);
            }
            cmbSizes.SelectedItem = 14;

            // Áp dụng mặc định
            richTextBox1.Font = new Font("Tahoma", 14);
            UpdateWordCount();
        }

        // === HỆ THỐNG: Tạo văn bản mới ===
        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e) => NewDocument();
        private void btnNew_Click(object sender, EventArgs e) => NewDocument();

        private void NewDocument()
        {
            richTextBox1.Clear();
            cmbFonts.SelectedItem = "Tahoma";
            cmbSizes.SelectedItem = 14;
            richTextBox1.Font = new Font("Tahoma", 14);
            currentFilePath = null;
            UpdateWordCount();
        }

        // === HỆ THỐNG: Mở tập tin ===
        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e) => OpenFile();
        private void btnOpen_Click(object sender, EventArgs e) => OpenFile();

        private void OpenFile()
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openDlg.FileName).ToLower();
                if (ext == ".rtf")
                    richTextBox1.LoadFile(openDlg.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.LoadFile(openDlg.FileName, RichTextBoxStreamType.PlainText);
                currentFilePath = openDlg.FileName;
                UpdateWordCount();
            }
        }

        // === HỆ THỐNG: Lưu tập tin ===
        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e) => SaveFile();
        private void btnSave_Click(object sender, EventArgs e) => SaveFile();

        private void SaveFile()
        {
            if (currentFilePath == null)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Rich Text Format (*.rtf)|*.rtf";
                saveDlg.DefaultExt = "rtf";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveDlg.FileName;
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // === ĐỊNH DẠNG: Font... ===
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.SelectionFont = fontDlg.Font;
                richTextBox1.SelectionColor = fontDlg.Color;
            }
        }

        // === Xử lý nút định dạng: Bold, Italic, Underline ===
        private void btnBold_Click(object sender, EventArgs e) => ToggleFontStyle(FontStyle.Bold);
        private void btnItalic_Click(object sender, EventArgs e) => ToggleFontStyle(FontStyle.Italic);
        private void btnUnderline_Click(object sender, EventArgs e) => ToggleFontStyle(FontStyle.Underline);

        private void ToggleFontStyle(FontStyle style)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle current = richTextBox1.SelectionFont.Style;
                FontStyle newStyle = current ^ style; // XOR: bật/tắt
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, newStyle);
            }
        }

        // === Khi chọn Font hoặc Size từ ComboBox ===
        private void cmbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null && cmbFonts.SelectedItem != null)
            {
                string fontName = cmbFonts.SelectedItem.ToString();
                float size = richTextBox1.SelectionFont.Size;
                FontStyle style = richTextBox1.SelectionFont.Style;
                richTextBox1.SelectionFont = new Font(fontName, size, style);
            }
        }

        private void cmbSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null && cmbSizes.SelectedItem != null)
            {
                string fontName = richTextBox1.SelectionFont.FontFamily.Name;
                float size = float.Parse(cmbSizes.SelectedItem.ToString());
                FontStyle style = richTextBox1.SelectionFont.Style;
                richTextBox1.SelectionFont = new Font(fontName, size, style);
            }
        }

        // === Cập nhật số từ trên thanh trạng thái ===
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateWordCount();
        }

        private void UpdateWordCount()
        {
            string text = richTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(text))
                lblWordCount.Text = "Số từ: 0";
            else
            {
                int wordCount = text.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                lblWordCount.Text = $"Số từ: {wordCount}";
            }
        }
    }
}
