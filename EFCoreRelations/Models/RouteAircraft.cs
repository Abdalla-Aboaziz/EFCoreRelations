using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelations.Models
{
    internal class RouteAircraft
    {
        public AirCraft NAirCraft { get; set; } = null!;
        public int AirCraftId { get; set; }



        public Route NRoute { get; set; } = null!;
        public int RouteId { get; set; }



        public int NumOfPassengers { get; set; }
        public decimal Price { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

        public int Duration { get; set; }

    }
}
