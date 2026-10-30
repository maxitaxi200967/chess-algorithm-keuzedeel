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
            this.pnlBord = new System.Windows.Forms.Panel();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblBeurt = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnNieuwSpel = new System.Windows.Forms.Button();
            this.btnOngedaanMaken = new System.Windows.Forms.Button();
            this.lstGeschiedenis = new System.Windows.Forms.ListBox();
            this.lblGeschiedenis = new System.Windows.Forms.Label();
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
            this.lblBeurt.Size = new System.Drawing.Size(89, 21);
            this.lblBeurt.TabIndex = 2;
            this.lblBeurt.Text = "Beurt: Wit";
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
            // btnNieuwSpel
            // 
            this.btnNieuwSpel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNieuwSpel.Location = new System.Drawing.Point(525, 150);
            this.btnNieuwSpel.Name = "btnNieuwSpel";
            this.btnNieuwSpel.Size = new System.Drawing.Size(200, 35);
            this.btnNieuwSpel.TabIndex = 5;
            this.btnNieuwSpel.Text = "Nieuw Spel";
            this.btnNieuwSpel.UseVisualStyleBackColor = true;
            this.btnNieuwSpel.Click += new System.EventHandler(this.btnNieuwSpel_Click);
            // 
            // btnOngedaanMaken
            // 
            this.btnOngedaanMaken.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOngedaanMaken.Location = new System.Drawing.Point(525, 192);
            this.btnOngedaanMaken.Name = "btnOngedaanMaken";
            this.btnOngedaanMaken.Size = new System.Drawing.Size(200, 30);
            this.btnOngedaanMaken.TabIndex = 6;
            this.btnOngedaanMaken.Text = "Zet Terugdraaien";
            this.btnOngedaanMaken.UseVisualStyleBackColor = true;
            this.btnOngedaanMaken.Click += new System.EventHandler(this.btnOngedaanMaken_Click);
            // 
            // lblGeschiedenis
            // 
            this.lblGeschiedenis.AutoSize = true;
            this.lblGeschiedenis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeschiedenis.Location = new System.Drawing.Point(522, 235);
            this.lblGeschiedenis.Name = "lblGeschiedenis";
            this.lblGeschiedenis.Size = new System.Drawing.Size(107, 15);
            this.lblGeschiedenis.TabIndex = 7;
            this.lblGeschiedenis.Text = "Gedane zetten:";
            // 
            // lstGeschiedenis
            // 
            this.lstGeschiedenis.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGeschiedenis.FormattingEnabled = true;
            this.lstGeschiedenis.ItemHeight = 14;
            this.lstGeschiedenis.Location = new System.Drawing.Point(525, 255);
            this.lstGeschiedenis.Name = "lstGeschiedenis";
            this.lstGeschiedenis.Size = new System.Drawing.Size(200, 242);
            this.lstGeschiedenis.TabIndex = 8;
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBord;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblBeurt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnNieuwSpel;
        private System.Windows.Forms.Button btnOngedaanMaken;
        private System.Windows.Forms.ListBox lstGeschiedenis;
        private System.Windows.Forms.Label lblGeschiedenis;
    }
}
