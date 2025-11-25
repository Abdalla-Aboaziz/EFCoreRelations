using EFCoreRelations.DataBaseContext;
using EFCoreRelations.Models;
using Microsoft.Identity.Client;

namespace EFCoreRelations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AirLineDbContext context = new AirLineDbContext();
            //a 
            var airline = new AirLine
            {
                Name = "EgyptAir",
                Address = "Cairo",
                Cont_Person = 0,  
            };

            context.AirLines.Add(airline);
            context.SaveChanges();

            //b

            var model01 = new AirCraft
            {
                Model = "Model01",
                Capacity = 180,
                AirLineId = airline.AirLineId
            };

            context.AirCrafts.Add(model01);
            context.SaveChanges();
            //c

            var tr = new Transaction
            {
                Amount = 50000,
                Description = "Tickets",
                Date = DateTime.Now,
                AirLineId = airline.AirLineId
            };

            context.Transactions.Add(tr);
            context.SaveChanges();

            //d
            var employees = context.Employees
                       .Where(e => e.AirLineId == airline.AirLineId)
                       .ToList();
            //e
            var trs = context.Transactions
                 .Where(t => t.AirLineId == airline.AirLineId)
                 .Select(t => new { t.TranactionId, t.Description, t.Amount })
                 .ToList();
            //f
            var totals = context.Employees
                    .GroupBy(e => e.AirLineId)
                    .Select(g => new
                    {
                        AirLineId = g.Key,
                        Count = g.Count()
                    })
                    .ToList();
            //g
            var model01AC = context.AirCrafts
                       .First(a => a.Model == "Model01");

            model01AC.Capacity = 200;

            context.SaveChanges();
            //h
            var old = context.Transactions
                  .Where(t => t.Date.Year < 2020)
                  .ToList();

            context.Transactions.RemoveRange(old);
            context.SaveChanges();
            //i

            var route = new Route
            {
                Origin = "Cairo",
                Destination = 1,   
                Classification = "International",
                Distance = 2400
            };

            context.Routes.Add(route);
            context.SaveChanges();

            //j






        }
    }
}
