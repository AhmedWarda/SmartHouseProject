namespace WindowsApplicationSmartHouse
{
    partial class DevicesAlarmConfiguration
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
            this.dataGridViewDevicesAlarmConfig = new System.Windows.Forms.DataGridView();
            this._colDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ColDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colAlarmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colConfigType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevicesAlarmConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDevicesAlarmConfig
            // 
            this.dataGridViewDevicesAlarmConfig.AllowUserToAddRows = false;
            this.dataGridViewDevicesAlarmConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevicesAlarmConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colDeviceID,
            this._ColDeviceName,
            this._colAlarmValue,
            this._colConfigType});
            this.dataGridViewDevicesAlarmConfig.Location = new System.Drawing.Point(33, 35);
            this.dataGridViewDevicesAlarmConfig.Name = "dataGridViewDevicesAlarmConfig";
            this.dataGridViewDevicesAlarmConfig.Size = new System.Drawing.Size(476, 199);
            this.dataGridViewDevicesAlarmConfig.TabIndex = 0;
            // 
            // _colDeviceID
            // 
            this._colDeviceID.HeaderText = "Device ID";
            this._colDeviceID.Name = "_colDeviceID";
            // 
            // _ColDeviceName
            // 
            this._ColDeviceName.HeaderText = "Device Name";
            this._ColDeviceName.Name = "_ColDeviceName";
            // 
            // _colAlarmValue
            // 
            this._colAlarmValue.HeaderText = "Alarm Value";
            this._colAlarmValue.Name = "_colAlarmValue";
            // 
            // _colConfigType
            // 
            this._colConfigType.HeaderText = "Condition";
            this._colConfigType.Items.AddRange(new object[] {
            "Over",
            "Less",
            "Equal"});
            this._colConfigType.Name = "_colConfigType";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(33, 6);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(81, 250);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(391, 250);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(237, 250);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // DevicesAlarmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 311);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dataGridViewDevicesAlarmConfig);
            this.Name = "DevicesAlarmConfiguration";
            this.Text = "Devices Alarm Configuration";
            this.Load += new System.EventHandler(this.DevicesAlarmConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevicesAlarmConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDevicesAlarmConfig;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ColDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAlarmValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn _colConfigType;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}