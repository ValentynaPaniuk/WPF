using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork20200520_Window
{
    [Serializable]
    public class Customer
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }


        public Customer() { }
    }
}
