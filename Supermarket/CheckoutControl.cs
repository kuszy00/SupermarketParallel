using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class CheckoutControl : UserControl
    {
        private int clientNumber;
        private int checkoutId;

        public CheckoutControl(int checkoutID)
        {
            InitializeComponent();
            Checkout_gBox.Text = "Kasa nr " + checkoutID.ToString();
            this.checkoutId = checkoutID;

            initialUpdateControl();
        }

        delegate void updateControlDelegate();
        private void initialUpdateControl()//aktualizacja wypisania stanu kasy
        {
            if (this.richTextBox1.InvokeRequired)
            {
                updateControlDelegate d = new updateControlDelegate(initialUpdateControl);
                this.Invoke(d);
            }
            else
            {
                richTextBox1.Text = String.Empty;
                string appendix = "Kasa jest otwarta\n";
                richTextBox1.AppendText(appendix);
                richTextBox1.Select(richTextBox1.Text.Length - appendix.Length, richTextBox1.Text.Length);
                richTextBox1.DeselectAll();
            }
        }

        private void updateControl()//aktualizacja wypisania stanu kasy
        {
            if (this.richTextBox1.InvokeRequired)
            {
                updateControlDelegate d = new updateControlDelegate(updateControl);
                this.Invoke(d);
            }
            else
            {
                richTextBox1.Text = String.Empty;
                string appendix = "Obsluga klienta nr " + clientNumber + "\n";
                richTextBox1.AppendText(appendix);
                richTextBox1.Select(richTextBox1.Text.Length - appendix.Length, richTextBox1.Text.Length);
                richTextBox1.DeselectAll();
            }
        }

        private void updateControlBreak()//aktualizacja wypisania stanu kasy
        {
            if (this.richTextBox1.InvokeRequired)
            {
                updateControlDelegate d = new updateControlDelegate(updateControlBreak);
                this.Invoke(d);
            }
            else
            {
                richTextBox1.Text = String.Empty;
                string appendix = "Przerwa\n";
                richTextBox1.AppendText(appendix);
                richTextBox1.Select(richTextBox1.Text.Length - appendix.Length, richTextBox1.Text.Length);
                richTextBox1.DeselectAll();
            }
        }

        private void updateControlChange()//aktualizacja wypisania stanu kasy
        {
            if (this.richTextBox1.InvokeRequired)
            {
                updateControlDelegate d = new updateControlDelegate(updateControlChange);
                this.Invoke(d);
            }
            else
            {
                richTextBox1.Text = String.Empty;
                string appendix = "Zmiana kasjerow\n";
                richTextBox1.AppendText(appendix);
                richTextBox1.Select(richTextBox1.Text.Length - appendix.Length, richTextBox1.Text.Length);
                richTextBox1.DeselectAll();
            }
        }

        public void ScanProducts(Client c)
        {
            clientNumber = c.clientNumber;
            updateControl();
        }

        public void Breaks()
        {
            updateControlBreak();
        }

        public void Changes()
        {
            updateControlChange();
        }
    }
}
