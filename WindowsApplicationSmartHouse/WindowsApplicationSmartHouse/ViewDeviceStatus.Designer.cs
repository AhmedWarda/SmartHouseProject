namespace WindowsApplicationSmartHouse
{
    partial class ViewDeviceStatus
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
            this._colDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceAssignedToRoomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceAssignedToRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colDeviceStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDevices
            // 
            this.dataGridViewDevices.AllowUserToAddRows = false;
            this.dataGridViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colDeviceID,
            this._colDeviceName,
            this._colDeviceValue,
            this._colDeviceAssignedToRoomID,
            this._colDeviceAssignedToRoomName,
            this._colDeviceStatus});
            this.dataGridViewDevices.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDevices.Name = "dataGridViewDevices";
            this.dataGridViewDevices.Size = new System.Drawing.Size(649, 183);
            this.dataGridViewDevices.TabIndex = 0;
            // 
            // _colDeviceID
            // 
            this._colDeviceID.HeaderText = "Device ID";
            this._colDeviceID.Name = "_colDeviceID";
            // 
            // _colDeviceName
            // 
            this._colDeviceName.HeaderText = "Device Name";
            this._colDeviceName.Name = "_colDeviceName";
            // 
            // _colDeviceValue
            // 
            this._colDeviceValue.HeaderText = "Current Value";
            this._colDeviceValue.Name = "_colDeviceValue";
            // 
            // _colDeviceAssignedToRoomID
            // 
            this._colDeviceAssignedToRoomID.HeaderText = "Device Room ID";
            this._colDeviceAssignedToRoomID.Name = "_colDeviceAssignedToRoomID";
            // 
            // _colDeviceAssignedToRoomName
            // 
            this._colDeviceAssignedToRoomName.HeaderText = "Device Room Name";
            this._colDeviceAssignedToRoomName.Name = "_colDeviceAssignedToRoomName";
            // 
            // _colDeviceStatus
            // 
            this._colDeviceStatus.HeaderText = "Device Enable";
            this._colDeviceStatus.Items.AddRange(new object[] {
            "True",
            "False"});
            this._colDeviceStatus.Name = "_colDeviceStatus";
            this._colDeviceStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._colDeviceStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(423, 201);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Show/Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(137, 201);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(108, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ViewDeviceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 260);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridViewDevices);
            this.Name = "ViewDeviceStatus";
            this.Text = "Device Status";
            this.Load += new System.EventHandler(this.ViewDeviceStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDevices;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceAssignedToRoomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceAssignedToRoomName;
        private System.Windows.Forms.DataGridViewComboBoxColumn _colDeviceStatus;
        private System.Windows.Forms.Button btnUpdate;
    }
}