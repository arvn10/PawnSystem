using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawnSystem.UI.Backend.Forms
{
    public partial class formCamera : Form
    {
        public Methods.Camera camera;
        public formCamera()
        {
            InitializeComponent();
            camera = new Methods.Camera();
        }

        private void formCamera_Load(object sender, EventArgs e)
        {
            
            camera.pictureBox = pictureCamera;
            camera.StartCamera();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            this.Close();
            formClientProcess form = (formClientProcess)Application.OpenForms["formClientProcess"];
            form.pictureClient.Image = (Image)pictureCamera.Image.Clone() as Image;
            form.pictureClient.Tag = "Client Picture";
        }

        private void formCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.pictureBox = pictureCamera;
            camera.ExitCamera();
        }
    }
}
