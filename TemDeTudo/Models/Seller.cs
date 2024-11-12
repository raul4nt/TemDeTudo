using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TemDeTudo.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Seller's name")]
        [StringLength(30, ErrorMessage="Max lenght of 30 characters.")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage="Invalid email")]
        public string Email { get; set; }
        [Display(Name= "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        //Orm do EntityFramework não tem suporte para DateOnly, sou obrigado a usar Datetime
        [Range(1400, 50000, ErrorMessage="Out of range")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString="{0:F2}")]
        public Decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Decimal TotalSales (DateTime initialDate, DateTime finalDate)
        {
            return Sales.Where(sr => sr.Date >= initialDate && sr.Date <= finalDate).Sum(sr => sr.Price);
        }


    }
}
