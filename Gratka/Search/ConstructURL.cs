using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gratka.Search.SearchEnum;
using Microsoft.Office.Interop.Excel;

namespace Gratka.Search
{
    public class ConstructURL
    {
        private SearchProperties _searchProperties;
        private StringBuilder _values;
        private StringBuilder _keys;
        private StringBuilder _link;
        public ConstructURL(SearchProperties searchProperties)
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
            Locatlization();
            Price();
            CreateDate();
            PriceForMeter();
            Area();
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

        private void Locatlization()
        {
            _link.Append(_searchProperties.Localization);
        }

        private void Price()
        {
            if (_searchProperties.PriceFrom != 0)
            {
                AddDateToURL(_searchProperties.PriceFrom, "co");
            }
            if (_searchProperties.PriceTo != 0)
            {
                AddDateToURL(_searchProperties.PriceTo, "cd");
            }
        }

        private void PriceForMeter()
        {
            if (_searchProperties.PriceForMeterFrom != 0)
            {
                AddDateToURL(_searchProperties.PriceForMeterFrom, "cmo");
            }
            if (_searchProperties.PriceForMeterTo != 0)
            {
                AddDateToURL(_searchProperties.PriceForMeterTo, "cmd");
            }
        }

        private void Area()
        {
            if (_searchProperties.AreaFrom != 0)
            {
                AddDateToURL(_searchProperties.AreaFrom, "mo");
            }
            if (_searchProperties.AreaTo != 0)
            {
                AddDateToURL(_searchProperties.AreaTo, "md");
            }
        }

        private void Room()
        {
            if ((int)_searchProperties.RoomsFrom != 0)
            {
                AddDateToURL((int)_searchProperties.RoomsFrom, "lpo");
            }
            if ((int)_searchProperties.RoomsTo != 0)
            {
                AddDateToURL((int)_searchProperties.RoomsTo, "lpd");
            }
        }

        private void Floor()
        {
            if ((int)_searchProperties.FloorsFrom != 0)
            {
                AddDateToURL((int)_searchProperties.FloorsFrom, "po");
            }
            if ((int)_searchProperties.FloorsTo != 0)
            {
                AddDateToURL((int)_searchProperties.FloorsTo, "pd");
            }
        }

        private void FloorInBulding()
        {
            if ((int)_searchProperties.FloorsInBuildingFrom != 0)
            {
                AddDateToURL((int)_searchProperties.FloorsInBuildingFrom, "lo");
            }
            if ((int)_searchProperties.FloorsInBuildingTo != 0)
            {
                AddDateToURL((int)_searchProperties.FloorsInBuildingTo, "ld");
            }
        }

        private void BuildingYear()
        {
            if ((int)_searchProperties.BuildingYearFrom != 0)
            {
                AddDateToURL((int)_searchProperties.BuildingYearFrom, "rbo");
            }
            if ((int)_searchProperties.BuildingYearTo != 0)
            {
                AddDateToURL((int)_searchProperties.BuildingYearTo, "rbd");
            }
        }

        private void ExtraAreas()
        {
            if (_searchProperties.ExtraAreas.Count != 0)
            {
                var valuesOfArea = _searchProperties.ExtraAreas.Select(v => (int) v).ToList();
                valuesOfArea.Sort();
                var values = string.Join("_", valuesOfArea);
                AddDateToURL(values, "pod");
            }
        }

        private void CreateDate()
        {
            if (_searchProperties.CreationDate != null)
            {

                AddDateToURL(_searchProperties.CreationDate.ToString(), "od");
            }
        }


        private void AddDateToURL(int value, string keyName)
        {
            _values.Append(",");
            _values.Append(value);
            _keys.Append(",");
            _keys.Append(keyName);
        }

        private void AddDateToURL(string value, string keyName)
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
