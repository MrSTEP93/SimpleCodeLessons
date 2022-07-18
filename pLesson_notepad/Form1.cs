using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pLesson_notepad
{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void ShowSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }
    public partial class Form1 : Form, IMainForm
    {

        public Form1()
        {
            InitializeComponent();
            BtnOpenDialog.Click += BtnOpenDialog_Click;
            BtnOpenFile.Click += BtnOpenFile_Click;
            btnSaveFile.Click += BtnSaveFile_Click;
            tbContent.TextChanged += TbContent_TextChanged;
            numFontSize.ValueChanged += NumFontSize_ValueChanged;
        }

        #region Код формы
        private void BtnOpenDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Текстовые файлы|*.txt|Все файлы|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = dlg.FileName;
                FileOpenClick?.Invoke(this, EventArgs.Empty);
                EnableElements();
            }
        }
        private void EnableElements()
        {
            tbContent.Enabled = true;
            numFontSize.Enabled = true;
            btnSaveFile.Enabled = true;
        }
        private void NumFontSize_ValueChanged(object sender, EventArgs e)
        {
            tbContent.Font = new Font("Calibri", (float)numFontSize.Value);
        }
        #endregion

        #region проброс событий
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            //if (FileOpenClick != null) FileOpenClick(this, new EventArgs());
            FileOpenClick?.Invoke(this, EventArgs.Empty);
            EnableElements();
        }

        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            FileSaveClick?.Invoke(this, EventArgs.Empty);
        }
        private void TbContent_TextChanged(object sender, EventArgs e)
        {
            ContentChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region MainForm
        public string FilePath
        {
            get { return txtFilePath.Text; }
        }

        public string Content 
        { 
            get { return tbContent.Text; } 
            set { tbContent.Text = value; } 
        }
        public void ShowSymbolCount(int count)
        {
            lblSymConut.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
        #endregion

    }
}
