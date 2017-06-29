namespace book_complex_exercise_2
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
            this.btnIncrease1 = new System.Windows.Forms.Button();
            this.btnIncrease2 = new System.Windows.Forms.Button();
            this.btnIncrease3 = new System.Windows.Forms.Button();
            this.textInfo = new System.Windows.Forms.Label();
            this.textCurrentNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIncrease1
            // 
            this.btnIncrease1.Location = new System.Drawing.Point(60, 83);
            this.btnIncrease1.Name = "btnIncrease1";
            this.btnIncrease1.Size = new System.Drawing.Size(48, 48);
            this.btnIncrease1.TabIndex = 0;
            this.btnIncrease1.Text = "+1";
            this.btnIncrease1.UseVisualStyleBackColor = true;
            this.btnIncrease1.Click += new System.EventHandler(this.btnIncrease1_Click);
            // 
            // btnIncrease2
            // 
            this.btnIncrease2.Location = new System.Drawing.Point(114, 83);
            this.btnIncrease2.Name = "btnIncrease2";
            this.btnIncrease2.Size = new System.Drawing.Size(48, 48);
            this.btnIncrease2.TabIndex = 1;
            this.btnIncrease2.Text = "+2";
            this.btnIncrease2.UseVisualStyleBackColor = true;
            this.btnIncrease2.Click += new System.EventHandler(this.btnIncrease2_Click);
            // 
            // btnIncrease3
            // 
            this.btnIncrease3.Location = new System.Drawing.Point(168, 83);
            this.btnIncrease3.Name = "btnIncrease3";
            this.btnIncrease3.Size = new System.Drawing.Size(48, 48);
            this.btnIncrease3.TabIndex = 2;
            this.btnIncrease3.Text = "+3";
            this.btnIncrease3.UseVisualStyleBackColor = true;
            this.btnIncrease3.Click += new System.EventHandler(this.btnIncrease3_Click);
            // 
            // textInfo
            // 
            this.textInfo.AutoSize = true;
            this.textInfo.Location = new System.Drawing.Point(57, 62);
            this.textInfo.Name = "textInfo";
            this.textInfo.Size = new System.Drawing.Size(48, 13);
            this.textInfo.TabIndex = 3;
            this.textInfo.Text = "Player 1:";
            // 
            // textCurrentNumber
            // 
            this.textCurrentNumber.AutoSize = true;
            this.textCurrentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCurrentNumber.Location = new System.Drawing.Point(57, 149);
            this.textCurrentNumber.Name = "textCurrentNumber";
            this.textCurrentNumber.Size = new System.Drawing.Size(64, 25);
            this.textCurrentNumber.TabIndex = 4;
            this.textCurrentNumber.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "First to 21 or over loses!";
            // 
            // textScore
            // 
            this.textScore.AutoSize = true;
            this.textScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textScore.Location = new System.Drawing.Point(58, 195);
            this.textScore.Name = "textScore";
            this.textScore.Size = new System.Drawing.Size(74, 40);
            this.textScore.TabIndex = 6;
            this.textScore.Text = "P1 Score\r\n0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 280);
            this.Controls.Add(this.textScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textCurrentNumber);
            this.Controls.Add(this.textInfo);
            this.Controls.Add(this.btnIncrease3);
            this.Controls.Add(this.btnIncrease2);
            this.Controls.Add(this.btnIncrease1);
            this.Name = "Form1";
            this.Text = "Increase The Number!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIncrease1;
        private System.Windows.Forms.Button btnIncrease2;
        private System.Windows.Forms.Button btnIncrease3;
        private System.Windows.Forms.Label textInfo;
        private System.Windows.Forms.Label textCurrentNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label textScore;
    }
}

