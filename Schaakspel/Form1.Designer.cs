namespace Schaakspel
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBord = new System.Windows.Forms.Panel();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblBeurt = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.grpModus = new System.Windows.Forms.GroupBox();
            this.rbVsComputer = new System.Windows.Forms.RadioButton();
            this.rbTweeSpelers = new System.Windows.Forms.RadioButton();
            this.btnNieuwSpel = new System.Windows.Forms.Button();
            this.btnOngedaanMaken = new System.Windows.Forms.Button();
            this.lstGeschiedenis = new System.Windows.Forms.ListBox();
            this.lblGeschiedenis = new System.Windows.Forms.Label();
            this.timerComputer = new System.Windows.Forms.Timer(this.components);
            this.grpModus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBord
            // 
            this.pnlBord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBord.Location = new System.Drawing.Point(20, 20);
            this.pnlBord.Name = "pnlBord";
            this.pnlBord.Size = new System.Drawing.Size(480, 480);
            this.pnlBord.TabIndex = 0;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitel.Location = new System.Drawing.Point(520, 20);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(126, 30);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Schaakspel";
            // 
            // lblBeurt
            // 
            this.lblBeurt.AutoSize = true;
            this.lblBeurt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeurt.Location = new System.Drawing.Point(521, 60);
            this.lblBeurt.Name = "lblBeurt";
            this.lblBeurt.Size = new System.Drawing.Size(161, 21);
            this.lblBeurt.TabIndex = 2;
            this.lblBeurt.Text = "Beurt: Wit (Speler)";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStatus.Location = new System.Drawing.Point(521, 88);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 19);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Spel gestart";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(521, 115);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(117, 17);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "Materiaal score: 0";
            // 
            // grpModus
            // 
            this.grpModus.Controls.Add(this.rbVsComputer);
            this.grpModus.Controls.Add(this.rbTweeSpelers);
            this.grpModus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpModus.Location = new System.Drawing.Point(525, 145);
            this.grpModus.Name = "grpModus";
            this.grpModus.Size = new System.Drawing.Size(200, 75);
            this.grpModus.TabIndex = 5;
            this.grpModus.TabStop = false;
            this.grpModus.Text = "Spelmodus";
            // 
            // rbVsComputer
            // 
            this.rbVsComputer.AutoSize = true;
            this.rbVsComputer.Checked = true;
            this.rbVsComputer.Location = new System.Drawing.Point(15, 22);
            this.rbVsComputer.Name = "rbVsComputer";
            this.rbVsComputer.Size = new System.Drawing.Size(123, 21);
            this.rbVsComputer.TabIndex = 0;
            this.rbVsComputer.TabStop = true;
            this.rbVsComputer.Text = "Tegen Computer";
            this.rbVsComputer.UseVisualStyleBackColor = true;
            // 
            // rbTweeSpelers
            // 
            this.rbTweeSpelers.AutoSize = true;
            this.rbTweeSpelers.Location = new System.Drawing.Point(15, 45);
            this.rbTweeSpelers.Name = "rbTweeSpelers";
            this.rbTweeSpelers.Size = new System.Drawing.Size(107, 21);
            this.rbTweeSpelers.TabIndex = 1;
            this.rbTweeSpelers.Text = "2 Spelers (Lokaal)";
            this.rbTweeSpelers.UseVisualStyleBackColor = true;
            // 
            // btnNieuwSpel
            // 
            this.btnNieuwSpel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNieuwSpel.Location = new System.Drawing.Point(525, 230);
            this.btnNieuwSpel.Name = "btnNieuwSpel";
            this.btnNieuwSpel.Size = new System.Drawing.Size(200, 35);
            this.btnNieuwSpel.TabIndex = 6;
            this.btnNieuwSpel.Text = "Nieuw Spel";
            this.btnNieuwSpel.UseVisualStyleBackColor = true;
            this.btnNieuwSpel.Click += new System.EventHandler(this.btnNieuwSpel_Click);
            // 
            // btnOngedaanMaken
            // 
            this.btnOngedaanMaken.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOngedaanMaken.Location = new System.Drawing.Point(525, 272);
            this.btnOngedaanMaken.Name = "btnOngedaanMaken";
            this.btnOngedaanMaken.Size = new System.Drawing.Size(200, 30);
            this.btnOngedaanMaken.TabIndex = 7;
            this.btnOngedaanMaken.Text = "Zet Terugdraaien";
            this.btnOngedaanMaken.UseVisualStyleBackColor = true;
            this.btnOngedaanMaken.Click += new System.EventHandler(this.btnOngedaanMaken_Click);
            // 
            // lblGeschiedenis
            // 
            this.lblGeschiedenis.AutoSize = true;
            this.lblGeschiedenis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeschiedenis.Location = new System.Drawing.Point(522, 315);
            this.lblGeschiedenis.Name = "lblGeschiedenis";
            this.lblGeschiedenis.Size = new System.Drawing.Size(107, 15);
            this.lblGeschiedenis.TabIndex = 8;
            this.lblGeschiedenis.Text = "Gedane zetten:";
            // 
            // lstGeschiedenis
            // 
            this.lstGeschiedenis.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGeschiedenis.FormattingEnabled = true;
            this.lstGeschiedenis.ItemHeight = 14;
            this.lstGeschiedenis.Location = new System.Drawing.Point(525, 335);
            this.lstGeschiedenis.Name = "lstGeschiedenis";
            this.lstGeschiedenis.Size = new System.Drawing.Size(200, 158);
            this.lstGeschiedenis.TabIndex = 9;
            // 
            // timerComputer
            // 
            this.timerComputer.Interval = 350;
            this.timerComputer.Tick += new System.EventHandler(this.timerComputer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(744, 521);
            this.Controls.Add(this.lstGeschiedenis);
            this.Controls.Add(this.lblGeschiedenis);
            this.Controls.Add(this.btnOngedaanMaken);
            this.Controls.Add(this.btnNieuwSpel);
            this.Controls.Add(this.grpModus);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblBeurt);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.pnlBord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schaakspel - Keuzedeel Verdieping Software";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpModus.ResumeLayout(false);
            this.grpModus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBord;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblBeurt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.GroupBox grpModus;
        private System.Windows.Forms.RadioButton rbVsComputer;
        private System.Windows.Forms.RadioButton rbTweeSpelers;
        private System.Windows.Forms.Button btnNieuwSpel;
        private System.Windows.Forms.Button btnOngedaanMaken;
        private System.Windows.Forms.ListBox lstGeschiedenis;
        private System.Windows.Forms.Label lblGeschiedenis;
        private System.Windows.Forms.Timer timerComputer;
    }
}
