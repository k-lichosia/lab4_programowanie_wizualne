namespace lab4_wizualne
{
    public partial class Form1 : Form
    {
        private Image image;
        private int currentAngle = 0;

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
    }
}
