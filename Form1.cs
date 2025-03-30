namespace lab4_wizualne
{
    public partial class Form1 : Form
    {
        private Image image;
        private bool IsOnlyGreen = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki BMP (*.bmp)|*.bmp|Wszystkie pliki (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Załaduj obrazek przed dokonaniem zmiany.");
                return;
            }

            if (!IsOnlyGreen)
            {
                pictureBox1.Image = ChangeNonGreenToBlack(image);
                IsOnlyGreen = true;
            }
            else
            {
                pictureBox1.Image = image;
                IsOnlyGreen = false;
            }
        }

        private Image ChangeNonGreenToBlack(Image image)
        {
            Bitmap bmp = new Bitmap(image); 

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    if (!(pixelColor.G > pixelColor.R && pixelColor.G > pixelColor.B))
                    {
                        bmp.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return bmp;
        }
    }
}
