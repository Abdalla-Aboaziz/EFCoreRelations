using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelations.Models
{
    internal class AirLine
    {
        public int AirLineId { get; set; }
      
        public string? Name { get; set; }

        public string? Address { get; set; }
        public int Cont_Person { get; set; }

        public ICollection<AirCraft> airCrafts { get; set; } = new HashSet<AirCraft>();

        public ICollection<Transaction> transactions { get; set; } = new HashSet<Transaction>();

        public ICollection<Employee> employees { get; set; }= new HashSet<Employee>();
    }


}
