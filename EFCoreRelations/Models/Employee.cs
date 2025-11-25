using System.ComponentModel.DataAnnotations;

namespace EFCoreRelations.Models
{
    internal class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
    
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public int BD_Year { get; set; }
        public int BD_Month { get; set; }
        public int BD_Day { get; set; }

        public  int AirLineId { get; set; }//Fk
        public AirLine EAirline { get; set; } = null!;

    }


}
