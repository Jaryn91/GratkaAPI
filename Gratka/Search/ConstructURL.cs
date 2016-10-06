using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratka.Search
{
    public class ConstructURL
    {
        private SearchProperties _searchProperties;
        public ConstructURL(SearchProperties searchProperties)
        {
            _searchProperties = searchProperties;
        }

        public string Create()
        {
            var link = new StringBuilder();
            link.Append(GratkaMainData.Address);
            link.Append(GetAdvertType());
            link.Append(@"/lista/");
            link.Append(_searchProperties.Localization);
            link.Append(ValuesString());
            link.Append(KeyString());
            link.Append(".html");

            return link.ToString();
        }

        private string GetAdvertType()
        {
            switch (_searchProperties.AdvertType)
            {
                case AdvertType.DoWynajecia:
                    return "mieszkania-do-wynajecia";
                case AdvertType.Inne:
                    return "mieszkania-inne";
                case AdvertType.NaSprzedaz:
                    return GetMarketType();                
            }
            return null;
        }

        private string GetMarketType()
        {
            switch (_searchProperties.MarketType)
            {
                case MarketType.Wszystkie:
                    return "mieszkania-sprzedam";
                case MarketType.RynekPierwotny:
                    return "deweloperzy-nowe-mieszkania";
                case MarketType.RynekWtorny:
                    return "mieszkania-rynek-wtorny";
                case MarketType.WProgramieMdM:
                    return "mieszkania-dla-mlodych";
            }
            return null;
        }

        private string ValuesString()
        {
            var sb = new StringBuilder();
            if (_searchProperties.PriceFrom != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.PriceFrom);
            }
            if (_searchProperties.PriceTo != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.PriceTo);
            }
            if (_searchProperties.AreaFrom != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.AreaFrom);
            }
            if (_searchProperties.AreaTo != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.AreaTo);
            }

            if (_searchProperties.NumberOfRoomsFrom != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.NumberOfRoomsFrom);
            }
            if (_searchProperties.NumberOfRoomsTo != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.NumberOfRoomsTo);
            }

            if (_searchProperties.PriceForMeterFrom != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.PriceForMeterFrom);
            }
            if (_searchProperties.PriceForMeterTo != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.PriceForMeterTo);
            }

            if (_searchProperties.FloorFrom != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.FloorFrom);
            }
            if (_searchProperties.FloorTo != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.FloorTo);
            }

            if (_searchProperties.FloorsInBuildingFrom != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.FloorsInBuildingFrom);
            }
            if (_searchProperties.FloorsInBuildingTo != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.FloorsInBuildingTo);
            }

            if (_searchProperties.YearOfBuildingFrom != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.YearOfBuildingFrom);
            }
            if (_searchProperties.YearOfBuildingTo != 0)
            {
                sb.Append(",");
                sb.Append(_searchProperties.YearOfBuildingTo);
            }


            return sb.ToString();
        }

        private string KeyString()
        {
            var sb = new StringBuilder();
            if (_searchProperties.PriceFrom != 0)
            {
                sb.Append(",");
                sb.Append("co");
            }
            if (_searchProperties.PriceTo != 0)
            {
                sb.Append(",");
                sb.Append("cd");
            }
            if (_searchProperties.AreaFrom != 0)
            {
                sb.Append(",");
                sb.Append("mo");
            }
            if (_searchProperties.AreaTo != 0)
            {
                sb.Append(",");
                sb.Append("md");
            }
            if (_searchProperties.NumberOfRoomsFrom != 0)
            {
                sb.Append(",");
                sb.Append("lpo");
            }
            if (_searchProperties.NumberOfRoomsTo != 0)
            {
                sb.Append(",");
                sb.Append("lpd");
            }

            if (_searchProperties.PriceForMeterFrom != 0)
            {
                sb.Append(",");
                sb.Append("cmo");
            }
            if (_searchProperties.PriceForMeterTo != 0)
            {
                sb.Append(",");
                sb.Append("cmd");
            }

            if (_searchProperties.FloorFrom != 0)
            {
                sb.Append(",");
                sb.Append("po");
            }
            if (_searchProperties.FloorTo != 0)
            {
                sb.Append(",");
                sb.Append("pd");
            }

            if (_searchProperties.FloorsInBuildingFrom != 0)
            {
                sb.Append(",");
                sb.Append("lo");
            }
            if (_searchProperties.FloorsInBuildingTo != 0)
            {
                sb.Append(",");
                sb.Append("ld");
            }

            if (_searchProperties.YearOfBuildingFrom != 0)
            {
                sb.Append(",");
                sb.Append("rbo");
            }
            if (_searchProperties.YearOfBuildingTo != 0)
            {
                sb.Append(",");
                sb.Append("rbd");
            }


            return sb.ToString();
        }
      
    }
}
