namespace Asgn2
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
            rb_Op1 = new System.Windows.Forms.RadioButton();
            rb_Op2 = new System.Windows.Forms.RadioButton();
            rb_Op3 = new System.Windows.Forms.RadioButton();
            b_ResetPos = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // rb_Op1
            // 
            rb_Op1.AutoSize = true;
            rb_Op1.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rb_Op1.Location = new System.Drawing.Point(60, 51);
            rb_Op1.Name = "rb_Op1";
            rb_Op1.Size = new System.Drawing.Size(181, 25);
            rb_Op1.TabIndex = 0;
            rb_Op1.TabStop = true;
            rb_Op1.Text = "Color By Position";
            rb_Op1.UseVisualStyleBackColor = true;
            rb_Op1.CheckedChanged += rb_Op1_CheckedChanged;
            // 
            // rb_Op2
            // 
            rb_Op2.AutoSize = true;
            rb_Op2.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rb_Op2.Location = new System.Drawing.Point(60, 94);
            rb_Op2.Name = "rb_Op2";
            rb_Op2.Size = new System.Drawing.Size(232, 25);
            rb_Op2.TabIndex = 1;
            rb_Op2.TabStop = true;
            rb_Op2.Text = "Dynamic Text Specular";
            rb_Op2.UseVisualStyleBackColor = true;
            rb_Op2.CheckedChanged += rb_Op2_CheckedChanged;
            // 
            // rb_Op3
            // 
            rb_Op3.AutoSize = true;
            rb_Op3.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rb_Op3.Location = new System.Drawing.Point(60, 174);
            rb_Op3.Name = "rb_Op3";
            rb_Op3.Size = new System.Drawing.Size(225, 25);
            rb_Op3.TabIndex = 2;
            rb_Op3.TabStop = true;
            rb_Op3.Text = "Move Cube To Sphere";
            rb_Op3.UseVisualStyleBackColor = true;
            rb_Op3.CheckedChanged += rb_Op3_CheckedChanged;
            // 
            // b_ResetPos
            // 
            b_ResetPos.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            b_ResetPos.Location = new System.Drawing.Point(85, 125);
            b_ResetPos.Name = "b_ResetPos";
            b_ResetPos.Size = new System.Drawing.Size(200, 30);
            b_ResetPos.TabIndex = 3;
            b_ResetPos.Text = "Reset Light Position";
            b_ResetPos.UseVisualStyleBackColor = true;
            b_ResetPos.Click += b_ResetPos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(334, 261);
            Controls.Add(b_ResetPos);
            Controls.Add(rb_Op3);
            Controls.Add(rb_Op2);
            Controls.Add(rb_Op1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Form1";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton rb_Op1;
        private System.Windows.Forms.RadioButton rb_Op2;
        private System.Windows.Forms.RadioButton rb_Op3;
        private System.Windows.Forms.Button b_ResetPos;
    }
}