namespace RobertHeijn_Desktop.Controls
{
    partial class CategoryFlowBox
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
            this.flpBoxes = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpBoxes
            // 
            this.flpBoxes.AutoScroll = true;
            this.flpBoxes.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpBoxes.Location = new System.Drawing.Point(0, 0);
            this.flpBoxes.Name = "flpBoxes";
            this.flpBoxes.Size = new System.Drawing.Size(366, 481);
            this.flpBoxes.TabIndex = 0;
            // 
            // CategoryFlowBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpBoxes);
            this.Name = "CategoryFlowBox";
            this.Size = new System.Drawing.Size(381, 481);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flpBoxes;
    }
}
