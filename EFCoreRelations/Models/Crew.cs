using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelations.Models
{
    internal class Crew
    {
       
        public int CrewId { get; set; }
        public string? Maj_Pilot { get; set; }
        public string? Assis_Pilot { get; set; }    
        public string? Host1 { get; set; }
        public string? Host2 { get; set; }

        public AirCraft CAirCraft { get; set; }=null!;

    }
}
