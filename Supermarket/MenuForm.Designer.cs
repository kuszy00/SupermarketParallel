
namespace Supermarket
{
    partial class MenuForm
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
            this.numUD_clients = new System.Windows.Forms.NumericUpDown();
            this.numUD_checkouts = new System.Windows.Forms.NumericUpDown();
            this.lbl_checkouts = new System.Windows.Forms.Label();
            this.lbl_clients = new System.Windows.Forms.Label();
            this.btn_start_sim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_clients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_checkouts)).BeginInit();
            this.SuspendLayout();
            // 
            // numUD_clients
            // 
            this.numUD_clients.Location = new System.Drawing.Point(222, 66);
            this.numUD_clients.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_clients.Name = "numUD_clients";
            this.numUD_clients.Size = new System.Drawing.Size(120, 23);
            this.numUD_clients.TabIndex = 1;
            this.numUD_clients.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numUD_checkouts
            // 
            this.numUD_checkouts.Location = new System.Drawing.Point(222, 25);
            this.numUD_checkouts.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD_checkouts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_checkouts.Name = "numUD_checkouts";
            this.numUD_checkouts.Size = new System.Drawing.Size(120, 23);
            this.numUD_checkouts.TabIndex = 2;
            this.numUD_checkouts.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lbl_checkouts
            // 
            this.lbl_checkouts.AutoSize = true;
            this.lbl_checkouts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_checkouts.Location = new System.Drawing.Point(129, 25);
            this.lbl_checkouts.Name = "lbl_checkouts";
            this.lbl_checkouts.Size = new System.Drawing.Size(73, 19);
            this.lbl_checkouts.TabIndex = 3;
            this.lbl_checkouts.Text = "Liczba kas:";
            // 
            // lbl_clients
            // 
            this.lbl_clients.AutoSize = true;
            this.lbl_clients.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_clients.Location = new System.Drawing.Point(21, 66);
            this.lbl_clients.Name = "lbl_clients";
            this.lbl_clients.Size = new System.Drawing.Size(181, 19);
            this.lbl_clients.TabIndex = 4;
            this.lbl_clients.Text = "Maksymalna liczba klientów:";
            // 
            // btn_start_sim
            // 
            this.btn_start_sim.Location = new System.Drawing.Point(222, 121);
            this.btn_start_sim.Name = "btn_start_sim";
            this.btn_start_sim.Size = new System.Drawing.Size(120, 23);
            this.btn_start_sim.TabIndex = 5;
            this.btn_start_sim.Text = "Start symulacji";
            this.btn_start_sim.UseVisualStyleBackColor = true;
            this.btn_start_sim.Click += new System.EventHandler(this.btn_start_sim_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.btn_start_sim);
            this.Controls.Add(this.lbl_clients);
            this.Controls.Add(this.lbl_checkouts);
            this.Controls.Add(this.numUD_checkouts);
            this.Controls.Add(this.numUD_clients);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "MenuForm";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.numUD_clients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_checkouts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numUD_clients;
        private System.Windows.Forms.NumericUpDown numUD_checkouts;
        private System.Windows.Forms.Label lbl_checkouts;
        private System.Windows.Forms.Label lbl_clients;
        private System.Windows.Forms.Button btn_start_sim;
    }
}

