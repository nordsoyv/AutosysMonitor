﻿namespace AutosysMonitor
{
    partial class StatusForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
			this.UpdateAllButton = new System.Windows.Forms.Button();
			this.Refreshtimer = new System.Windows.Forms.Timer(this.components);
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SystemView = new System.Windows.Forms.DataGridView();
			this.StatusColumn = new System.Windows.Forms.DataGridViewImageColumn();
			this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Ping = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ReloadFileButton = new System.Windows.Forms.Button();
			this.openSystemFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.lblSetRefreshTime = new System.Windows.Forms.Label();
			this.txtSetRefreshtime = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ckbRefreshEnabled = new System.Windows.Forms.CheckBox();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.aliveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.systemerDataSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.SystemView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.systemerDataSource)).BeginInit();
			this.SuspendLayout();
			// 
			// UpdateAllButton
			// 
			this.UpdateAllButton.Location = new System.Drawing.Point(15, 12);
			this.UpdateAllButton.Name = "UpdateAllButton";
			this.UpdateAllButton.Size = new System.Drawing.Size(103, 23);
			this.UpdateAllButton.TabIndex = 1;
			this.UpdateAllButton.Text = "Oppdater alle";
			this.UpdateAllButton.UseVisualStyleBackColor = true;
			this.UpdateAllButton.Click += new System.EventHandler(this.UpdateAllButton_Click);
			// 
			// Refreshtimer
			// 
			this.Refreshtimer.Enabled = true;
			this.Refreshtimer.Interval = 5000;
			this.Refreshtimer.Tick += new System.EventHandler(this.Refreshtimer_Tick);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			// 
			// SystemView
			// 
			this.SystemView.AllowUserToAddRows = false;
			this.SystemView.AllowUserToDeleteRows = false;
			this.SystemView.AutoGenerateColumns = false;
			this.SystemView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.SystemView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.SystemView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.SystemView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.StatusColumn,
            this.Url,
            this.aliveDataGridViewCheckBoxColumn,
            this.Ping});
			this.SystemView.DataSource = this.systemerDataSource;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.SystemView.DefaultCellStyle = dataGridViewCellStyle2;
			this.SystemView.Location = new System.Drawing.Point(15, 41);
			this.SystemView.Name = "SystemView";
			this.SystemView.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.SystemView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.SystemView.Size = new System.Drawing.Size(706, 479);
			this.SystemView.TabIndex = 0;
			this.SystemView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.SystemView_CellPainting);
			// 
			// StatusColumn
			// 
			this.StatusColumn.HeaderText = "Status";
			this.StatusColumn.Image = ((System.Drawing.Image)(resources.GetObject("StatusColumn.Image")));
			this.StatusColumn.Name = "StatusColumn";
			this.StatusColumn.ReadOnly = true;
			this.StatusColumn.Width = 43;
			// 
			// Url
			// 
			this.Url.DataPropertyName = "Url";
			this.Url.HeaderText = "Url";
			this.Url.Name = "Url";
			this.Url.ReadOnly = true;
			this.Url.Width = 45;
			// 
			// Ping
			// 
			this.Ping.DataPropertyName = "Ping";
			this.Ping.HeaderText = "Ping";
			this.Ping.Name = "Ping";
			this.Ping.ReadOnly = true;
			this.Ping.Width = 53;
			// 
			// ReloadFileButton
			// 
			this.ReloadFileButton.Location = new System.Drawing.Point(124, 12);
			this.ReloadFileButton.Name = "ReloadFileButton";
			this.ReloadFileButton.Size = new System.Drawing.Size(102, 23);
			this.ReloadFileButton.TabIndex = 7;
			this.ReloadFileButton.Text = "Les fil";
			this.ReloadFileButton.UseVisualStyleBackColor = true;
			this.ReloadFileButton.Click += new System.EventHandler(this.ReloadFileButton_Click);
			// 
			// openSystemFileDialog
			// 
			this.openSystemFileDialog.FileName = "systemer.txt";
			this.openSystemFileDialog.InitialDirectory = ".";
			// 
			// lblSetRefreshTime
			// 
			this.lblSetRefreshTime.AutoSize = true;
			this.lblSetRefreshTime.Location = new System.Drawing.Point(233, 22);
			this.lblSetRefreshTime.Name = "lblSetRefreshTime";
			this.lblSetRefreshTime.Size = new System.Drawing.Size(66, 13);
			this.lblSetRefreshTime.TabIndex = 8;
			this.lblSetRefreshTime.Text = "Refresh time";
			// 
			// txtSetRefreshtime
			// 
			this.txtSetRefreshtime.Location = new System.Drawing.Point(305, 15);
			this.txtSetRefreshtime.Name = "txtSetRefreshtime";
			this.txtSetRefreshtime.Size = new System.Drawing.Size(100, 20);
			this.txtSetRefreshtime.TabIndex = 9;
			this.txtSetRefreshtime.TextChanged += new System.EventHandler(this.txtSetRefreshtime_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(412, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Refresh enabled";
			// 
			// ckbRefreshEnabled
			// 
			this.ckbRefreshEnabled.AutoSize = true;
			this.ckbRefreshEnabled.Checked = true;
			this.ckbRefreshEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbRefreshEnabled.Location = new System.Drawing.Point(503, 22);
			this.ckbRefreshEnabled.Name = "ckbRefreshEnabled";
			this.ckbRefreshEnabled.Size = new System.Drawing.Size(15, 14);
			this.ckbRefreshEnabled.TabIndex = 11;
			this.ckbRefreshEnabled.UseVisualStyleBackColor = true;
			this.ckbRefreshEnabled.CheckedChanged += new System.EventHandler(this.ckbRefreshEnabled_CheckedChanged);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn1.HeaderText = "Name";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 60;
			// 
			// aliveDataGridViewCheckBoxColumn
			// 
			this.aliveDataGridViewCheckBoxColumn.DataPropertyName = "Alive";
			this.aliveDataGridViewCheckBoxColumn.HeaderText = "Alive";
			this.aliveDataGridViewCheckBoxColumn.Name = "aliveDataGridViewCheckBoxColumn";
			this.aliveDataGridViewCheckBoxColumn.ReadOnly = true;
			this.aliveDataGridViewCheckBoxColumn.Visible = false;
			this.aliveDataGridViewCheckBoxColumn.Width = 36;
			// 
			// systemerDataSource
			// 
			this.systemerDataSource.DataSource = typeof(AutosysMonitor.IAutosysSystem);
			// 
			// StatusForm
			// 
			this.ClientSize = new System.Drawing.Size(733, 532);
			this.Controls.Add(this.ckbRefreshEnabled);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSetRefreshtime);
			this.Controls.Add(this.lblSetRefreshTime);
			this.Controls.Add(this.ReloadFileButton);
			this.Controls.Add(this.SystemView);
			this.Controls.Add(this.UpdateAllButton);
			this.Name = "StatusForm";
			this.Text = "Autosys status";
			this.Load += new System.EventHandler(this.StatusForm_Load);
			this.Resize += new System.EventHandler(this.StatusForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.SystemView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.systemerDataSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateAllButton;
        private System.Windows.Forms.Timer Refreshtimer;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.DataGridView SystemView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button ReloadFileButton;
		private System.Windows.Forms.BindingSource systemerDataSource;
		private System.Windows.Forms.OpenFileDialog openSystemFileDialog;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewImageColumn StatusColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn Url;
		private System.Windows.Forms.DataGridViewCheckBoxColumn aliveDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn Ping;
		private System.Windows.Forms.Label lblSetRefreshTime;
		private System.Windows.Forms.TextBox txtSetRefreshtime;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox ckbRefreshEnabled;
    }
}

