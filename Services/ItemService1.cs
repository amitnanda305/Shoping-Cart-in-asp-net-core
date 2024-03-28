using Mycloth_website.Interfaces;
using Mycloth_website.Models;
using WebApplication1.NewFolder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mycloth_website.Services
{
    public class ItemService1 : IItemService1
    {
        private readonly ApplicationDbContex _dbContext;

        public ItemService1(ApplicationDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MenCategory> GetMenCategory()
        {

            IEnumerable<MenCategory> data = _dbContext.MenCategory;
            return data;
        }
         public IEnumerable<ShoesCategory> GetShoesCategory()
        {

            IEnumerable<ShoesCategory> data = _dbContext.ShoesCategory;
            return data;
        }
        public IEnumerable<WomenCategory> GetWomenCategory()
        {

            IEnumerable<WomenCategory> data = _dbContext.WomenCategory;
            return data;
        }
        public IEnumerable<ElectronicsCategory> GetElectronicsCategory()
        {

            IEnumerable<ElectronicsCategory> data = _dbContext.ElectronicsCategory;
            return data;
        }
        public IEnumerable<FrunitureCategory> GetFrunitureCategory()
        {

            IEnumerable<FrunitureCategory> data = _dbContext.FrunitureCategory;
            return data;
        }
        public IEnumerable<CleaningCategory> GetCleaningCategory()
        {

            IEnumerable<CleaningCategory> data = _dbContext.CleaningCategory;
            return data;
        }
        public IEnumerable<tvCategory> GettvCategory()
        {

            IEnumerable<tvCategory> data = _dbContext.tvCategory;
            return data;
        }
        public IEnumerable<ToysCategory> GetToysCategory()
        {

            IEnumerable<ToysCategory> data = _dbContext.ToysCategory;
            return data;
        }
        public IEnumerable<MobileCategory> GetMobileCategory()
        {

            IEnumerable<MobileCategory> data = _dbContext.MobileCategory;
            return data;
        }

        public IEnumerable<Cart> GetCart()
        {

            IEnumerable<Cart> data = _dbContext.Cart;
            return data;
        }
    }
}
