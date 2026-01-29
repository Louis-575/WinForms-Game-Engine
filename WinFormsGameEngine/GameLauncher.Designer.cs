namespace WinFormsGameEngine
{
    partial class GameLauncher
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(473, 133);
            label1.Name = "label1";
            label1.Size = new Size(113, 41);
            label1.TabIndex = 0;
            label1.Text = "Games";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = Color.Red;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 10;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bernard MT Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(439, 191);
            button1.Name = "button1";
            button1.Size = new Size(172, 63);
            button1.TabIndex = 1;
            button1.Text = "Bounce";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.BackColor = Color.Red;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatAppearance.BorderSize = 10;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Bernard MT Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(439, 260);
            button2.Name = "button2";
            button2.Size = new Size(172, 63);
            button2.TabIndex = 2;
            button2.Text = "FootballGame";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // GameLauncher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 574);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "GameLauncher";
            Text = "GameLauncher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
    }
}