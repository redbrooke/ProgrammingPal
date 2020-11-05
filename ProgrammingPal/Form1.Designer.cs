namespace ProgrammingPal
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
            this.display = new System.Windows.Forms.PictureBox();
            this.Codebox = new System.Windows.Forms.RichTextBox();
            this.commandLine = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(546, 23);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(532, 496);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            this.display.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            // 
            // Codebox
            // 
            this.Codebox.Location = new System.Drawing.Point(9, 23);
            this.Codebox.Name = "Codebox";
            this.Codebox.Size = new System.Drawing.Size(500, 380);
            this.Codebox.TabIndex = 1;
            this.Codebox.Text = "";
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(12, 453);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(497, 20);
            this.commandLine.TabIndex = 2;
            this.commandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLine_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 551);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.Codebox);
            this.Controls.Add(this.display);
            this.Name = "Form1";
            this.Text = "Programming Pal";
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.RichTextBox Codebox;
        private System.Windows.Forms.TextBox commandLine;
    }
}

