using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gratka.Extension;
using Gratka.Search.SearchEnum;
using Microsoft.Office.Interop.Excel;

namespace Gratka.Search
{
    public class ConstructUrl
    {
        private readonly SearchProperties _searchProperties;
        private readonly StringBuilder _values;
        private readonly StringBuilder _keys;
        private readonly StringBuilder _link;
        public ConstructUrl(SearchProperties searchProperties)
        {
            _searchProperties = searchProperties;
            _link = new StringBuilder();
            _keys = new StringBuilder();
            _values = new StringBuilder();
        }

        public string Create()
        {
            Domain();
            AdvertType();           
            Localization();
            Price();
            CreateDate();
            PriceForMeter();
            Area();
            AddedBy();           
            Room();
            FloorInBulding();
            Floor();            
            ExtraAreas();           
            BuildingYear();
            
            ConcatePropertiesToURL();

            return _link.ToString();
        }

        private void Domain()
        {
            _link.Append(GratkaMainData.Address);
        }

        private void AdvertType()
        {
            switch (_searchProperties.AdvertType)
            {
                case SearchEnum.AdvertType.DoWynajecia:
                     _link.Append("mieszkania-do-wynajecia");
                    break;
                case SearchEnum.AdvertType.Inne:
                    _link.Append("mieszkania-inne");
                    break;
                case SearchEnum.AdvertType.NaSprzedaz:
                     GetMarketType();
                     break;
            }
            _link.Append(@"/lista/");
        }

        private void GetMarketType()
        {
            switch (_searchProperties.MarketType)
            {
                case MarketType.Wszystkie:
                    _link.Append("mieszkania-sprzedam");
                    break;
                case MarketType.RynekPierwotny:
                    _link.Append("deweloperzy-nowe-mieszkania");
                    break;
                case MarketType.RynekWtorny:
                    _link.Append("mieszkania-rynek-wtorny");
                    break;
                case MarketType.WProgramieMdM:
                    _link.Append("mieszkania-dla-mlodych");
                    break;
            }
        }

        private void Localization()
        {
            if (_searchProperties.Localization != null)
            {
                LocalizationContainsOnlyCountyAndCity();
                LocalizationContainsCountyCityDistrict();
            }
            else
            {
                var sb = new StringBuilder();
                sb.Append(",");
                sb.Append(_searchProperties.County);
                AddCommaToLocalizationString(sb, _searchProperties.City);
                sb.Append(_searchProperties.City);
                AddCommaToLocalizationString(sb, _searchProperties.District);
                sb.Append(_searchProperties.District);
                sb.Replace(" ", "_");

                AddDataToURL(sb.ToString(), "lok");
            }
        }

        private void LocalizationContainsCountyCityDistrict()
        {
            if (_searchProperties.Localization.Count(x => x == ',') == 2)
            {
                var localization = _searchProperties.Localization.RemovePolishLetters().ToLower().Replace(", ", ",").Replace(" ","_");
                _values.Append(localization);
                _keys.Append(",dz");
            }
        }

        private void LocalizationContainsOnlyCountyAndCity()
        {
            if (_searchProperties.Localization.Count(x => x == ',') == 1)
            {
                var localization = _searchProperties.Localization.RemovePolishLetters().ToLower().Replace(" ", "");
                _values.Append(localization);
            }
        }

        private void AddCommaToLocalizationString(StringBuilder sb, string nextProperty)
        {
            if (sb.Length > 1 && nextProperty != null)
                sb.Append("%5E_");
        }

        private void Price()
        {
            if (_searchProperties.PriceFrom != 0)
            {
                AddDataToURL(_searchProperties.PriceFrom, "co");
            }
            if (_searchProperties.PriceTo != 0)
            {
                AddDataToURL(_searchProperties.PriceTo, "cd");
            }
        }

        private void PriceForMeter()
        {
            if (_searchProperties.PriceForMeterFrom != 0)
            {
                AddDataToURL(_searchProperties.PriceForMeterFrom, "cmo");
            }
            if (_searchProperties.PriceForMeterTo != 0)
            {
                AddDataToURL(_searchProperties.PriceForMeterTo, "cmd");
            }
        }

        private void Area()
        {
            if (_searchProperties.AreaFrom != 0)
            {
                AddDataToURL(_searchProperties.AreaFrom, "mo");
            }
            if (_searchProperties.AreaTo != 0)
            {
                AddDataToURL(_searchProperties.AreaTo, "md");
            }
        }

        private void Room()
        {
            if ((int)_searchProperties.RoomsFrom != 0)
            {
                AddDataToURL((int)_searchProperties.RoomsFrom, "lpo");
            }
            if ((int)_searchProperties.RoomsTo != 0)
            {
                AddDataToURL((int)_searchProperties.RoomsTo, "lpd");
            }
        }

        private void Floor()
        {
            if ((int)_searchProperties.FloorsFrom != 0)
            {
                AddDataToURL((int)_searchProperties.FloorsFrom, "po");
            }
            if ((int)_searchProperties.FloorsTo != 0)
            {
                AddDataToURL((int)_searchProperties.FloorsTo, "pd");
            }
        }

        private void FloorInBulding()
        {
            if ((int)_searchProperties.FloorsInBuildingFrom != 0)
            {
                AddDataToURL((int)_searchProperties.FloorsInBuildingFrom, "lo");
            }
            if ((int)_searchProperties.FloorsInBuildingTo != 0)
            {
                AddDataToURL((int)_searchProperties.FloorsInBuildingTo, "ld");
            }
        }

        private void BuildingYear()
        {
            if ((int)_searchProperties.BuildingYearFrom != 0)
            {
                AddDataToURL((int)_searchProperties.BuildingYearFrom, "rbo");
            }
            if ((int)_searchProperties.BuildingYearTo != 0)
            {
                AddDataToURL((int)_searchProperties.BuildingYearTo, "rbd");
            }
        }

        private void ExtraAreas()
        {
            if (_searchProperties.ExtraAreas.Count != 0)
            {
                var valuesOfArea = _searchProperties.ExtraAreas.Select(v => (int) v).ToList();
                valuesOfArea.Sort();
                var values = string.Join("_", valuesOfArea);
                AddDataToURL(values, "pod");
            }
        }

        private void AddedBy()
        {
            if (_searchProperties.AddedBy.Count != 0)
            {
                var addedByList = _searchProperties.AddedBy.OrderBy(v => v.GetOrder()).ToList();
                foreach (var addedBy in addedByList)
                {
                    AddDataToURL("on", addedBy.ToString());
                }

            }
        }

        private void CreateDate()
        {
            if (_searchProperties.CreationDate != null)
            {
                AddDataToURL(_searchProperties.CreationDate.ToString(), "od");
            }
        }


        private void AddDataToURL(int value, string keyName)
        {
            _values.Append(",");
            _values.Append(value);
            _keys.Append(",");
            _keys.Append(keyName);
        }

        private void AddDataToURL(string value, string keyName)
        {
            _values.Append(",");
            _values.Append(value);
            _keys.Append(",");
            _keys.Append(keyName);
        }

        private void ConcatePropertiesToURL()
        {
            _link.Append(_values);
            _link.Append(_keys);
            _link.Append(".html");
        }

    }
}
