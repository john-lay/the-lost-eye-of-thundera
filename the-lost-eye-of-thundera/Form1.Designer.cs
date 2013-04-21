namespace the_lost_eye_of_thundera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelSecondTimer = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainMenu_Game = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_Game_Resize = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_Game_ResizeScale1x = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu_Game_ResizeScale2x = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(28, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(498, 433);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 25);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(24, 438);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(36, 13);
            this.labelTimer.TabIndex = 2;
            this.labelTimer.Text = "Timer:";
            // 
            // labelSecondTimer
            // 
            this.labelSecondTimer.AutoSize = true;
            this.labelSecondTimer.Location = new System.Drawing.Point(24, 464);
            this.labelSecondTimer.Name = "labelSecondTimer";
            this.labelSecondTimer.Size = new System.Drawing.Size(36, 13);
            this.labelSecondTimer.TabIndex = 3;
            this.labelSecondTimer.Text = "Timer:";
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(25, 489);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(37, 13);
            this.labelInput.TabIndex = 4;
            this.labelInput.Text = "Input: ";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_Game,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(632, 24);
            this.MainMenu.TabIndex = 5;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MainMenu_Game
            // 
            this.MainMenu_Game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_Game_Resize});
            this.MainMenu_Game.Name = "MainMenu_Game";
            this.MainMenu_Game.Size = new System.Drawing.Size(46, 20);
            this.MainMenu_Game.Text = "Game";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MainMenu_Game_Resize
            // 
            this.MainMenu_Game_Resize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_Game_ResizeScale1x,
            this.MainMenu_Game_ResizeScale2x});
            this.MainMenu_Game_Resize.Name = "MainMenu_Game_Resize";
            this.MainMenu_Game_Resize.Size = new System.Drawing.Size(152, 22);
            this.MainMenu_Game_Resize.Text = "Resize";
            // 
            // MainMenu_Game_ResizeScale1x
            // 
            this.MainMenu_Game_ResizeScale1x.Name = "MainMenu_Game_ResizeScale1x";
            this.MainMenu_Game_ResizeScale1x.Size = new System.Drawing.Size(178, 22);
            this.MainMenu_Game_ResizeScale1x.Text = "Scale 1x (288x200)";
            this.MainMenu_Game_ResizeScale1x.Click += new System.EventHandler(this.MainMenu_Game_ResizeScale1x_Click);
            // 
            // MainMenu_Game_ResizeScale2x
            // 
            this.MainMenu_Game_ResizeScale2x.Name = "MainMenu_Game_ResizeScale2x";
            this.MainMenu_Game_ResizeScale2x.Size = new System.Drawing.Size(178, 22);
            this.MainMenu_Game_ResizeScale2x.Text = "Scale 2x (576x400)";
            this.MainMenu_Game_ResizeScale2x.Click += new System.EventHandler(this.MainMenu_Game_ResizeScale2x_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 606);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.labelSecondTimer);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Form1";
            this.Text = "Thundercats: The lost eye of Thundera";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelSecondTimer;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_Game;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_Game_Resize;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_Game_ResizeScale1x;
        private System.Windows.Forms.ToolStripMenuItem MainMenu_Game_ResizeScale2x;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

