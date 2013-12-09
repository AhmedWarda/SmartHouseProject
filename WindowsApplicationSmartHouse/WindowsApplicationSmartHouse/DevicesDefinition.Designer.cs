namespace WindowsApplicationSmartHouse
{
    partial class DevicesDefinition
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
            this.dataGridViewDevices = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this._colDeviceAlreadyinDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceAreaAssign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDevices
            // 
            this.dataGridViewDevices.AllowUserToAddRows = false;
            this.dataGridViewDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colDeviceAlreadyinDB,
            this._colDeviceID,
            this._colDeviceName,
            this._colDeviceAreaAssign,
            this._colDeviceStatus});
            this.dataGridViewDevices.Location = new System.Drawing.Point(32, 36);
            this.dataGridViewDevices.Name = "dataGridViewDevices";
            this.dataGridViewDevices.Size = new System.Drawing.Size(431, 177);
            this.dataGridViewDevices.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(32, 7);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(51, 228);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(109, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(188, 228);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(321, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _colDeviceAlreadyinDB
            // 
            this._colDeviceAlreadyinDB.HeaderText = "Device Already in DB";
            this._colDeviceAlreadyinDB.Name = "_colDeviceAlreadyinDB";
            this._colDeviceAlreadyinDB.Visible = false;
            this._colDeviceAlreadyinDB.Width = 131;
            // 
            // _colDeviceID
            // 
            this._colDeviceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this._colDeviceID.HeaderText = "Device ID";
            this._colDeviceID.Name = "_colDeviceID";
            this._colDeviceID.Width = 78;
            // 
            // _colDeviceName
            // 
            this._colDeviceName.HeaderText = "Device Name";
            this._colDeviceName.Name = "_colDeviceName";
            this._colDeviceName.Width = 94;
            // 
            // _colDeviceAreaAssign
            // 
            this._colDeviceAreaAssign.HeaderText = "Area Assigned";
            this._colDeviceAreaAssign.Name = "_colDeviceAreaAssign";
            this._colDeviceAreaAssign.Visible = false;
            this._colDeviceAreaAssign.Width = 101;
            // 
            // _colDeviceStatus
            // 
            this._colDeviceStatus.HeaderText = "Enabled";
            this._colDeviceStatus.Items.AddRange(new object[] {
            "True",
            "False"});
            this._colDeviceStatus.Name = "_colDeviceStatus";
            this._colDeviceStatus.Width = 51;
            // 
            // DevicesDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 304);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dataGridViewDevices);
            this.Name = "DevicesDefinition";
            this.Text = "Devices Definition";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDevices;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceAlreadyinDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceAreaAssign;
        private System.Windows.Forms.DataGridViewComboBoxColumn _colDeviceStatus;
    }
}