namespace Snake
{
    partial class GameForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SnakeHead = new System.Windows.Forms.Panel();
            this.Fruit = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.SnakeHead);
            this.panel1.Controls.Add(this.Fruit);
            this.panel1.Location = new System.Drawing.Point(10, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 0;
            // 
            // SnakeHead
            // 
            this.SnakeHead.BackColor = System.Drawing.SystemColors.InfoText;
            this.SnakeHead.Location = new System.Drawing.Point(238, 101);
            this.SnakeHead.Name = "SnakeHead";
            this.SnakeHead.Size = new System.Drawing.Size(25, 25);
            this.SnakeHead.TabIndex = 1;
            // 
            // Fruit
            // 
            this.Fruit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Fruit.Location = new System.Drawing.Point(238, 334);
            this.Fruit.Name = "Fruit";
            this.Fruit.Size = new System.Drawing.Size(25, 25);
            this.Fruit.TabIndex = 0;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(396, -2);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(114, 29);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "Score : 0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(682, 653);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel SnakeHead;
        private System.Windows.Forms.Panel Fruit;
        private System.Windows.Forms.Label scoreLabel;
    }
}