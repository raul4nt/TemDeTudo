using TemDeTudo.Enums;

namespace TemDeTudo.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
        public SaleStatus Status { get; set; }
        
    }
}
