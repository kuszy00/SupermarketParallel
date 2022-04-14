
namespace Supermarket
{
    partial class CheckoutControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Checkout_gBox = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Checkout_gBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Checkout_gBox
            // 
            this.Checkout_gBox.Controls.Add(this.richTextBox1);
            this.Checkout_gBox.Location = new System.Drawing.Point(10, 11);
            this.Checkout_gBox.Name = "Checkout_gBox";
            this.Checkout_gBox.Size = new System.Drawing.Size(129, 103);
            this.Checkout_gBox.TabIndex = 0;
            this.Checkout_gBox.TabStop = false;
            this.Checkout_gBox.Text = "Checkout";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(116, 77);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // CheckoutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Checkout_gBox);
            this.Name = "CheckoutControl";
            this.Size = new System.Drawing.Size(148, 114);
            this.Checkout_gBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Checkout_gBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
