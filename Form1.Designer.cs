namespace BeautifulGirl
{
    partial class Form1
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
            this.lblBefore = new System.Windows.Forms.Label();
            this.textBoxBefore = new System.Windows.Forms.TextBox();
            this.textBoxAfter = new System.Windows.Forms.TextBox();
            this.lblAfter = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBefore
            // 
            this.lblBefore.AutoSize = true;
            this.lblBefore.Location = new System.Drawing.Point(18, 16);
            this.lblBefore.Name = "lblBefore";
            this.lblBefore.Size = new System.Drawing.Size(38, 13);
            this.lblBefore.TabIndex = 0;
            this.lblBefore.Text = "Before";
            this.lblBefore.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxBefore
            // 
            this.textBoxBefore.Location = new System.Drawing.Point(21, 47);
            this.textBoxBefore.Multiline = true;
            this.textBoxBefore.Name = "textBoxBefore";
            this.textBoxBefore.Size = new System.Drawing.Size(228, 198);
            this.textBoxBefore.TabIndex = 1;
            this.textBoxBefore.TextChanged += new System.EventHandler(this.textBoxBefore_TextChanged);
            // 
            // textBoxAfter
            // 
            this.textBoxAfter.Location = new System.Drawing.Point(406, 47);
            this.textBoxAfter.Multiline = true;
            this.textBoxAfter.Name = "textBoxAfter";
            this.textBoxAfter.Size = new System.Drawing.Size(228, 198);
            this.textBoxAfter.TabIndex = 3;
            this.textBoxAfter.TextChanged += new System.EventHandler(this.textBoxAfter_TextChanged);
            // 
            // lblAfter
            // 
            this.lblAfter.AutoSize = true;
            this.lblAfter.Location = new System.Drawing.Point(403, 16);
            this.lblAfter.Name = "lblAfter";
            this.lblAfter.Size = new System.Drawing.Size(29, 13);
            this.lblAfter.TabIndex = 2;
            this.lblAfter.Text = "After";
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(272, 103);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 83);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Beautiful Girl";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.TextChanged += new System.EventHandler(this.textBoxAfter_TextChanged);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 267);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.textBoxAfter);
            this.Controls.Add(this.lblAfter);
            this.Controls.Add(this.textBoxBefore);
            this.Controls.Add(this.lblBefore);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beautiful Girl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBefore;
        private System.Windows.Forms.TextBox textBoxBefore;
        private System.Windows.Forms.TextBox textBoxAfter;
        private System.Windows.Forms.Label lblAfter;
        private System.Windows.Forms.Button btnStart;
    }
}

