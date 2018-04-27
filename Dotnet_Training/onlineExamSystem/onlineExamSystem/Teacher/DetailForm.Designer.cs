using System;
namespace UI
{
    partial class FormDetail
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

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            picSearchAttandence.Focus();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlAttendance = new System.Windows.Forms.Panel();
            this.picSearchAttandence = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlOrderTitle = new System.Windows.Forms.Panel();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.picOperation = new System.Windows.Forms.PictureBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.picAttendance = new System.Windows.Forms.PictureBox();
            this.picScore = new System.Windows.Forms.PictureBox();
            this.dgvAttendanceList = new System.Windows.Forms.DataGridView();
            this.rownum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass_criteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.pnlSearch = new UI.AdvancedLabel();
            this.bgwAttendanceList = new System.ComponentModel.BackgroundWorker();
            this.pnlAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchAttandence)).BeginInit();
            this.pnlOrderTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSystem
            // 
            resources.ApplyResources(this.lblSystem, "lblSystem");
            // 
            // txtPageNo
            // 
            resources.ApplyResources(this.txtPageNo, "txtPageNo");
            // 
            // cboPageSize
            // 
            resources.ApplyResources(this.cboPageSize, "cboPageSize");
            // 
            // pnlAttendance
            // 
            resources.ApplyResources(this.pnlAttendance, "pnlAttendance");
            this.pnlAttendance.BackColor = System.Drawing.Color.White;
            this.pnlAttendance.Controls.Add(this.picSearchAttandence);
            this.pnlAttendance.Controls.Add(this.txtName);
            this.pnlAttendance.Controls.Add(this.pnlOrderTitle);
            this.pnlAttendance.Controls.Add(this.dgvAttendanceList);
            this.pnlAttendance.Controls.Add(this.shapeContainer1);
            this.pnlAttendance.Controls.Add(this.pnlSearch);
            this.pnlAttendance.Name = "pnlAttendance";
            // 
            // picSearchAttandence
            // 
            resources.ApplyResources(this.picSearchAttandence, "picSearchAttandence");
            this.picSearchAttandence.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSearchAttandence.Image = global::UI.Properties.Resources.ICN_Search_15x20_png;
            this.picSearchAttandence.Name = "picSearchAttandence";
            this.picSearchAttandence.TabStop = false;
            this.picSearchAttandence.Click += new System.EventHandler(this.DoSearchOnClick);
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.txtName.Name = "txtName";
            this.txtName.Tag = "";
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoTxtBoxOnKeyDown);
            // 
            // pnlOrderTitle
            // 
            resources.ApplyResources(this.pnlOrderTitle, "pnlOrderTitle");
            this.pnlOrderTitle.Controls.Add(this.lblAttendance);
            this.pnlOrderTitle.Controls.Add(this.lblScore);
            this.pnlOrderTitle.Controls.Add(this.lblPass);
            this.pnlOrderTitle.Controls.Add(this.picOperation);
            this.pnlOrderTitle.Controls.Add(this.lblResult);
            this.pnlOrderTitle.Controls.Add(this.picAttendance);
            this.pnlOrderTitle.Controls.Add(this.picScore);
            this.pnlOrderTitle.Name = "pnlOrderTitle";
            // 
            // lblAttendance
            // 
            resources.ApplyResources(this.lblAttendance, "lblAttendance");
            this.lblAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAttendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblAttendance.Name = "lblAttendance";
            this.lblAttendance.Tag = "picAttendance";
            this.lblAttendance.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblScore
            // 
            resources.ApplyResources(this.lblScore, "lblScore");
            this.lblScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblScore.Name = "lblScore";
            this.lblScore.Tag = "picScore";
            this.lblScore.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblPass
            // 
            resources.ApplyResources(this.lblPass, "lblPass");
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblPass.Name = "lblPass";
            this.lblPass.Tag = "";
            // 
            // picOperation
            // 
            resources.ApplyResources(this.picOperation, "picOperation");
            this.picOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOperation.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picOperation.Name = "picOperation";
            this.picOperation.TabStop = false;
            this.picOperation.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblResult
            // 
            resources.ApplyResources(this.lblResult, "lblResult");
            this.lblResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblResult.Name = "lblResult";
            this.lblResult.Tag = "picOperation";
            this.lblResult.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picAttendance
            // 
            resources.ApplyResources(this.picAttendance, "picAttendance");
            this.picAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAttendance.Image = global::UI.Properties.Resources.ICN_Increase_10x15_png;
            this.picAttendance.Name = "picAttendance";
            this.picAttendance.TabStop = false;
            this.picAttendance.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picScore
            // 
            resources.ApplyResources(this.picScore, "picScore");
            this.picScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScore.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picScore.Name = "picScore";
            this.picScore.TabStop = false;
            this.picScore.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // dgvAttendanceList
            // 
            resources.ApplyResources(this.dgvAttendanceList, "dgvAttendanceList");
            this.dgvAttendanceList.AllowUserToAddRows = false;
            this.dgvAttendanceList.AllowUserToDeleteRows = false;
            this.dgvAttendanceList.AllowUserToResizeColumns = false;
            this.dgvAttendanceList.AllowUserToResizeRows = false;
            this.dgvAttendanceList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendanceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendanceList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvAttendanceList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAttendanceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceList.ColumnHeadersVisible = false;
            this.dgvAttendanceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rownum,
            this.name,
            this.pass_criteria,
            this.score,
            this.result});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendanceList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttendanceList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.dgvAttendanceList.MultiSelect = false;
            this.dgvAttendanceList.Name = "dgvAttendanceList";
            this.dgvAttendanceList.ReadOnly = true;
            this.dgvAttendanceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAttendanceList.RowHeadersVisible = false;
            this.dgvAttendanceList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgvAttendanceList.RowTemplate.DividerHeight = 1;
            this.dgvAttendanceList.RowTemplate.Height = 40;
            this.dgvAttendanceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAttendanceList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DoDgvPaperListOnCellPainting);
            this.dgvAttendanceList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DodgvPaperListRowPrePaint);
            // 
            // rownum
            // 
            this.rownum.DataPropertyName = "Rownum";
            resources.ApplyResources(this.rownum, "rownum");
            this.rownum.Name = "rownum";
            this.rownum.ReadOnly = true;
            this.rownum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rownum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pass_criteria
            // 
            this.pass_criteria.DataPropertyName = "PassCriteria";
            resources.ApplyResources(this.pass_criteria, "pass_criteria");
            this.pass_criteria.Name = "pass_criteria";
            this.pass_criteria.ReadOnly = true;
            this.pass_criteria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.pass_criteria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // score
            // 
            this.score.DataPropertyName = "Score";
            resources.ApplyResources(this.score, "score");
            this.score.Name = "score";
            this.score.ReadOnly = true;
            this.score.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.score.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // result
            // 
            this.result.DataPropertyName = "Result";
            resources.ApplyResources(this.result, "result");
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.result.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // shapeContainer1
            // 
            resources.ApplyResources(this.shapeContainer1, "shapeContainer1");
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1,
            this.lineShape2});
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            resources.ApplyResources(this.lineShape1, "lineShape1");
            this.lineShape1.Name = "lineOrderBottom";
            // 
            // lineShape2
            // 
            resources.ApplyResources(this.lineShape2, "lineShape2");
            this.lineShape2.Name = "lineOrderTop";
            // 
            // pnlSearch
            // 
            resources.ApplyResources(this.pnlSearch, "pnlSearch");
            this.pnlSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.pnlSearch.BorderSize = 1F;
            this.pnlSearch.DefaultBackColor = System.Drawing.Color.Empty;
            this.pnlSearch.DefaultFont = null;
            this.pnlSearch.DefaultFontColor = System.Drawing.Color.Empty;
            this.pnlSearch.MouseDownBackColor = System.Drawing.Color.Empty;
            this.pnlSearch.MouseDownFont = null;
            this.pnlSearch.MouseDownFontColor = System.Drawing.Color.Empty;
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Radius = 5F;
            // 
            // bgwAttendanceList
            // 
            this.bgwAttendanceList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoBgwAttendanceListDoWork);
            this.bgwAttendanceList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoBgwAttendanceListRunWorkerCompleted);
            // 
            // FormDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.pnlAttendance);
            this.Name = "FormDetail";
            this.SizeChanged += new System.EventHandler(this.FormDetailOnSizeChanged);
            this.Controls.SetChildIndex(this.pnlAttendance, 0);
            this.pnlAttendance.ResumeLayout(false);
            this.pnlAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchAttandence)).EndInit();
            this.pnlOrderTitle.ResumeLayout(false);
            this.pnlOrderTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAttendance;
        private System.Windows.Forms.PictureBox picSearchAttandence;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlOrderTitle;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.PictureBox picOperation;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.PictureBox picAttendance;
        private System.Windows.Forms.PictureBox picScore;
        private System.Windows.Forms.DataGridView dgvAttendanceList;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private AdvancedLabel pnlSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn rownum;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass_criteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.ComponentModel.BackgroundWorker bgwAttendanceList;
    }
}