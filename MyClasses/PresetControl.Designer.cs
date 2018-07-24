namespace PlaylistParser.MyClasses
{
    partial class PresetControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PresetName = new System.Windows.Forms.Label();
            this.PresetHours = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.DeletePresetLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пресет";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Часы";
            // 
            // PresetName
            // 
            this.PresetName.AutoSize = true;
            this.PresetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PresetName.Location = new System.Drawing.Point(93, 13);
            this.PresetName.Name = "PresetName";
            this.PresetName.Size = new System.Drawing.Size(45, 17);
            this.PresetName.TabIndex = 2;
            this.PresetName.Text = "Name";
            // 
            // PresetHours
            // 
            this.PresetHours.AutoSize = true;
            this.PresetHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PresetHours.Location = new System.Drawing.Point(93, 39);
            this.PresetHours.Name = "PresetHours";
            this.PresetHours.Size = new System.Drawing.Size(49, 17);
            this.PresetHours.TabIndex = 3;
            this.PresetHours.Text = "HOurs";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(566, 51);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(84, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Редактировать";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnEditPresetLinkClick);
            // 
            // DeletePresetLinkLabel
            // 
            this.DeletePresetLinkLabel.AutoSize = true;
            this.DeletePresetLinkLabel.Location = new System.Drawing.Point(654, 50);
            this.DeletePresetLinkLabel.Name = "DeletePresetLinkLabel";
            this.DeletePresetLinkLabel.Size = new System.Drawing.Size(50, 13);
            this.DeletePresetLinkLabel.TabIndex = 5;
            this.DeletePresetLinkLabel.TabStop = true;
            this.DeletePresetLinkLabel.Text = "Удалить";
            this.DeletePresetLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnRemovePresetLinkClick);
            // 
            // PresetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeletePresetLinkLabel);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.PresetHours);
            this.Controls.Add(this.PresetName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PresetControl";
            this.Size = new System.Drawing.Size(720, 73);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PresetName;
        private System.Windows.Forms.Label PresetHours;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel DeletePresetLinkLabel;
    }
}
