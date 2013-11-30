namespace WindowsApplicationSmartHouse
{
    partial class AddDevicesAlarmConfiguration
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
            this.btnSave = new System.Windows.Forms.Button();
            this.ComboxDeviceName = new System.Windows.Forms.ComboBox();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblDeviceID = new System.Windows.Forms.Label();
            this.txtBoxDeviceID = new System.Windows.Forms.TextBox();
            this.txtBoxAlarmValue = new System.Windows.Forms.TextBox();
            this.lblAlarmValue = new System.Windows.Forms.Label();
            this.lblCondition = new System.Windows.Forms.Label();
            this.ComboBoxCondition = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(304, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ComboxDeviceName
            // 
            this.ComboxDeviceName.FormattingEnabled = true;
            this.ComboxDeviceName.Location = new System.Drawing.Point(116, 30);
            this.ComboxDeviceName.Name = "ComboxDeviceName";
            this.ComboxDeviceName.Size = new System.Drawing.Size(121, 21);
            this.ComboxDeviceName.TabIndex = 1;
            this.ComboxDeviceName.SelectedIndexChanged += new System.EventHandler(this.ComboxDeviceName_SelectedIndexChanged);
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(23, 33);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(69, 13);
            this.lblDeviceName.TabIndex = 2;
            this.lblDeviceName.Text = "Device Name";
            // 
            // lblDeviceID
            // 
            this.lblDeviceID.AutoSize = true;
            this.lblDeviceID.Location = new System.Drawing.Point(23, 73);
            this.lblDeviceID.Name = "lblDeviceID";
            this.lblDeviceID.Size = new System.Drawing.Size(53, 13);
            this.lblDeviceID.TabIndex = 3;
            this.lblDeviceID.Text = "Device ID";
            // 
            // txtBoxDeviceID
            // 
            this.txtBoxDeviceID.Location = new System.Drawing.Point(116, 73);
            this.txtBoxDeviceID.Name = "txtBoxDeviceID";
            this.txtBoxDeviceID.ReadOnly = true;
            this.txtBoxDeviceID.Size = new System.Drawing.Size(121, 20);
            this.txtBoxDeviceID.TabIndex = 4;
            // 
            // txtBoxAlarmValue
            // 
            this.txtBoxAlarmValue.Location = new System.Drawing.Point(116, 118);
            this.txtBoxAlarmValue.Name = "txtBoxAlarmValue";
            this.txtBoxAlarmValue.Size = new System.Drawing.Size(121, 20);
            this.txtBoxAlarmValue.TabIndex = 6;
            // 
            // lblAlarmValue
            // 
            this.lblAlarmValue.AutoSize = true;
            this.lblAlarmValue.Location = new System.Drawing.Point(23, 118);
            this.lblAlarmValue.Name = "lblAlarmValue";
            this.lblAlarmValue.Size = new System.Drawing.Size(63, 13);
            this.lblAlarmValue.TabIndex = 5;
            this.lblAlarmValue.Text = "Alarm Value";
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(23, 164);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(52, 13);
            this.lblCondition.TabIndex = 8;
            this.lblCondition.Text = "Condition";
            // 
            // ComboBoxCondition
            // 
            this.ComboBoxCondition.FormattingEnabled = true;
            this.ComboBoxCondition.Items.AddRange(new object[] {
            "Over",
            "Less",
            "Equal"});
            this.ComboBoxCondition.Location = new System.Drawing.Point(116, 161);
            this.ComboBoxCondition.Name = "ComboBoxCondition";
            this.ComboBoxCondition.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxCondition.TabIndex = 7;
            // 
            // AddDevicesAlarmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 261);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.ComboBoxCondition);
            this.Controls.Add(this.txtBoxAlarmValue);
            this.Controls.Add(this.lblAlarmValue);
            this.Controls.Add(this.txtBoxDeviceID);
            this.Controls.Add(this.lblDeviceID);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.ComboxDeviceName);
            this.Controls.Add(this.btnSave);
            this.Name = "AddDevicesAlarmConfiguration";
            this.Text = "New Devices Alarm Configuration";
            this.Load += new System.EventHandler(this.AddDevicesAlarmConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ComboxDeviceName;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblDeviceID;
        private System.Windows.Forms.TextBox txtBoxDeviceID;
        private System.Windows.Forms.TextBox txtBoxAlarmValue;
        private System.Windows.Forms.Label lblAlarmValue;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.ComboBox ComboBoxCondition;
    }
}