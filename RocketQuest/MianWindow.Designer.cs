
namespace RocketQuest
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scoreDisplay = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.stateLabel = new System.Windows.Forms.Label();
            this.nickName = new System.Windows.Forms.TextBox();
            this.exitBTN = new System.Windows.Forms.Button();
            this.scoreList = new System.Windows.Forms.ListBox();
            this.startBTN = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.AutoSize = true;
            this.scoreDisplay.Location = new System.Drawing.Point(0, 0);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(38, 15);
            this.scoreDisplay.TabIndex = 0;
            this.scoreDisplay.Text = "label1";
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.stateLabel);
            this.menuPanel.Controls.Add(this.nickName);
            this.menuPanel.Controls.Add(this.exitBTN);
            this.menuPanel.Controls.Add(this.scoreList);
            this.menuPanel.Controls.Add(this.startBTN);
            this.menuPanel.Location = new System.Drawing.Point(213, 166);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(380, 258);
            this.menuPanel.TabIndex = 1;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(157, 13);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(38, 15);
            this.stateLabel.TabIndex = 4;
            this.stateLabel.Text = "label1";
            // 
            // nickName
            // 
            this.nickName.Location = new System.Drawing.Point(52, 105);
            this.nickName.Name = "nickName";
            this.nickName.Size = new System.Drawing.Size(100, 23);
            this.nickName.TabIndex = 3;
            // 
            // exitBTN
            // 
            this.exitBTN.FlatAppearance.BorderSize = 0;
            this.exitBTN.Location = new System.Drawing.Point(52, 166);
            this.exitBTN.Name = "exitBTN";
            this.exitBTN.Size = new System.Drawing.Size(100, 23);
            this.exitBTN.TabIndex = 2;
            this.exitBTN.Text = "button2";
            this.exitBTN.UseVisualStyleBackColor = true;
            this.exitBTN.Click += new System.EventHandler(this.exitBTN_Click);
            // 
            // scoreList
            // 
            this.scoreList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scoreList.FormattingEnabled = true;
            this.scoreList.ItemHeight = 15;
            this.scoreList.Location = new System.Drawing.Point(223, 95);
            this.scoreList.Name = "scoreList";
            this.scoreList.Size = new System.Drawing.Size(120, 90);
            this.scoreList.TabIndex = 1;
            // 
            // startBTN
            // 
            this.startBTN.FlatAppearance.BorderSize = 0;
            this.startBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startBTN.Location = new System.Drawing.Point(140, 47);
            this.startBTN.Name = "startBTN";
            this.startBTN.Size = new System.Drawing.Size(75, 23);
            this.startBTN.TabIndex = 0;
            this.startBTN.Text = "Играть";
            this.startBTN.UseVisualStyleBackColor = true;
            this.startBTN.Click += new System.EventHandler(this.startBTN_Click_1);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 459);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.scoreDisplay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Title";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainWindow_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreDisplay;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.TextBox nickName;
        private System.Windows.Forms.Button exitBTN;
        private System.Windows.Forms.ListBox scoreList;
        private System.Windows.Forms.Button startBTN;
        private System.Windows.Forms.Label stateLabel;
    }
}

