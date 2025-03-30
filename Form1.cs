namespace lab4_wizualne
{
    public partial class Form1 : Form
    {
        private Image image;
        private int currentAngle = 0;
        private bool ColorsInverted = false;
        private bool Rotated = false;

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
                MessageBox.Show("Załaduj obrazek przed obrotem.");
                return;
            }

            int angle = 0;

            if (radioButton1.Checked)
                angle = 90;
            else if (radioButton2.Checked)
                angle = 180;
            else if (radioButton3.Checked)
                angle = 270;

            currentAngle = (currentAngle + angle) % 360;

            pictureBox1.Image = RotateImage(image, currentAngle);
        }

        private Image RotateImage(Image image, float angle)
        {
            Bitmap bmp = new Bitmap(image);

            switch (angle)
            {
                case 90:
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 180:
                    bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 270:
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                default:
                    break;
            }

            return bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Załaduj obrazek przed inwersją.");
                return;
            }

            if (!ColorsInverted)
            {
                pictureBox1.Image = InvertColors(image);
                ColorsInverted = true;
            }
            else
            {
                pictureBox1.Image = image;
                ColorsInverted = false;
            }
            currentAngle = 0;
        }

        private Image InvertColors(Image image)
        {
            Bitmap bmp = new Bitmap(image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    int invertedRed = 255 - pixelColor.R;
                    int invertedGreen = 255 - pixelColor.G;
                    int invertedBlue = 255 - pixelColor.B;

                    bmp.SetPixel(x, y, Color.FromArgb(invertedRed, invertedGreen, invertedBlue));
                }
            }

            return bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Załaduj obrazek przed obrotem.");
                return;
            }

            if (!Rotated)
            {
                pictureBox1.Image = RotateImage(image, 180);
                currentAngle = 180;
                Rotated = true;
            }
            else {
                pictureBox1.Image = image;
                currentAngle = 0;
                Rotated = false;
            }
        }
    }
}
