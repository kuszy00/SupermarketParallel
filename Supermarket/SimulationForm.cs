using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
#pragma warning disable SYSLIB0006

namespace Supermarket
{
    public partial class SimulationForm : Form
    {
        //Zasoby dzielone
        //Ekran (wyświetlenie symulacji)             
        private int maxClientCount = 1; //zmienna przechowująca aktualną liczbę klientów       
        private int[] currentCheckout = new int[20]; //obecna kasa
        private List<List<Client>> queues; //lista klientów w kolejkach do kas
              
        private int numberOfCheckouts; //liczba kas w supermarkecie
        private int numberOfClients; //maksymalna liczba klientów w supermarkecie
        private int clientNumber = 1; //numeracja klientów
        private int[] checkout_break = new int[20]; //która kasa ma mieć przerwę
        private List<CheckoutControl> checkouts; //lista kas
        private List<RichTextBox> queueTextBoxes; //wyświetlanie kolejki
        private List<Thread> productsScanning; //wątek pracy kas
        private List<Thread> checkoutList; //wątek generowania klientów
        private Semaphore[] sem_queue; //semafor blokujący generowanie klientów w trakcie przerwy kasy

        public SimulationForm(int checkouts, int clients)
        {
            InitializeComponent();
            this.numberOfCheckouts = checkouts; //liczba kas w supermarkecie
            this.numberOfClients = clients; //maksymalna liczba klientów w supermarkecie

            InitializeVisualisation();
            InitializeSimulation();
        }

        private void InitializeVisualisation()
        {
            checkouts = new List<CheckoutControl>();
            queueTextBoxes = new List<RichTextBox>();
            for (int i = 0; i < numberOfCheckouts; i++)
            {
                CheckoutControl c = new CheckoutControl(i + 1);
                c.Location = new Point(i * 150, 5);
                this.Controls.Add(c);
                checkouts.Add(c);
                if (i == numberOfCheckouts - 1)
                {
                    this.Size = new Size((i + 1) * 155, 280);
                }
                RichTextBox rtb = new RichTextBox();
                rtb.Size = new Size(144, 80);
                rtb.Location = new Point(2 + i * 150, 150);
                this.Controls.Add(rtb);
                queueTextBoxes.Add(rtb);
            }
        }

        private void InitializeSimulation()
        {
            sem_queue = new Semaphore[numberOfCheckouts];
            for(int i = 0; i < numberOfCheckouts; i++)
            {
                sem_queue[i] = new Semaphore(1, 1);
            }
            queues = new List<List<Client>>();
            for (int i = 0; i < numberOfCheckouts; i++)
            {
                List<Client> queue = new List<Client>();
                queues.Add(queue);
            }
            checkoutList = new List<Thread>();
            for (int i = 0; i < numberOfCheckouts; i++)
            {
                Thread cl = new Thread(new ParameterizedThreadStart(GenerateClients));
                cl.Start(i);
                checkoutList.Add(cl);
            }
          
            productsScanning = new List<Thread>();
            for (int i = 0; i < numberOfCheckouts; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(ScanningProducts));
                t.Start(i);
                productsScanning.Add(t);
            }
        }

        private void GenerateClients(object queueObject) //generowanie klientow
        {
            int queue = (int)queueObject;
                Random rand = new Random();
                while (true)
                {
                    if (maxClientCount < numberOfClients)
                    {
                        int time = rand.Next(100,1000); //losowy czas generowanie klientów
                        Thread.Sleep(time);
                        if(currentCheckout[queue] == 1) //kasa sygnalizuje przerwę
                        {
                            sem_queue[queue].WaitOne(); //zatrzymania generowania
                            while (currentCheckout[queue] != 0)
                            {; }
                            Thread.Sleep(100);
                            sem_queue[queue].Release(); //wznowienie generowania

                        }                             
                        Client c = new Client(clientNumber);
                        clientNumber++;
                        Thread.Sleep(rand.Next(10,100));                     
                        queues[queue].Add(c);
                        UpdateLabel(queue);                        
                        maxClientCount++;                       
                    }                    
                }

        }

        private delegate void updateLabelDelegate(int queue);
        private void UpdateLabel(int queue) //aktualizacja wypisywania kolejek do kas
        {
            if (queueTextBoxes[queue].InvokeRequired)
            {
                updateLabelDelegate d = new updateLabelDelegate(UpdateLabel);
                this.Invoke(d, new object[] { queue });
            }
            else
            {
                queueTextBoxes[queue].Text = String.Empty;
                queueTextBoxes[queue].ReadOnly = true;
                foreach (Client cli in queues[queue])
                {
                    queueTextBoxes[queue].Text = queueTextBoxes[queue].Text + " " + cli.clientNumber;
                }
                for (int i = 0; i < queueTextBoxes[queue].Text.Length; i++)
                {
                    queueTextBoxes[queue].Select(i, i + 1);
                    try
                    {
                        string raw = queueTextBoxes[queue].Text.Substring(i, 1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Exception");
                    }
                    queueTextBoxes[queue].DeselectAll();
                }
            }
        }
        
        private void ScanningProducts(object queueObject) //obsluga kas
        {
            int queue = (int)queueObject;
            Client c;
            Random rand = new Random();
            while (true)
            {               
                if (checkout_break[queue] == 1) //Przerwa pracy kasy
                {                   
                    if (queues[queue].Count != 0)
                    {
                        currentCheckout[queue] = 1;
                        c = queues[queue][0];
                        Thread.Sleep(2000);
                        checkouts[queue].ScanProducts(c);
                        queues[queue].RemoveAt(0);
                        maxClientCount--;
                        UpdateLabel(queue);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        checkouts[queue].Breaks();
                        Thread.Sleep(5000);                      
                        currentCheckout[queue] = 0;
                    }
                }
                else if(checkout_break[queue] == 20) //Zmiana kasjerow
                {
                    if (queues[queue].Count != 0)
                    {
                        currentCheckout[queue] = 1;
                        c = queues[queue][0];
                        Thread.Sleep(2000);
                        checkouts[queue].ScanProducts(c);
                        queues[queue].RemoveAt(0);
                        maxClientCount--;
                        UpdateLabel(queue);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        checkouts[queue].Changes();
                        Thread.Sleep(2000);
                        currentCheckout[queue] = 0;
                    }
                }
                else
                {
                    if (queues[queue].Count != 0)
                    {
                        c = queues[queue][0];
                        Thread.Sleep(2000);
                        checkouts[queue].ScanProducts(c);
                        queues[queue].RemoveAt(0);
                        maxClientCount--;
                        UpdateLabel(queue);
                    }
                    else Thread.Sleep(1);
                }
                checkout_break[queue] = rand.Next(1, 21);
                Thread.Sleep(100);
            }           
        }
        #region
        private void TerminateSimulation()
        {
            foreach (Thread cl in checkoutList)
            {
                cl.Join(1000);
                cl.Interrupt();                              
            }

            foreach (Thread t in productsScanning)
            {
                t.Join(1000);
                t.Interrupt();                                
            }           
        }

        private void SimulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            //TerminateSimulation();            
        }
        #endregion
    }
}