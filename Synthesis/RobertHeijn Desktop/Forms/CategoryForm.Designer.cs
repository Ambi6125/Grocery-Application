namespace RobertHeijn_Desktop.Forms
{
    partial class CategoryForm
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
            this.pnlControlContainer = new System.Windows.Forms.Panel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnSelectParent = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSelection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlControlContainer
            // 
            this.pnlControlContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlControlContainer.Name = "pnlControlContainer";
            this.pnlControlContainer.Size = new System.Drawing.Size(381, 450);
            this.pnlControlContainer.TabIndex = 0;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(625, 242);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(163, 27);
            this.tbName.TabIndex = 1;
            this.tbName.Leave += new System.EventHandler(this.OnLeaveNameBox);
            // 
            // btnSelectParent
            // 
            this.btnSelectParent.Location = new System.Drawing.Point(442, 154);
            this.btnSelectParent.Name = "btnSelectParent";
            this.btnSelectParent.Size = new System.Drawing.Size(131, 31);
            this.btnSelectParent.TabIndex = 2;
            this.btnSelectParent.Text = "Select as parent";
            this.btnSelectParent.UseVisualStyleBackColor = true;
            this.btnSelectParent.Click += new System.EventHandler(this.OnParentSelectClick);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(442, 242);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(131, 32);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import category";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.OnImportClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(392, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "←";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(573, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 41);
            this.label2.TabIndex = 5;
            this.label2.Text = "→";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(527, 363);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 57);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelection.Location = new System.Drawing.Point(423, 63);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(178, 41);
            this.lblSelection.TabIndex = 7;
            this.lblSelection.Text = "<selection>";
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSelectParent);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.pnlControlContainer);
            this.Name = "CategoryForm";
            this.Text = "Manage categories";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlControlContainer;
        private TextBox tbName;
        private Button btnSelectParent;
        private Button btnImport;
        private Label label1;
        private Label label2;
        private Button btnSave;
        private Label lblSelection;
    }
}