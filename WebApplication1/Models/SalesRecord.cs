using WebApplication1.Models.Enums;

namespace WebApplication1.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amounth { get; set; }
        public SalesStatus Status { get; set; }

        public Seller Seler { get; set; }

        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amounth, SalesStatus status, Seller seler)
        {
            Id = id;
            Date = date;
            Amounth = amounth;
            Status = status;
            Seler = seler;
        }
    }
}
