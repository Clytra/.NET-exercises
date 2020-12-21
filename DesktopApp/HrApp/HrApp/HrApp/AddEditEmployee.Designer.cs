
namespace HrApp
{
    partial class AddEditEmployee
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
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbDateOfEmployment = new System.Windows.Forms.Label();
            this.lbEarnings = new System.Windows.Forms.Label();
            this.lbComments = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbDateOfEmployment = new System.Windows.Forms.TextBox();
            this.tbEarnings = new System.Windows.Forms.TextBox();
            this.rtbComments = new System.Windows.Forms.RichTextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbId = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(12, 54);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(37, 17);
            this.lbFirstName.TabIndex = 0;
            this.lbFirstName.Text = "Imię:";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(12, 89);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(71, 17);
            this.lbLastName.TabIndex = 1;
            this.lbLastName.Text = "Nazwisko:";
            // 
            // lbDateOfEmployment
            // 
            this.lbDateOfEmployment.AutoSize = true;
            this.lbDateOfEmployment.Location = new System.Drawing.Point(12, 127);
            this.lbDateOfEmployment.Name = "lbDateOfEmployment";
            this.lbDateOfEmployment.Size = new System.Drawing.Size(124, 17);
            this.lbDateOfEmployment.TabIndex = 2;
            this.lbDateOfEmployment.Text = "Data zatrudnienia:";
            // 
            // lbEarnings
            // 
            this.lbEarnings.AutoSize = true;
            this.lbEarnings.Location = new System.Drawing.Point(12, 164);
            this.lbEarnings.Name = "lbEarnings";
            this.lbEarnings.Size = new System.Drawing.Size(60, 17);
            this.lbEarnings.TabIndex = 3;
            this.lbEarnings.Text = "Zarobki:";
            // 
            // lbComments
            // 
            this.lbComments.AutoSize = true;
            this.lbComments.Location = new System.Drawing.Point(12, 245);
            this.lbComments.Name = "lbComments";
            this.lbComments.Size = new System.Drawing.Size(50, 17);
            this.lbComments.TabIndex = 4;
            this.lbComments.Text = "Uwagi:";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(188, 54);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(219, 22);
            this.tbFirstName.TabIndex = 5;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(188, 89);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(219, 22);
            this.tbLastName.TabIndex = 6;
            // 
            // tbDateOfEmployment
            // 
            this.tbDateOfEmployment.Location = new System.Drawing.Point(188, 124);
            this.tbDateOfEmployment.Name = "tbDateOfEmployment";
            this.tbDateOfEmployment.Size = new System.Drawing.Size(219, 22);
            this.tbDateOfEmployment.TabIndex = 7;
            // 
            // tbEarnings
            // 
            this.tbEarnings.Location = new System.Drawing.Point(188, 161);
            this.tbEarnings.Name = "tbEarnings";
            this.tbEarnings.Size = new System.Drawing.Size(219, 22);
            this.tbEarnings.TabIndex = 8;
            // 
            // rtbComments
            // 
            this.rtbComments.Location = new System.Drawing.Point(188, 218);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(219, 96);
            this.rtbComments.TabIndex = 9;
            this.rtbComments.Text = "";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(36, 352);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(81, 30);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Zatwierdź";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(157, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(12, 21);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(23, 17);
            this.lbId.TabIndex = 12;
            this.lbId.Text = "Id:";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(188, 16);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(219, 22);
            this.tbId.TabIndex = 13;
            // 
            // AddEditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 395);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.rtbComments);
            this.Controls.Add(this.tbEarnings);
            this.Controls.Add(this.tbDateOfEmployment);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.lbComments);
            this.Controls.Add(this.lbEarnings);
            this.Controls.Add(this.lbDateOfEmployment);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.lbFirstName);
            this.Name = "AddEditEmployee";
            this.Text = "AddEditEmployee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbDateOfEmployment;
        private System.Windows.Forms.Label lbEarnings;
        private System.Windows.Forms.Label lbComments;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbDateOfEmployment;
        private System.Windows.Forms.TextBox tbEarnings;
        private System.Windows.Forms.RichTextBox rtbComments;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.TextBox tbId;
    }
}