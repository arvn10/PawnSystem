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
using PawnSystem.Helper;
namespace PawnSystem.UI.Backend.Forms
{
    public partial class formItemTypeProcess : Form
    {
        private ItemTypeModel model;
        private ItemTypeService service;
        public UserModel activeUser;
        public int itemTypeID;
        public string processType;
        public formItemTypeProcess()
        {
            InitializeComponent();
        }
       

        private void formItemTypeProcess_Load(object sender, EventArgs e)
        {
            this.Text = "Item Type [" + processType + "]";
            if (processType == "Edit")
            {
                model = new ItemTypeModel();
                service = new ItemTypeService();
                model = service.Get().Where(x => x.ID == itemTypeID).FirstOrDefault();
                textItemName.Text = model.Description;
                textInterest.Text = Convert.ToString(model.Interest);
                textPenalty.Text = Convert.ToString(model.Penalty);
                textAppraiseValue.Text = Convert.ToString(model.AppraiseValue);
                comboWithSC.Text = Convert.ToString(model.WithServiceCharge);
                textDaysToMature.Text = Convert.ToString(model.DaysToMature);
                textDaysToExpire.Text = Convert.ToString(model.DaysToExpire);
                textDaysToPenalty.Text = Convert.ToString(model.DaysToPenalty);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;

            foreach(Control control in this.Controls)
            {
                if(control is TextBox || control is ComboBox)
                {
                    if(control.Text == string.Empty)
                    {
                        isValid = false;
                    }
                }
            }

            if (isValid)
            {
                model = new ItemTypeModel();
                service = new ItemTypeService();
                if(processType == "New")
                {
                    model.Description = textItemName.Text;
                    model.Interest = Convert.ToInt32(textInterest.Text);
                    model.Penalty = Convert.ToInt32(textPenalty.Text);
                    model.AppraiseValue = Convert.ToInt32(textAppraiseValue.Text);
                    model.WithServiceCharge = comboWithSC.Text;
                    model.DaysToMature = Convert.ToInt32(textDaysToMature.Text);
                    model.DaysToExpire = Convert.ToInt32(textDaysToExpire.Text);
                    model.DaysToPenalty = Convert.ToInt32(textDaysToPenalty.Text);

                    if (service.Create(model) != null)
                    {
                        MessageBox.Show("Item Type Saved", "Pawnshop Managemnet System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        formItemType form = (formItemType)Application.OpenForms["formItemType"];
                        form.loadData();
                    }
                    
                }
                else
                {
                    string messageBox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if(messageBox == "Yes")
                    {
                        model.ID = itemTypeID;
                        model.Description = textItemName.Text;
                        model.Interest = Convert.ToInt32(textInterest.Text);
                        model.Penalty = Convert.ToInt32(textPenalty.Text);
                        model.AppraiseValue = Convert.ToInt32(textAppraiseValue.Text);
                        model.WithServiceCharge = comboWithSC.Text;
                        model.DaysToMature = Convert.ToInt32(textDaysToMature.Text);
                        model.DaysToExpire = Convert.ToInt32(textDaysToExpire.Text);
                        model.DaysToPenalty = Convert.ToInt32(textDaysToPenalty.Text);

                        if (service.Update(model) != null)
                        {
                            MessageBox.Show("Item Type Saved", "Pawnshop Managemnet System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                            formItemType form = (formItemType)Application.OpenForms["formItemType"];
                            form.loadData();
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Fillup all Required Fields", "Pawnshop Managemnet System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textInterest_TextChanged(object sender, EventArgs e)
        {

        }

        private void textInterest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboWithSC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textPenalty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textDaysToMature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textDaysToPenalty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textDaysToExpire_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textAppraiseValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textItemName_Leave(object sender, EventArgs e)
        {
            textItemName.Text = HelperClass.toProperCase(textItemName.Text);
        }
    }
}
