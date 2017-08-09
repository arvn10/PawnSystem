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
    public partial class formTicketTypeProcess : Form
    {
        public UserModel activeUser;
        private TicketTypeService service;
        private TicketTypeModel model;
        public int ticketTypeID;
        public string processType;

        public formTicketTypeProcess()
        {
            InitializeComponent();
            service = new TicketTypeService();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formTicketTypeProcess_Load(object sender, EventArgs e)
        {
            this.Text = "Ticket Type [" + processType + "]";
            if (processType == "Edit")
            {
                model = new TicketTypeModel();
                service = new TicketTypeService();
                model = service.Get().Where(x => x.ID == ticketTypeID).FirstOrDefault();
                textTicketType.Text = model.Type;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textTicketType.Text != string.Empty)
            {
                service = new TicketTypeService();
                model = new TicketTypeModel();
                model.Type = textTicketType.Text;
                if (processType == "New")
                {
                    model.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;

                    if (service.Create(model) != null)
                    {
                        MessageBox.Show("Ticket Type Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();

                        formTicketType form = (formTicketType)Application.OpenForms["formTicketType"];
                        form.loadData();
                    }
                }
                else
                {
                    string messageBox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString();
                    if (messageBox == "Yes")
                    {
                        model.ID = ticketTypeID;
                        model.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;

                        if (service.Update(model) != null)
                        {
                            MessageBox.Show("Ticket Type Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();

                            formTicketType form = (formTicketType)Application.OpenForms["formTicketType"];
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
    }
}
