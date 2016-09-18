
using System.Collections.Generic;
using Gratka.ExcelData;
using Gratka.ExtraProp;

namespace Gratka
{
    class Program
    {
        static IList<Advert> adverts = new List<Advert>();

        private static string strona = "Gratka";

        static void Main(string[] args)
        {
            //var url = "http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,srodmiescie,300000,35,55,2,2,10,4,7,2,dz,cd,mo,md,lpo,lpd,ld,po,pd,pod.html";
            var url = "http://dom.gratka.pl/mieszkania-do-wynajecia/lista/,,dolno%C5%9Bl%C4%85skie%5E_Wroc%C5%82aw%5E_%C5%9Br%C3%B3dmie%C5%9Bcie,lok.html";
            var getAdvertsUrl = new GetAdvertsUrl();
            var advertsUrl = getAdvertsUrl.GetUrlsToAdverts(url);

            var urlToAdvert = new ParseToAdvert();
            adverts = urlToAdvert.ParseCollection(advertsUrl);

            List<ExtraProperty> extraProperty = new List<ExtraProperty> { new TwoSidesFlat(), new LastFloor() };
            var extraProprties = new ExtraProperties(adverts, extraProperty);
            extraProprties.Excecute();

            IGetExcelOrder getExcelOrder = new RentExcelOrder();

            var saveToExcel = new SaveToExcelFile(adverts, getExcelOrder, "d:\\Ogloszenia.xls");
            saveToExcel.FillExcelWorkSheet();
        }
    
    }
}
                                                                                                           