using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFCoreRelations.Models
{
    internal class AirCraft
    {
      
        public int AirCraftId { get; set; }

      
        public string? Model { get; set; }
        public int Capacity { get; set; }
      
        public Crew ACrew { get; set; }=null!;


        public int AirLineId { get; set; } //Fk 
        public AirLine AirLine { get; set; } = null!;


        public ICollection<RouteAircraft> ArouteAircraft { get; set;}=new HashSet<RouteAircraft>();




    }


}
