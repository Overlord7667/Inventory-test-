using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form1 : Form
    {
        List<PictureBox> cells;
        List<Label> lables;
        List<int> count, images;
        int Aple ;
        public Form1()
        {
            InitializeComponent();
            cells = new List<PictureBox>()
            {
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9,
                pictureBox10
            };

            lables = new List<Label>()
            {
                label1,label2,label3,label4,label5,label6,label7,label8,label9
            };
            count = new List<int>
            {
                0,0,0,0,0,0,0,0,0
            };
            images = new List<int>
            {
                0,0,0,0,0,0,0,0,0
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(PictureBox pictureBox in cells)
            {
                pictureBox.AllowDrop = true;
                pictureBox.DragEnter += pictureBox2_DragEnter;
                pictureBox.DragDrop += pictureBox2_DragDrop;
                pictureBox.MouseClick += pictureBox2_MouseClick;
                pictureBox.MouseDown += pictureBox_MouseDown;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            Image image = pictureBox1.Image;
            if(image == null)
            {
                MessageBox.Show("Картинка отсутствует");
                return;
            }
            DoDragDrop(image, DragDropEffects.Move);
            Aple = 1;
        }
        private void pictureBox11_MouseDown(object sender, MouseEventArgs e)
        {
            Image image = pictureBox11.Image;
            if (image == null)
            {
                MessageBox.Show("Картинка отсутствует");
                return;
            }
            DoDragDrop(image, DragDropEffects.Move);
            Aple = 2;
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                PictureBox pb = (PictureBox)sender;
                int i = cells.FindIndex((p) => pb == p);
                Image image = pictureBox1.Image;
                if(count[i]>0)
                {
                    if (image == null)
                    {
                        MessageBox.Show("Картинка отсутствует");
                        return;
                    }
                    DoDragDrop(image, DragDropEffects.Move);
                    count[i]--;
                    lables[i].Text = count[i].ToString();
                    if (count[i] == 0)
                        pb.Image = Properties.Resources._1;
                }
            }
        }

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int x = cells.FindIndex((p) => pb == p);
            Bitmap bitmap = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            if (count[x] == 0 || images[x] == Aple || images[x]==0)
            {
                images[x] = Aple;
                pb.Image = bitmap;
                int i = cells.FindIndex((p)=>pb==p);
                count[i]++;
                lables[i].Text = count[i].ToString();
            }

        }

        private void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox pb = (PictureBox)sender;
                int i = cells.FindIndex((p) => pb == p);
                count[i]--;
                if (count[i] <= 0)
                {
                    count[i] = 0;
                    pb.Image = Properties.Resources._1;
                }
                lables[i].Text = count[i].ToString();
            }
        }

    }
}
