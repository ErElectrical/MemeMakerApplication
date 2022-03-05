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
            //initialise the top text label in picture box with whatever we write in top text box.
            lbltoptext.Text = texttoptextbox.Text;

        }
        /// <summary>
        /// Method that is responsible for bottom text of image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changebottomtext(object sender, EventArgs e)
        {
            //initialise the bottom text label in picture box with whatever we write in bottom text box.
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
            //create a object of openfiledialog class 
            //it is a class that is available in system.drawing.imgaging namespace
            openImageFile = new OpenFileDialog();
            //set up the initial folder where we search for images 
            openImageFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            // filter specific file of provided extension
            // after | we provided extension that is for backend purpose 
            // only  things that are available before | is visible to end user in file dialog box
            openImageFile.Filter = "Image Files Only (*.jpg,*.gif,*.png,*.bmp) | *.jpg;*.gif;*.png;*.bmp";

            //check if user click enter in filedialog box
            if(openImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //linking picturebox(imgpreview) with the image that is selected by end user
                    imgpreview.Image = Image.FromFile(openImageFile.FileName);
                }
                catch(Exception ex)
                {
                    //if some error occur instead of crashing application give information to end user in a message box
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
            //creating an object of savefiledialog class 
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.FileName = "Meme from Maker"; // provide default filename
            savedialog.DefaultExt = "jpg"; // provide default extension type
            savedialog.Filter = "Jpg Image | *.jpg"; 

            savedialog.ValidateNames = true; // bound the user for using unappropriate name to our file
             //check weather user press enter to savedailog box
            if(savedialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(imgpreview.Width);
                int height = Convert.ToInt32(imgpreview.Height);
                //bitmap is a class that helps to create a graphics picture by giving pixel data to it
                Bitmap bmp = new Bitmap(width, height);
                //draw image by bitmap from picturebox imgpreview
                imgpreview.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                //save the image based on provided filename and extension
                bmp.Save(savedialog.FileName, ImageFormat.Jpeg);
                

            }
        }
        /// <summary>
        /// Method is responsible to deal situations when user wants to change text color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changetextcolor(object sender, EventArgs e)
        {
            //create a instance of button class and initialise it with sender button
            Button tempbutton = sender as Button;
            //make the forecolor same as tempbutton class forecolour
            lbltoptext.ForeColor = tempbutton.ForeColor;
            lblbottomtext.ForeColor = tempbutton.ForeColor;
        }

        private void MemeMaker_Load(object sender, EventArgs e)
        {

        }
    }
}
