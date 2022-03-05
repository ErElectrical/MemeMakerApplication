using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging; // this one is for deal with jpg image file

namespace MemeMakerApp
{
   
    public partial class MemeMaker : Form
    {

        OpenFileDialog openImageFile;
        public MemeMaker()
        {
            InitializeComponent();
            SetUpApp();
        }

        /// <summary>
        /// Method set both top and bottom text as a child of picture box
        /// </summary>
        private void SetUpApp()
        {
            //Adding both lbl text to the controls of picture box
            imgpreview.Controls.Add(lbltoptext);
            imgpreview.Controls.Add(lblbottomtext);
            //setting up the location of both lbl text
            lbltoptext.Location = new Point(0, 0);
            lblbottomtext.Location = new Point(0,12);

            //send it to back so that lbl text rises above the image
            imgpreview.SendToBack();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method that will responsible for top text of image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changetoptext(object sender, EventArgs e)
        {
            lbltoptext.Text = texttoptextbox.Text;

        }
        /// <summary>
        /// Method that is responsible for bottom text of image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changebottomtext(object sender, EventArgs e)
        {
            lblbottomtext.Text = txtbottomtxtbox.Text;
        }
        /// <summary>
        /// Method is resposible to deal what happens when user click on open button
        /// in window form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openimage(object sender, EventArgs e)
        {
            openImageFile = new OpenFileDialog();
            openImageFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openImageFile.Filter = "Image Files Only (*.jpg,*.gif,*.png,*.bmp) | *.jpg;*.gif;*.png;*.bmp";

            if(openImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imgpreview.Image = Image.FromFile(openImageFile.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error!, could not loud the file " + ex.Message);
                }
            }

        }
        /// <summary>
        /// Method that is responsible to deal what happens when user entered on 
        /// save button in window form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveimage(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Method is responsible to deal situations when user wants to change text color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changetextcolor(object sender, EventArgs e)
        {
            Button tempbutton = sender as Button;
            lbltoptext.ForeColor = tempbutton.ForeColor;
            lblbottomtext.ForeColor = tempbutton.ForeColor;
        }

        private void MemeMaker_Load(object sender, EventArgs e)
        {

        }
    }
}
