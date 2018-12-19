namespace Howling_Software
{
    partial class Error
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Error));
            this.Launch_button = new System.Windows.Forms.Button();
            this.ErrorMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Launch_button
            // 
            this.Launch_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Launch_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Launch_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Launch_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Launch_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Launch_button.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Launch_button.ForeColor = System.Drawing.Color.White;
            this.Launch_button.Location = new System.Drawing.Point(12, 92);
            this.Launch_button.Name = "Launch_button";
            this.Launch_button.Size = new System.Drawing.Size(284, 24);
            this.Launch_button.TabIndex = 38;
            this.Launch_button.Text = "OK";
            this.Launch_button.UseVisualStyleBackColor = false;
            this.Launch_button.Click += new System.EventHandler(this.Launch_button_Click);
            // 
            // ErrorMsg
            // 
            this.ErrorMsg.AutoSize = true;
            this.ErrorMsg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMsg.ForeColor = System.Drawing.Color.White;
            this.ErrorMsg.Location = new System.Drawing.Point(12, 20);
            this.ErrorMsg.Name = "ErrorMsg";
            this.ErrorMsg.Size = new System.Drawing.Size(52, 16);
            this.ErrorMsg.TabIndex = 39;
            this.ErrorMsg.Text = "No Text\r\n";
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(312, 128);
            this.Controls.Add(this.ErrorMsg);
            this.Controls.Add(this.Launch_button);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Error";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.Error_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Launch_button;
        private System.Windows.Forms.Label ErrorMsg;
    }
}