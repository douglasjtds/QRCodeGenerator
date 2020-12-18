using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrCodeGenerator
{
    public partial class Form1 : Form
    {
        public Bitmap generatedImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (textBoxURL.Text == string.Empty)
            {
                MessageBox.Show("Invalid info. Complete all info to generate QRCode...");
                textBoxURL.Focus();
                return;
            }
            else if (textBoxHeight.Text == string.Empty || textBoxWidth.Text == string.Empty)
            {
                var defaultValue = "500";
                textBoxHeight.Text = defaultValue;
                textBoxWidth.Text = defaultValue;
            }
            try
            {
                int largura = Convert.ToInt32(textBoxHeight.Text);
                int altura = Convert.ToInt32(textBoxWidth.Text);
                picQrCode.Image = GenerateQRCode(largura, altura, textBoxURL.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Bitmap GenerateQRCode(int width, int height, string text)
        {
            try
            {
                var bw = new ZXing.BarcodeWriter();
                var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
                bw.Options = encOptions;
                bw.Format = ZXing.BarcodeFormat.QR_CODE;
                generatedImage = new Bitmap(bw.Write(text));
                return generatedImage;
            }
            catch
            {
                throw;
            }
        }

        private void buttonDownloadJPG_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "JPG(*.JPG)|*.jpg";

            if (saveFile.ShowDialog() == DialogResult.OK)
                generatedImage.Save(saveFile.FileName);
        }
    }
}
