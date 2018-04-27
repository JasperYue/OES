namespace UI
{
    partial class PanelLoop
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
            this.lblRownum = new System.Windows.Forms.Label();
            this.llblName = new System.Windows.Forms.LinkLabel();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblEffectiveTime = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblPassCriteria = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.llblStatus = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblRownum
            // 
            this.lblRownum.BackColor = System.Drawing.Color.White;
            this.lblRownum.Location = new System.Drawing.Point(0, 0);
            this.lblRownum.Name = "lblRownum";
            this.lblRownum.Size = new System.Drawing.Size(45, 40);
            this.lblRownum.TabIndex = 0;
            this.lblRownum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llblName
            // 
            this.llblName.BackColor = System.Drawing.Color.White;
            this.llblName.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblName.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.llblName.Location = new System.Drawing.Point(45, 0);
            this.llblName.Name = "llblName";
            this.llblName.Size = new System.Drawing.Size(170, 40);
            this.llblName.TabIndex = 1;
            this.llblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNum
            // 
            this.lblNum.BackColor = System.Drawing.Color.White;
            this.lblNum.Location = new System.Drawing.Point(215, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(85, 40);
            this.lblNum.TabIndex = 2;
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEffectiveTime
            // 
            this.lblEffectiveTime.BackColor = System.Drawing.Color.White;
            this.lblEffectiveTime.Location = new System.Drawing.Point(300, 0);
            this.lblEffectiveTime.Name = "lblEffectiveTime";
            this.lblEffectiveTime.Size = new System.Drawing.Size(150, 40);
            this.lblEffectiveTime.TabIndex = 3;
            this.lblEffectiveTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.White;
            this.lblDuration.Location = new System.Drawing.Point(450, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(110, 40);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassCriteria
            // 
            this.lblPassCriteria.BackColor = System.Drawing.Color.White;
            this.lblPassCriteria.Location = new System.Drawing.Point(560, 0);
            this.lblPassCriteria.Name = "lblPassCriteria";
            this.lblPassCriteria.Size = new System.Drawing.Size(130, 40);
            this.lblPassCriteria.TabIndex = 5;
            this.lblPassCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(690, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(150, 40);
            this.lblScore.TabIndex = 6;
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llblStatus
            // 
            this.llblStatus.BackColor = System.Drawing.Color.White;
            this.llblStatus.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.llblStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.llblStatus.Location = new System.Drawing.Point(840, 0);
            this.llblStatus.Name = "llblStatus";
            this.llblStatus.Size = new System.Drawing.Size(145, 40);
            this.llblStatus.TabIndex = 7;
            this.llblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.llblStatus);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblPassCriteria);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblEffectiveTime);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.llblName);
            this.Controls.Add(this.lblRownum);
            this.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PanelLoop";
            this.Size = new System.Drawing.Size(985, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRownum;
        private System.Windows.Forms.LinkLabel llblName;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblEffectiveTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblPassCriteria;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.LinkLabel llblStatus;
    }
}
