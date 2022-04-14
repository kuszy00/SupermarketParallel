using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Client
    {
        public int clientNumber { get; set; }
        public DateTime DateCreated { get; private set; }

        public Client(int number)
        {
            clientNumber = number;
            DateCreated = DateTime.Now;
        }
    }
}
