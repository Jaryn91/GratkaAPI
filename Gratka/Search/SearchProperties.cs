using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int NumberOfRoomsFrom { get; set; }
        public int NumberOfRoomsTo { get; set; }
        public int PriceForMeterFrom { get; set; }
        public int PriceForMeterTo { get; set; }
        public int FloorFrom { get; set; }
        public int FloorTo { get; set; }
        public int FloorsInBuildingFrom { get; set; }
        public int FloorsInBuildingTo { get; set; }
        public int YearOfBuildingFrom { get; set; }
        public int YearOfBuildingTo { get; set; }

    }
}
