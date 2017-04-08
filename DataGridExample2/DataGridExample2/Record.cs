using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridExample2
{
    class Record
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Website { get; set; }
        public bool IsBillionaire { get; set; }
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
