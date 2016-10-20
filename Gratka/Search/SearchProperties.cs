using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gratka.Search.SearchEnum;

namespace Gratka.Search
{
    public class SearchProperties
    {
        public AdvertType AdvertType { get; set; }
        public MarketType MarketType { get; set; }
        public string Localization { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }       
        public int AreaFrom { get; set; }
        public int AreaTo { get; set; }
        public Rooms RoomsFrom { get; set; }
        public Rooms RoomsTo { get; set; }
        public int PriceForMeterFrom { get; set; }
        public int PriceForMeterTo { get; set; }
        public Floors FloorsFrom { get; set; }
        public Floors FloorsTo { get; set; }
        public FloorsInBuilding FloorsInBuildingFrom { get; set; }
        public FloorsInBuilding FloorsInBuildingTo { get; set; }
        public BuildingYear BuildingYearFrom { get; set; }
        public BuildingYear BuildingYearTo { get; set; }
        public List<ExtraArea> ExtraAreas { get; set; }
        public CreationDate CreationDate { get; set; }
        public List<AddedBy> AddedBy { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public SearchProperties()
        {
            ExtraAreas = new List<ExtraArea>();
            AddedBy = new List<AddedBy>();
        }
    }
}
