namespace RobertHeijn_Desktop.Forms
{
    partial class ProductsForm
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
            this.pnlFlowBoxHolder = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblCategory = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.nmudPrice = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudPrice)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFlowBoxHolder
            // 
            this.pnlFlowBoxHolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFlowBoxHolder.Location = new System.Drawing.Point(0, 0);
            this.pnlFlowBoxHolder.Name = "pnlFlowBoxHolder";
            this.pnlFlowBoxHolder.Size = new System.Drawing.Size(287, 558);
            this.pnlFlowBoxHolder.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbCategories);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(748, 525);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit product";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbCategories
            // 
            this.lbCategories.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.ItemHeight = 20;
            this.lbCategories.Location = new System.Drawing.Point(3, 3);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.Size = new System.Drawing.Size(237, 519);
            this.lbCategories.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.nmudPrice);
            this.tabPage1.Controls.Add(this.btnCreate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbName);
            this.tabPage1.Controls.Add(this.lblCategory);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(748, 525);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Product";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCategory.Location = new System.Drawing.Point(59, 48);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(312, 31);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Choose a category on the left";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(69, 219);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(191, 27);
            this.tbName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Product name:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(226, 329);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(131, 43);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.OnCreateClick);
            // 
            // nmudPrice
            // 
            this.nmudPrice.DecimalPlaces = 2;
            this.nmudPrice.Location = new System.Drawing.Point(344, 220);
            this.nmudPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmudPrice.Name = "nmudPrice";
            this.nmudPrice.Size = new System.Drawing.Size(150, 27);
            this.nmudPrice.TabIndex = 5;
            this.nmudPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Price:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(287, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 558);
            this.tabControl1.TabIndex = 0;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 558);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlFlowBoxHolder);
            this.Name = "ProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.OnLoad);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudPrice)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnlFlowBoxHolder;
        private TabPage tabPage2;
        private ListBox lbCategories;
        private TabPage tabPage1;
        private Label label2;
        private NumericUpDown nmudPrice;
        private Button btnCreate;
        private Label label1;
        private TextBox tbName;
        private Label lblCategory;
        private TabControl tabControl1;
    }
}