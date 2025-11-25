using System.ComponentModel.DataAnnotations;

namespace EFCoreRelations.Models
{
    internal class Transaction
    {
      
        [Key]
        public int TranactionId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int AirLineId { get; set; }
        public AirLine TAirLine { get; set; } = null!;


    }
}
