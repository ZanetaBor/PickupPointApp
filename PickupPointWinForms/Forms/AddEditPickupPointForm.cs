using System;
using System.Windows.Forms;
using PickupPointWinForms.Models;

namespace PickupPointWinForms
{
    public partial class AddEditPickupPointForm : Form
    {
        private TextBox txtAddress;
        private TextBox txtOpeningHours;
        private TextBox txtContactNumber;
        private Label lblPickupFormsTitle;
        private Label lblAddNamePickerPoint;
        private Label lblAddAddressPickerPoint;
        private Label lblAddHoursPickerPoint;
        private Label lblAddContactNumberPickerPoint;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtName;

        public PickupPointClient PickupPoint { get; private set; }
        public string PickupPointName { get; private set; }
        public string Address { get; private set; }
        public string OpeningHours { get; private set; }
        public string ContactNumber { get; private set; }

        public AddEditPickupPointForm(string title = "Add/Edit Pickup Point", PickupPointClient pickupPoint = null)
        {
            InitializeComponent();
            this.Text = title;

            PickupPoint = pickupPoint;

            if (pickupPoint != null)
            {
                txtName.Text = pickupPoint.Name;
                txtAddress.Text = pickupPoint.Address;
                txtOpeningHours.Text = pickupPoint.OpeningHours;
                txtContactNumber.Text = pickupPoint.ContactNumber;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PickupPointName = txtName.Text.Trim();
            Address = txtAddress.Text.Trim();
            OpeningHours = txtOpeningHours.Text.Trim();
            ContactNumber = txtContactNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(PickupPointName) ||
                string.IsNullOrWhiteSpace(Address) ||
                string.IsNullOrWhiteSpace(OpeningHours) ||
                string.IsNullOrWhiteSpace(ContactNumber))
            {
                MessageBox.Show("Wszystkie pola są wymagane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PickupPoint == null)
            {
                PickupPoint = new PickupPointClient
                {
                    Name = PickupPointName,
                    Address = Address,
                    OpeningHours = OpeningHours,
                    ContactNumber = ContactNumber
                };
            }
            else
            {
                PickupPoint.Name = PickupPointName;
                PickupPoint.Address = Address;
                PickupPoint.OpeningHours = OpeningHours;
                PickupPoint.ContactNumber = ContactNumber;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtOpeningHours = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.lblPickupFormsTitle = new System.Windows.Forms.Label();
            this.lblAddNamePickerPoint = new System.Windows.Forms.Label();
            this.lblAddAddressPickerPoint = new System.Windows.Forms.Label();
            this.lblAddHoursPickerPoint = new System.Windows.Forms.Label();
            this.lblAddContactNumberPickerPoint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtName.Location = new System.Drawing.Point(300, 100);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 34);
            this.txtName.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtAddress.Location = new System.Drawing.Point(300, 164);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 34);
            this.txtAddress.TabIndex = 1;
            // 
            // txtOpeningHours
            // 
            this.txtOpeningHours.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtOpeningHours.Location = new System.Drawing.Point(300, 224);
            this.txtOpeningHours.Name = "txtOpeningHours";
            this.txtOpeningHours.Size = new System.Drawing.Size(250, 34);
            this.txtOpeningHours.TabIndex = 2;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtContactNumber.Location = new System.Drawing.Point(300, 284);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(250, 34);
            this.txtContactNumber.TabIndex = 3;
            this.txtContactNumber.TabStop = false;
            // 
            // lblPickupFormsTitle
            // 
            this.lblPickupFormsTitle.AutoSize = true;
            this.lblPickupFormsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPickupFormsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16.8F, System.Drawing.FontStyle.Bold);
            this.lblPickupFormsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.lblPickupFormsTitle.Location = new System.Drawing.Point(123, 25);
            this.lblPickupFormsTitle.Name = "lblPickupFormsTitle";
            this.lblPickupFormsTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblPickupFormsTitle.Size = new System.Drawing.Size(297, 48);
            this.lblPickupFormsTitle.TabIndex = 4;
            this.lblPickupFormsTitle.Text = "Add new Picker Point";
            this.lblPickupFormsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddNamePickerPoint
            // 
            this.lblAddNamePickerPoint.AllowDrop = true;
            this.lblAddNamePickerPoint.AutoSize = true;
            this.lblAddNamePickerPoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAddNamePickerPoint.ForeColor = System.Drawing.Color.Black;
            this.lblAddNamePickerPoint.Location = new System.Drawing.Point(100, 100);
            this.lblAddNamePickerPoint.Name = "lblAddNamePickerPoint";
            this.lblAddNamePickerPoint.Padding = new System.Windows.Forms.Padding(5);
            this.lblAddNamePickerPoint.Size = new System.Drawing.Size(74, 38);
            this.lblAddNamePickerPoint.TabIndex = 5;
            this.lblAddNamePickerPoint.Text = "Name";
            this.lblAddNamePickerPoint.UseMnemonic = false;
            // 
            // lblAddAddressPickerPoint
            // 
            this.lblAddAddressPickerPoint.AllowDrop = true;
            this.lblAddAddressPickerPoint.AutoSize = true;
            this.lblAddAddressPickerPoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAddAddressPickerPoint.ForeColor = System.Drawing.Color.Black;
            this.lblAddAddressPickerPoint.Location = new System.Drawing.Point(77, 164);
            this.lblAddAddressPickerPoint.Name = "lblAddAddressPickerPoint";
            this.lblAddAddressPickerPoint.Padding = new System.Windows.Forms.Padding(5);
            this.lblAddAddressPickerPoint.Size = new System.Drawing.Size(97, 38);
            this.lblAddAddressPickerPoint.TabIndex = 6;
            this.lblAddAddressPickerPoint.Text = "Address ";
            // 
            // lblAddHoursPickerPoint
            // 
            this.lblAddHoursPickerPoint.AllowDrop = true;
            this.lblAddHoursPickerPoint.AutoSize = true;
            this.lblAddHoursPickerPoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAddHoursPickerPoint.ForeColor = System.Drawing.Color.Black;
            this.lblAddHoursPickerPoint.Location = new System.Drawing.Point(17, 224);
            this.lblAddHoursPickerPoint.Name = "lblAddHoursPickerPoint";
            this.lblAddHoursPickerPoint.Padding = new System.Windows.Forms.Padding(5);
            this.lblAddHoursPickerPoint.Size = new System.Drawing.Size(157, 38);
            this.lblAddHoursPickerPoint.TabIndex = 7;
            this.lblAddHoursPickerPoint.Text = "Opening hours ";
            // 
            // lblAddContactNumberPickerPoint
            // 
            this.lblAddContactNumberPickerPoint.AllowDrop = true;
            this.lblAddContactNumberPickerPoint.AutoSize = true;
            this.lblAddContactNumberPickerPoint.Cursor = System.Windows.Forms.Cursors.No;
            this.lblAddContactNumberPickerPoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAddContactNumberPickerPoint.ForeColor = System.Drawing.Color.Black;
            this.lblAddContactNumberPickerPoint.Location = new System.Drawing.Point(8, 284);
            this.lblAddContactNumberPickerPoint.Name = "lblAddContactNumberPickerPoint";
            this.lblAddContactNumberPickerPoint.Padding = new System.Windows.Forms.Padding(5);
            this.lblAddContactNumberPickerPoint.Size = new System.Drawing.Size(168, 38);
            this.lblAddContactNumberPickerPoint.TabIndex = 8;
            this.lblAddContactNumberPickerPoint.Text = "Contact number ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(430, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(120, 50);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(300, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEditPickupPointForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(564, 413);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAddContactNumberPickerPoint);
            this.Controls.Add(this.lblAddHoursPickerPoint);
            this.Controls.Add(this.lblAddAddressPickerPoint);
            this.Controls.Add(this.lblAddNamePickerPoint);
            this.Controls.Add(this.lblPickupFormsTitle);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.txtOpeningHours);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Name = "AddEditPickupPointForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
