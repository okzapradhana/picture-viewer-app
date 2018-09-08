using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureApp
{
    public partial class Form_1079_1 : Form
    {
       
        Image gbrAsli;


        public Form_1079_1()
        {
            InitializeComponent();
            pictureBox_1079_1.MouseWheel += PictureBox_1079_1_MouseWheel;
            panel_1079_1.MouseWheel += Panel_1079_1_MouseWheel;
        }

        private void Panel_1079_1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                toolStripButton_1079_2_Click(sender, e);
            } else
            {
                toolStripButton_1079_3_Click(sender, e);
            }
        }

        private void PictureBox_1079_1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                toolStripButton_1079_2_Click(sender, e);
            }
            else
            {
                toolStripButton_1079_3_Click(sender, e);
            }
        }

        private void openToolStripButton_1079_Click(object sender, EventArgs e)
        {
            openFileDialog_1079_1.Filter = "Image Files (*.jpg, *.png) | *.jpg; *.png";
            if(openFileDialog_1079_1.ShowDialog() == DialogResult.OK)
            {
                pictureBox_1079_1.Image = Image.FromFile(openFileDialog_1079_1.FileName);
                gbrAsli = pictureBox_1079_1.Image;
            }
        }


        private void toolStripButton_1079_2_Click(object sender, EventArgs e)
        {
            pictureBox_1079_1.Height = pictureBox_1079_1.Height + 50;
            pictureBox_1079_1.Width = pictureBox_1079_1.Width + 50;
        }

        private void toolStripButton_1079_3_Click(object sender, EventArgs e)
        {
            pictureBox_1079_1.Height = pictureBox_1079_1.Height - 50;
            pictureBox_1079_1.Width = pictureBox_1079_1.Width - 50;
        }

        private void toolStripButton_1079_4_Click(object sender, EventArgs e)
        {
            Image flipImage = pictureBox_1079_1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            

            /*rotate the image*/
            pictureBox_1079_1.Image = flipImage;
            
        }

        private void toolStripButton_1079_5_Click(object sender, EventArgs e)
        {
            Image flipImage = pictureBox_1079_1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            

            pictureBox_1079_1.Image = flipImage;
            
        }

        private void Form_1079_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)43)
            {
                toolStripButton_1079_2_Click(sender, e);
            } else if(e.KeyChar == (char)45)
            {
                toolStripButton_1079_3_Click(sender, e);
            }
        }

        private void panel_1079_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_1079_1_Click(object sender, EventArgs e)
        {

        }

        private void Form_1079_1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right & e.Control)
            {
                toolStripButton_1079_4_Click(sender, e);
            } else if(e.KeyCode == Keys.Left & e.Control)
            {
                toolStripButton_1079_5_Click(sender, e);
            }
        }

        private void saveToolStripMenuItem_1079_Click(object sender, EventArgs e)
        {
            saveFileDialog_1079_1.Filter = "Image Files (*.jpg, *.png) | *.jpg; *.png";
            
            
                if (saveFileDialog_1079_1.ShowDialog() == DialogResult.OK)
                {
                    if (System.Drawing.Imaging.ImageFormat.Jpeg.Equals(gbrAsli.RawFormat))
                    {
                        pictureBox_1079_1.Image.Save(saveFileDialog_1079_1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        
                    }
                    else if (System.Drawing.Imaging.ImageFormat.Png.Equals(gbrAsli.RawFormat))
                    {
                        pictureBox_1079_1.Image.Save(saveFileDialog_1079_1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    MessageBox.Show(saveFileDialog_1079_1.FileName + " was saved succesfully");


            }


        }

        private void printToolStripButton_1079_Click(object sender, EventArgs e)
        {
            
            if(printDialog_1079_1.ShowDialog() == DialogResult.OK)
            {
                printDocument_1079_1.Print();
            }
        }

        private void saveToolStripButton_1079_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_1079_Click(sender, e);
        }

        private void printDocument_1079_1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox_1079_1.Image, e.MarginBounds);
        }
    }
}
