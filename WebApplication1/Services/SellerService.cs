using WebApplication1.Models;
namespace WebApplication1.Services
{
    public class SellerService
    {
        private readonly WebApplication1Context _context;

        public SellerService (WebApplication1Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id) 
        {
            return _context.Seller.First(x => x.Id == id);
        }

        public void Remove(int id) 
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        
        }
    }
}
