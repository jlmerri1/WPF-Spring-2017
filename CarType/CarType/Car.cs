using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarType
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return string.Format("Make: {0} \n Model: {1} \n Year: {2}", Make, Model, Year);
        }
    }
}
