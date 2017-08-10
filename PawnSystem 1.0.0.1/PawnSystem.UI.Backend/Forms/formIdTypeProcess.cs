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
    public partial class formIdTypeProcess : Form
    {
        private IdTypeService service;

        private IdTypeModel model;
        public int idTypeID;
        public UserModel activeUser;
        public string processType;

        public formIdTypeProcess()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formIdTypeProcess_Load(object sender, EventArgs e)
        {
            this.Text = "ID Type [" + processType + "]";
            if (processType == "Edit")
            {
                model = new IdTypeModel();
                service = new IdTypeService();
                model = service.Get().Where(x => x.ID == idTypeID).FirstOrDefault();
                textIdType.Text = model.Type;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textIdType.Text != string.Empty)
            {
                if (processType == "New")
                {

                    service = new IdTypeService();
                    model = new IdTypeModel();
                    model.Type = textIdType.Text;
                    model.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;
                    model.CreatedDate = DateTime.Now;

                    if (service.Create(model) != null)
                    {
                        MessageBox.Show("ID Type Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();

                        formIdType form = (formIdType)Application.OpenForms["formIdType"];
                        form.loadData();
                    }
                }
                else
                {
                    string messageBox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString();
                    if(messageBox == "Yes")
                    {
                        service = new IdTypeService();
                        model = new IdTypeModel();
                        model.ID = idTypeID;
                        model.Type = textIdType.Text;
                        model.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;
                        model.ModifiedDate = DateTime.Now;

                        if (service.Update(model) != null)
                        {
                            MessageBox.Show("ID Type Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();

                            formIdType form = (formIdType)Application.OpenForms["formIdType"];
                            form.loadData();
                        }
                    }
                }
            }
            else
                {
                MessageBox.Show("Fill up required field(s)", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textIdType_Leave(object sender, EventArgs e)
        {
            textIdType.Text = Helper.toProperCase(textIdType.Text);
        }
    }
}
