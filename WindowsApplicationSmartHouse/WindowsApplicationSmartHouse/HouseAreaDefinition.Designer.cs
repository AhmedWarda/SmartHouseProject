namespace WindowsApplicationSmartHouse
{
    partial class HouseAreaDefinition
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
            this.dataGridViewHouseArea = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this._colAreaAlreadyInDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colAreaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colAreaStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnDevicesAssignment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouseArea)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHouseArea
            // 
            this.dataGridViewHouseArea.AllowUserToAddRows = false;
            this.dataGridViewHouseArea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewHouseArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHouseArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colAreaAlreadyInDB,
            this._colAreaID,
            this._colAreaName,
            this._colAreaStatus});
            this.dataGridViewHouseArea.Location = new System.Drawing.Point(36, 46);
            this.dataGridViewHouseArea.Name = "dataGridViewHouseArea";
            this.dataGridViewHouseArea.Size = new System.Drawing.Size(382, 162);
            this.dataGridViewHouseArea.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(36, 12);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(36, 214);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(123, 214);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(208, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _colAreaAlreadyInDB
            // 
            this._colAreaAlreadyInDB.HeaderText = "Area Already in DB";
            this._colAreaAlreadyInDB.Name = "_colAreaAlreadyInDB";
            this._colAreaAlreadyInDB.Visible = false;
            this._colAreaAlreadyInDB.Width = 122;
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
            // _colAreaStatus
            // 
            this._colAreaStatus.HeaderText = "Enabled";
            this._colAreaStatus.Items.AddRange(new object[] {
            "True",
            "False"});
            this._colAreaStatus.Name = "_colAreaStatus";
            this._colAreaStatus.Width = 51;
            // 
            // btnDevicesAssignment
            // 
            this.btnDevicesAssignment.Location = new System.Drawing.Point(299, 214);
            this.btnDevicesAssignment.Name = "btnDevicesAssignment";
            this.btnDevicesAssignment.Size = new System.Drawing.Size(119, 23);
            this.btnDevicesAssignment.TabIndex = 5;
            this.btnDevicesAssignment.Text = "Devices Assignment";
            this.btnDevicesAssignment.UseVisualStyleBackColor = true;
            this.btnDevicesAssignment.Click += new System.EventHandler(this.btnDevicesAssignment_Click);
            // 
            // HouseAreaDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 266);
            this.Controls.Add(this.btnDevicesAssignment);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dataGridViewHouseArea);
            this.Name = "HouseAreaDefinition";
            this.Text = "House Area Definition";
            this.Load += new System.EventHandler(this.HouseAreaDefinition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouseArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHouseArea;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAreaAlreadyInDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAreaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAreaName;
        private System.Windows.Forms.DataGridViewComboBoxColumn _colAreaStatus;
        private System.Windows.Forms.Button btnDevicesAssignment;
    }
}