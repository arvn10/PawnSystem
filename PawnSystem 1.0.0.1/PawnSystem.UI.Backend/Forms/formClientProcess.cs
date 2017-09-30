using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using PawnSystem.BLL.Model;
using PawnSystem.BLL.Service;
using PawnSystem.Helper;
namespace PawnSystem.UI.Backend.Forms
{
    public partial class formClientProcess : Form
    {
        private ClientService service;
        private ClientModel model;
        public UserModel activeUser = new UserModel();
        public int clientID;
        public string processType;
        public formClientProcess()
        {
            InitializeComponent();
        }



        private static string RandomString()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Boolean saveImage(string filename, Image image)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Client Images\\" + filename;
            Bitmap dest = new Bitmap(image.Width, image.Height);
            Graphics gfx = Graphics.FromImage(dest);
            gfx.DrawImageUnscaled(image, Point.Empty);
            dest.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            dest.Dispose();
            return true;
        }

        private string toProperCase(string text)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            return textInfo.ToTitleCase(text);
        }

        private Image loadImage(string filename)
        {
            string Path;
            try
            {
                Path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Client Images\\" + filename;
            }
            catch
            {
                Path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Client Images\\Default.png";
            }
            
            return Image.FromFile(Path);
        }

        private void deleteImage(string filename)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Client Images\\" + filename;
            if (File.Exists(path))
            {
                pictureClient.Image = null;

                File.Delete(path);
            }
        }

        private void formClientProcess_Load(object sender, EventArgs e)
        {


            this.Text = "Client [" + processType + "]";

            Methods.Camera camera = new Methods.Camera();

            if (camera.CheckCamera())
            {
                buttonTakePhoto.Enabled = true;
            }

            if (processType == "Edit")
            {
                model = new ClientModel();
                service = new ClientService();
                model = service.Get().Where(x => x.ID == clientID).FirstOrDefault();
                textFirstname.Text = model.FirstName;
                textLastname.Text = model.LastName;
                textAddress.Text = model.Address;
                textContactNumber.Text = model.ContactNumber;
                pictureClient.Tag = model.ImagePath;
                if (model.ImagePath != string.Empty)
                {
                    pictureClient.Tag = model.ImagePath;
                    pictureClient.Image = loadImage(model.ImagePath);
                }
                else
                {
                    pictureClient.Tag = "Default";
                    pictureClient.Image = loadImage("Default.png");
                }

            }
            else if (processType == "New")
            {
                pictureClient.Tag = "Default";
                pictureClient.Image = loadImage("Default.png");
            }


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            foreach (Control control in groupClientInfo.Controls)
            {
                if (control is TextBox && control.Name != "textContactNumber")
                {
                    if (control.Text == string.Empty)
                    {
                        isValid = false;
                    }
                } 
            }

            if (isValid)
            {
                service = new ClientService();
                if (processType == "New")
                {
                    Boolean exist = service.Get()
                                           .Where(x =>
                                                  x.Address.ToUpper().Contains(textAddress.Text.ToUpper()) &&
                                                  x.FirstName.ToUpper() == textFirstname.Text.ToUpper() &&
                                                  x.LastName.ToUpper() == textLastname.Text.ToUpper())
                                           .FirstOrDefault() != null ? true : false;
                    if (!exist)
                    {
                        model = new ClientModel();
                        model.FirstName = textFirstname.Text;
                        model.LastName = textLastname.Text;
                        model.Address = textAddress.Text;
                        model.ContactNumber = textContactNumber.Text;
                        model.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;
                        model.CreatedDate = DateTime.Now;
                        string filename = RandomString() + ".jpg";
                        if (pictureClient.Tag.ToString() != "Default")
                        {
                            if (saveImage(filename, pictureClient.Image))
                            {
                                model.ImagePath = filename;
                            }
                        }
                        else
                        {
                            model.ImagePath = "";
                        }

                        if (service.Create(model) != null)
                        {
                            MessageBox.Show("Client Profile Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                            formClient form = (formClient)Application.OpenForms["formClient"];
                            form.loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Client Already Exist", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (processType == "Edit")
                {
                    string messageBox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();         
                    model = new ClientModel();
                    model.ID = clientID;
                    model.FirstName = textFirstname.Text;
                    model.LastName = textLastname.Text;
                    model.Address = textAddress.Text;
                    model.ContactNumber = textContactNumber.Text;
                    model.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;

                    string filename = RandomString() + ".jpg";
                    string oldFilename = model.ImagePath;
                    if (pictureClient.Tag.ToString() != "Default")
                    {
                        if(pictureClient.Tag.ToString() != model.ImagePath)
                        {
                            if (saveImage(filename, pictureClient.Image))
                            {
                                model.ImagePath = filename;
                                if (oldFilename != "")
                                {
                                    deleteImage(oldFilename);
                                }

                            }
                        }
                    }
                    else
                    {
                        model.ImagePath = "";
                    }

                    if (messageBox == "Yes")
                    {
                        if (service.Update(model) != null)
                        {
                            MessageBox.Show("Client Profile Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                            formClient form = (formClient)Application.OpenForms["formClient"];
                            form.loadData();
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Fill up all required fields.", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textFirstname_Leave(object sender, EventArgs e)
        {
            textFirstname.Text = HelperClass.toProperCase(textFirstname.Text);
        }

        private void textLastname_Leave(object sender, EventArgs e)
        {
            textLastname.Text = HelperClass.toProperCase(textLastname.Text);
        }

        private void textAddress_Leave(object sender, EventArgs e)
        {
            textAddress.Text = HelperClass.toProperCase(textAddress.Text);
        }

        private void textContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void buttonTakePhoto_Click(object sender, EventArgs e)
        {
            formCamera form = new formCamera();
            form.Show();
        }

        private void textAddress_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
