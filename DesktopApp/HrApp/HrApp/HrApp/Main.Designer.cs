
using System;

namespace HrApp
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDismissal = new System.Windows.Forms.Button();
            this.dvgEmployes = new System.Windows.Forms.DataGridView();
            this.lbFilter = new System.Windows.Forms.Label();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmployes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 51);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Dodaj pracownika";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(113, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 51);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edytuj dane pracownika";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDismissal
            // 
            this.btnDismissal.Location = new System.Drawing.Point(214, 12);
            this.btnDismissal.Name = "btnDismissal";
            this.btnDismissal.Size = new System.Drawing.Size(95, 51);
            this.btnDismissal.TabIndex = 2;
            this.btnDismissal.Text = "Zwolnij pracownika";
            this.btnDismissal.UseVisualStyleBackColor = true;
            this.btnDismissal.Click += new System.EventHandler(this.btnDismissal_Click);
            // 
            // dvgEmployes
            // 
            this.dvgEmployes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgEmployes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgEmployes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dvgEmployes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgEmployes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgEmployes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEmployes.Location = new System.Drawing.Point(12, 69);
            this.dvgEmployes.Name = "dvgEmployes";
            this.dvgEmployes.RowHeadersWidth = 51;
            this.dvgEmployes.RowTemplate.Height = 24;
            this.dvgEmployes.Size = new System.Drawing.Size(1158, 444);
            this.dvgEmployes.TabIndex = 3;
            // 
            // lbFilter
            // 
            this.lbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(854, 29);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(46, 17);
            this.lbFilter.TabIndex = 4;
            this.lbFilter.Text = "Filtruj:";
            // 
            // cbxFilter
            // 
            this.cbxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "Wszyscy",
            "Zatrudnieni",
            "Zwolnieni"});
            this.cbxFilter.Location = new System.Drawing.Point(926, 26);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(244, 24);
            this.cbxFilter.TabIndex = 5;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 525);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.dvgEmployes);
            this.Controls.Add(this.btnDismissal);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program kadrowy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmployes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDismissal;
        private System.Windows.Forms.DataGridView dvgEmployes;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.ComboBox cbxFilter;
    }
}

