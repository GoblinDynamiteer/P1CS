namespace book_complex_exercise_1
{
    partial class GuessNumber
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxGuess = new System.Windows.Forms.TextBox();
            this.ButtonGuess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(28, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 46);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter number (1-100)";
            // 
            // TextBoxGuess
            // 
            this.TextBoxGuess.Location = new System.Drawing.Point(137, 57);
            this.TextBoxGuess.Name = "TextBoxGuess";
            this.TextBoxGuess.Size = new System.Drawing.Size(80, 20);
            this.TextBoxGuess.TabIndex = 0;
            this.TextBoxGuess.TextChanged += new System.EventHandler(this.TextBoxGuess_TextChanged);
            // 
            // ButtonGuess
            // 
            this.ButtonGuess.Location = new System.Drawing.Point(137, 84);
            this.ButtonGuess.Name = "ButtonGuess";
            this.ButtonGuess.Size = new System.Drawing.Size(80, 23);
            this.ButtonGuess.TabIndex = 3;
            this.ButtonGuess.Text = "Guess!";
            this.ButtonGuess.UseVisualStyleBackColor = true;
            this.ButtonGuess.Click += new System.EventHandler(this.ButtonGuess_Click);
            // 
            // GuessNumber
            // 
            this.AcceptButton = this.ButtonGuess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 137);
            this.Controls.Add(this.ButtonGuess);
            this.Controls.Add(this.TextBoxGuess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "GuessNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guess the number!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxGuess;
        private System.Windows.Forms.Button ButtonGuess;
    }
}

