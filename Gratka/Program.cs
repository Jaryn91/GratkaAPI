
using System.Collections.Generic;
using Gratka.ExcelData;
using Gratka.ExtraProp;
using Gratka.Search;

namespace Gratka
{
    class Program
    {
        static IList<Advert> adverts = new List<Advert>();

        static void Main(string[] args)
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw,srodmiescie";
            ConstructUrl consturUrl = new ConstructUrl(search);
            var seachPage = consturUrl.Create();
            var getAdvertsUrl = new GetAdvertsUrl();
            var advertsUrl = getAdvertsUrl.GetUrlsToAdverts(seachPage);

            var urlToAdvert = new ParseToAdvert();
            adverts = urlToAdvert.ParseCollection(advertsUrl);

            var pathToFileWithNameOfStreets =
                @"C:\Users\Tomasz\Documents\Visual Studio 2012\Projects\GratkaAPI\Gratka\Address.txt";
            List<ExtraProperty> extraProperty = new List<ExtraProperty> { new TwoSidesFlat(), new LastFloor(), new ContainsNameOfStreet(pathToFileWithNameOfStreets) };
            var extraProprties = new ExtraProperties(adverts, extraProperty);
            extraProprties.Excecute();

            IGetExcelOrder getExcelOrder = new SellExcelOrder();

            var saveToExcel = new SaveToExcelFile(adverts, getExcelOrder, "d:\\Ogloszenia.xls");
            saveToExcel.FillExcelWorkSheet();
        }
    
    }
}
                                                                                                           