using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawnSystem.BLL.Model;
using PawnSystem.BLL.Service;
using PawnSystem.UI.Backend.Methods;
namespace PawnSystem.UI.Backend.Forms
{
    public partial class formUserProcess : Form
    {
        private UserService service;
        private UserModel model;
        private Helper helper;
        public UserModel activeUser;
        public int userID;
        public string processType;
        public formUserProcess()
        {
            InitializeComponent();
            helper = new Helper();
        }

        private void formUserProcess_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " [" + processType + "]";
            if(processType == "Edit")
            {
                service = new UserService();
                model = new UserModel();
                model = service.Get().AsQueryable<UserModel>().Where(x => x.ID == userID).FirstOrDefault();
                textFirstname.Text = model.FirstName;
                textLastname.Text = model.LastName;
                textUsername.Text = model.UserName;
                textPassword.Text = model.Password;
                textRePassword.Text = model.Password;
                comboStatus.Text = model.Status;
            }
            else
            {
                comboStatus.Text = "--Select Account Status--";
            }
        }

        private void comboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboUserType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool invalidInputs = false;

            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        invalidInputs = true;
                    }
                }
            }
            foreach (Control control in groupBox2.Controls)
            {
                if (control is TextBox)
                {
                    if (control is ComboBox)
                    {
                        ComboBox comboBox = control as ComboBox;
                        if (comboBox.Text == string.Empty || comboBox.Text == "--Select Account Status--" || comboBox.Text == "--Select User Type--")
                        {
                            invalidInputs = true;
                        }
                    }
                }
            }

            if (!invalidInputs)
            {
                if (textPassword.Text != textRePassword.Text)
                {
                    MessageBox.Show("Passwords are not match", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    service = new UserService();
                    model = new UserModel();

                    if (processType == "New")
                    {
                        
                        if (service.Get().AsQueryable<UserModel>().Where(x => x.UserName == textUsername.Text).FirstOrDefault() != null)
                        {
                            MessageBox.Show("Username already exist", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            model.FirstName = textFirstname.Text;
                            model.LastName = textLastname.Text;
                            model.UserName = textUsername.Text;
                            model.Password = textPassword.Text;
                            model.UserTypeID = 1;
                            model.Status = comboStatus.Text;
                            model.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;

                            if (service.Create(model) != null)
                            {
                                MessageBox.Show("Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                                formUser form = (formUser)Application.OpenForms["formUser"];
                                form.loadData();
                            }
                        }
                    }
                    else
                    {
                        model = new UserModel();
                        model.ID = userID;
                        model.FirstName = textFirstname.Text;
                        model.LastName = textLastname.Text;
                        model.UserName = textUsername.Text;
                        model.Password = textPassword.Text;
                        model.UserTypeID = 1;
                        model.Status = comboStatus.Text;
                        model.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;
                        model.ModifiedDate = DateTime.Now;

                        string messageBox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        if (messageBox == "Yes")
                        {
                            if(service.Update(model) != null)
                            {
                                MessageBox.Show("Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                                formUser form = (formUser)Application.OpenForms["formUser"];
                                form.loadData(textFirstname.Text);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Fillup required field(s)", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textFirstname_Leave(object sender, EventArgs e)
        {
            textFirstname.Text = helper.toProperCase(textFirstname.Text);
        }

        private void textLastname_Leave(object sender, EventArgs e)
        {
            textLastname.Text = helper.toProperCase(textLastname.Text);
        }
    }
}
