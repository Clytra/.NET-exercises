
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDismissal = new System.Windows.Forms.Button();
            this.dvgEmployes = new System.Windows.Forms.DataGridView();
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
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(113, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 51);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edytuj dane pracownika";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDismissal
            // 
            this.btnDismissal.Location = new System.Drawing.Point(214, 12);
            this.btnDismissal.Name = "btnDismissal";
            this.btnDismissal.Size = new System.Drawing.Size(95, 51);
            this.btnDismissal.TabIndex = 2;
            this.btnDismissal.Text = "Zwolnij pracownika";
            this.btnDismissal.UseVisualStyleBackColor = true;
            // 
            // dvgEmployes
            // 
            this.dvgEmployes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dvgEmployes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEmployes.Location = new System.Drawing.Point(12, 69);
            this.dvgEmployes.Name = "dvgEmployes";
            this.dvgEmployes.RowHeadersWidth = 51;
            this.dvgEmployes.RowTemplate.Height = 24;
            this.dvgEmployes.Size = new System.Drawing.Size(1158, 444);
            this.dvgEmployes.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 525);
            this.Controls.Add(this.dvgEmployes);
            this.Controls.Add(this.btnDismissal);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "Main";
            this.Text = "Program kadrowy";
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmployes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDismissal;
        private System.Windows.Forms.DataGridView dvgEmployes;
    }
}

