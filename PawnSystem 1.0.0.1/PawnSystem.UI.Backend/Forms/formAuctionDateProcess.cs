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
    public partial class formAuctionDateProcess : Form
    {
        private AuctionDateService service;
        private AuctionDateModel model;
        public UserModel activeUser;
        public int auctionDateID = 0;
        public string processType;

        public formAuctionDateProcess()
        {
            InitializeComponent();
        }

        private void formAuctionDateProcess_Load(object sender, EventArgs e)
        {
            this.Text = "Auction Date [" + processType + "]";
            if(auctionDateID != 0)
            {
                service = new AuctionDateService();
                model = new AuctionDateModel();
                model = service.Get().AsQueryable<AuctionDateModel>().Where(x => x.ID == auctionDateID).FirstOrDefault();
                dateTimeAuctionDate.Text = Convert.ToString(model.Date);
                dateTimeItemFrom.Text = Convert.ToString(model.ItemFrom);
                dateTimeItemTo.Text = Convert.ToString(model.ItemTo);
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (processType == "New")
            {
                service = new AuctionDateService();
                model = new AuctionDateModel();

                model.Date = Convert.ToDateTime(dateTimeAuctionDate.Text);
                model.ItemFrom = Convert.ToDateTime(dateTimeItemFrom.Text);
                model.ItemTo = Convert.ToDateTime(dateTimeItemTo.Text);
                model.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;
                model.CreatedDate = DateTime.Now;

                if (service.Get().AsQueryable<AuctionDateModel>().Where(x => x.Date == dateTimeAuctionDate.Value).FirstOrDefault() == null)
                {
                    if(service.Create(model) != null)
                    {
                        MessageBox.Show("Auction Date Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        formAuctionDate form = (formAuctionDate)Application.OpenForms["formAuctionDate"];
                        form.loadData(null);
                    }
                }
                else
                {
                    MessageBox.Show("Auction Date Exists", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (processType == "Edit")
            {

                string messageBox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if(messageBox == "Yes")
                {
                    service = new AuctionDateService();
                    model = new AuctionDateModel();
                    model.ID = auctionDateID;
                    model.Date = Convert.ToDateTime(dateTimeAuctionDate.Text);
                    model.ItemFrom = Convert.ToDateTime(dateTimeItemFrom.Text);
                    model.ItemTo = Convert.ToDateTime(dateTimeItemTo.Text);
                    model.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;
                    

                    if(service.Update(model) != null)
                    {
                        MessageBox.Show("Auction Date Saved!", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Dispose();
                        formAuctionDate form = (formAuctionDate)Application.OpenForms["formAuctionDate"];
                        form.loadData(null);
                    }
                }
            }
        }
    }
}
