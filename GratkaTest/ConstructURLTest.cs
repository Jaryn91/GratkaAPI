using System;
using Gratka.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GratkaTest
{
    [TestClass]
    public class ConstructURLTest
    {
        [TestMethod]
        public void BasicURL()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.RynekPierwotny;
            search.AdvertType = AdvertType.NaSprzedaz;

            var construct = new ConstructURL(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/deweloperzy-nowe-mieszkania/lista/dolnoslaskie,wroclaw.html", url);
        }

        [TestMethod]
        public void Price()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.RynekPierwotny;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.PriceFrom = 50000;
            search.PriceTo = 100000;

            var construct = new ConstructURL(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/deweloperzy-nowe-mieszkania/lista/dolnoslaskie,wroclaw,50000,100000,co,cd.html", url);
        }
    }
}
