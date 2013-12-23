namespace WindowsApplicationSmartHouse
{
    partial class AssignmentHouseAreaToDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAreaName = new System.Windows.Forms.Label();
            this.comboBoxAreaName = new System.Windows.Forms.ComboBox();
            this.comboBoxDeviceName = new System.Windows.Forms.ComboBox();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.textBoxAreaID = new System.Windows.Forms.TextBox();
            this.textBoxDeviceID = new System.Windows.Forms.TextBox();
            this.lblDeviceID = new System.Windows.Forms.Label();
            this.dataGridViewAreaDevicesAssign = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this._colAssignedBeforeinDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colAreaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAreaDevicesAssign)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Location = new System.Drawing.Point(21, 26);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(60, 13);
            this.lblAreaName.TabIndex = 0;
            this.lblAreaName.Text = "Area Name";
            // 
            // comboBoxAreaName
            // 
            this.comboBoxAreaName.FormattingEnabled = true;
            this.comboBoxAreaName.Location = new System.Drawing.Point(96, 23);
            this.comboBoxAreaName.Name = "comboBoxAreaName";
            this.comboBoxAreaName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAreaName.TabIndex = 1;
            this.comboBoxAreaName.SelectedIndexChanged += new System.EventHandler(this.comboBoxAreaName_SelectedIndexChanged);
            // 
            // comboBoxDeviceName
            // 
            this.comboBoxDeviceName.FormattingEnabled = true;
            this.comboBoxDeviceName.Location = new System.Drawing.Point(96, 56);
            this.comboBoxDeviceName.Name = "comboBoxDeviceName";
            this.comboBoxDeviceName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDeviceName.TabIndex = 3;
            this.comboBoxDeviceName.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeviceName_SelectedIndexChanged);
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(21, 59);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(69, 13);
            this.lblDeviceName.TabIndex = 2;
            this.lblDeviceName.Text = "Device Name";
            // 
            // lblAreaID
            // 
            this.lblAreaID.AutoSize = true;
            this.lblAreaID.Location = new System.Drawing.Point(269, 26);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(44, 13);
            this.lblAreaID.TabIndex = 4;
            this.lblAreaID.Text = "Area ID";
            // 
            // textBoxAreaID
            // 
            this.textBoxAreaID.Location = new System.Drawing.Point(330, 24);
            this.textBoxAreaID.Name = "textBoxAreaID";
            this.textBoxAreaID.ReadOnly = true;
            this.textBoxAreaID.Size = new System.Drawing.Size(123, 20);
            this.textBoxAreaID.TabIndex = 5;
            // 
            // textBoxDeviceID
            // 
            this.textBoxDeviceID.Location = new System.Drawing.Point(330, 59);
            this.textBoxDeviceID.Name = "textBoxDeviceID";
            this.textBoxDeviceID.ReadOnly = true;
            this.textBoxDeviceID.Size = new System.Drawing.Size(123, 20);
            this.textBoxDeviceID.TabIndex = 7;
            // 
            // lblDeviceID
            // 
            this.lblDeviceID.AutoSize = true;
            this.lblDeviceID.Location = new System.Drawing.Point(269, 61);
            this.lblDeviceID.Name = "lblDeviceID";
            this.lblDeviceID.Size = new System.Drawing.Size(53, 13);
            this.lblDeviceID.TabIndex = 6;
            this.lblDeviceID.Text = "Device ID";
            // 
            // dataGridViewAreaDevicesAssign
            // 
            this.dataGridViewAreaDevicesAssign.AllowUserToAddRows = false;
            this.dataGridViewAreaDevicesAssign.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewAreaDevicesAssign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAreaDevicesAssign.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colAssignedBeforeinDB,
            this._colAreaID,
            this._colAreaName,
            this._colDeviceID,
            this._colDeviceName});
            this.dataGridViewAreaDevicesAssign.Location = new System.Drawing.Point(24, 121);
            this.dataGridViewAreaDevicesAssign.Name = "dataGridViewAreaDevicesAssign";
            this.dataGridViewAreaDevicesAssign.Size = new System.Drawing.Size(507, 185);
            this.dataGridViewAreaDevicesAssign.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(115, 83);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add Device";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(142, 326);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(330, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _colAssignedBeforeinDB
            // 
            this._colAssignedBeforeinDB.HeaderText = "AssignedBeforeinBD";
            this._colAssignedBeforeinDB.Name = "_colAssignedBeforeinDB";
            this._colAssignedBeforeinDB.Visible = false;
            this._colAssignedBeforeinDB.Width = 128;
            // 
            // _colAreaID
            // 
            this._colAreaID.HeaderText = "Area ID";
            this._colAreaID.Name = "_colAreaID";
            this._colAreaID.Width = 69;
            // 
            // _colAreaName
            // 
            this._colAreaName.HeaderText = "Area Name";
            this._colAreaName.Name = "_colAreaName";
            this._colAreaName.Width = 85;
            // 
            // _colDeviceID
            // 
            this._colDeviceID.HeaderText = "DeviceID";
            this._colDeviceID.Name = "_colDeviceID";
            this._colDeviceID.Width = 75;
            // 
            // _colDeviceName
            // 
            this._colDeviceName.HeaderText = "Device Name";
            this._colDeviceName.Name = "_colDeviceName";
            this._colDeviceName.Width = 94;
            // 
            // AssignmentHouseAreaToDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 385);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewAreaDevicesAssign);
            this.Controls.Add(this.textBoxDeviceID);
            this.Controls.Add(this.lblDeviceID);
            this.Controls.Add(this.textBoxAreaID);
            this.Controls.Add(this.lblAreaID);
            this.Controls.Add(this.comboBoxDeviceName);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.comboBoxAreaName);
            this.Controls.Add(this.lblAreaName);
            this.Name = "AssignmentHouseAreaToDevice";
            this.Text = "Assignment House Area To Device";
            this.Load += new System.EventHandler(this.AssignmentHouseAreaToDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAreaDevicesAssign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.ComboBox comboBoxAreaName;
        private System.Windows.Forms.ComboBox comboBoxDeviceName;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.TextBox textBoxAreaID;
        private System.Windows.Forms.TextBox textBoxDeviceID;
        private System.Windows.Forms.Label lblDeviceID;
        private System.Windows.Forms.DataGridView dataGridViewAreaDevicesAssign;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAssignedBeforeinDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAreaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceName;
    }
}