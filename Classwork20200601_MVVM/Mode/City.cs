using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork20200601_MVVM.Mode
{
    public class City
    {

       
            public int Version { get; set; }
            public string Key { get; set; }
            public string Type { get; set; }
            public int Rank { get; set; }
            public string LocalizedName { get; set; }
            public Country Country { get; set; }
            public Country AdministrativeArea { get; set; }
        }

        public class Country
        {
            public string ID { get; set; }
            public string LocalizedName { get; set; }
        }

    // Витерли клас Administrativearea
    //public class Administrativearea
    //{
    //    public string ID { get; set; }
    //    public string LocalizedName { get; set; }
    //}


}
