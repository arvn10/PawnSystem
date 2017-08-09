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
namespace PawnSystem.UI.Backend.Forms
{
    public partial class formUserTypeProcess : Form
    {
        private UserTypeService service;

        public UserTypeModel model;

        public UserModel activeUser;

        public formUserTypeProcess()
        {
            InitializeComponent();
        }

        private void formUserTypeProcess_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " [" + this.Text + "]";
            if (this.Text == "Edit")
            {
                textUserType.Text = model.Type;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            service = new UserTypeService();
            if (textUserType.Text == string.Empty)
                MessageBox.Show("Fill up required fields", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else

            if (this.Text == "New")
            {
                if(textUserType.Text != string.Empty)
                {
                    if (service.Get().Where(x => x.Type == textUserType.Text).FirstOrDefault() == null)
                    {
                        model = new UserTypeModel();
                        model.Type = textUserType.Text;
                        model.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;
                        model.CreatedDate = DateTime.Now;
                        if (service.Create(model) != null)
                        {
                            MessageBox.Show("User Type Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Dispose();

                            formUserType form = (formUserType)Application.OpenForms["formUserType"];
                            form.loadData();

                        }
                    }
                    else
                    {
                        MessageBox.Show("User Type Exist", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Fill up required field(s).", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                string messagebox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (messagebox == "Yes")
                {
                    model.Type = textUserType.Text;
                    model.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;
                    if (service.Update(model) != null)
                    {
                        MessageBox.Show("User Type Updated", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Dispose();

                        formUserType form = (formUserType)Application.OpenForms["formUserType"];
                        form.loadData();
                    }
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
