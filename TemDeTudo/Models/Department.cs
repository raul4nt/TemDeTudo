namespace TemDeTudo.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Seller> Sellers { get; set; } = new List<Seller>();

        public Decimal TotalSales(DateTime initialDate, DateTime endDate)
        {
            return Sellers.Sum(s => s.TotalSales(initialDate, endDate));
        }
    }
}
