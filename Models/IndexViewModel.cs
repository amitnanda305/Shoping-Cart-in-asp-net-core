using Mycloth_website.Lists;

namespace Mycloth_website.Models
{
    public class IndexViewModel
    {
        public PaginatedList<MenCategory> MenItems { get; set; }
        public PaginatedList<WomenCategory> WomenItems { get; set; }
        public PaginatedList<ShoesCategory> ShoesItems { get; set; } = new PaginatedList<ShoesCategory>();

        public PaginatedList<ElectronicsCategory> ElectronicsItems { get; set; } = new PaginatedList<ElectronicsCategory>();
        public PaginatedList<FrunitureCategory> FrunitureItems { get; set; } = new PaginatedList<FrunitureCategory>();
        public PaginatedList<CleaningCategory> CleaningItems { get; set; } = new PaginatedList<CleaningCategory>();
        public PaginatedList<tvCategory> tvItems { get; set; } = new PaginatedList<tvCategory>();
        public PaginatedList<ToysCategory> ToysItems { get; set; } = new PaginatedList<ToysCategory>();
        public PaginatedList<MobileCategory> MobileItems { get; set; } = new PaginatedList<MobileCategory>();

    }
}
