﻿namespace Random_Generator
{
    partial class Randomizer
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Randomizer));
            this.btnGen = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.intInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.intInput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGen
            // 
            this.btnGen.BackColor = System.Drawing.Color.Black;
            this.btnGen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGen.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGen.Location = new System.Drawing.Point(12, 53);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(100, 30);
            this.btnGen.TabIndex = 2;
            this.btnGen.Text = "Generate";
            this.btnGen.UseVisualStyleBackColor = false;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            this.btnGen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Randomizer_KeyDown);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(152, 14);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(42, 20);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "■■■";
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Black;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMin.Location = new System.Drawing.Point(160, 53);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(30, 30);
            this.btnMin.TabIndex = 4;
            this.btnMin.Text = "_";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            this.btnMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Randomizer_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(196, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Randomizer_KeyDown);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Black;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHelp.Location = new System.Drawing.Point(124, 53);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 30);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            this.btnHelp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Randomizer_KeyDown);
            // 
            // intInput
            // 
            this.intInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.intInput.Location = new System.Drawing.Point(12, 17);
            this.intInput.Maximum = new decimal(new int[] {
            2147483646,
            0,
            0,
            0});
            this.intInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intInput.Name = "intInput";
            this.intInput.Size = new System.Drawing.Size(100, 20);
            this.intInput.TabIndex = 0;
            this.intInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.intInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Randomizer_KeyDown);
            // 
            // Randomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(238, 93);
            this.Controls.Add(this.intInput);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnGen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Randomizer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Randomizer_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.intInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.NumericUpDown intInput;
    }
}

