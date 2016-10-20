using System;
using System.Collections.Generic;
using Gratka.Search;
using Gratka.Search.SearchEnum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GratkaTest
{
    [TestClass]
    public class ConstructUrlTest
    {
        [TestMethod]
        public void BasicURL()
        {
            var search = new SearchProperties();
            search.Localization = "dolnośląskie, Wrocław";
            search.MarketType = MarketType.RynekPierwotny;
            search.AdvertType = AdvertType.NaSprzedaz;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/deweloperzy-nowe-mieszkania/lista/dolnoslaskie,wroclaw.html", url);
        }

        [TestMethod]
        public void CopiedFromLocalizationBoxCityDistrictAndCounty()
        {
            var search = new SearchProperties();
            search.Localization = "dolnośląskie, Wrocław, Stare Miasto";
            search.AdvertType = AdvertType.NaSprzedaz;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,stare_miasto,dz.html", url);
        }

        [TestMethod]
        public void CopiedFromLocalizationBoxCityDistrictAndCountyAndPrice()
        {
            var search = new SearchProperties();
            search.Localization = "dolnośląskie, Wrocław, Stare Miasto";
            search.AdvertType = AdvertType.NaSprzedaz;
            search.PriceFrom = 50000;
            search.PriceTo = 100000;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,stare_miasto,50000,100000,dz,co,cd.html", url);
        }

        [TestMethod]
        public void OnlyCity()
        {
            var search = new SearchProperties();
            search.City= "Wrocław";
            search.AdvertType = AdvertType.NaSprzedaz;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/,,Wrocław,lok.html", url);
        }
        
        [TestMethod]
        public void CityAndDistrict()
        {
            var search = new SearchProperties();
            search.City= "wrocław";
            search.District = "Stare Miasto";
            search.AdvertType = AdvertType.NaSprzedaz;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/,,wrocław%5E_Stare_Miasto,lok.html", url);
        }

        [TestMethod]
        public void CityDistrictAndCounty()
        {
            var search = new SearchProperties();
            search.County = "dolnyśląsk";
            search.City = "wrocław";
            search.District = "Stare Miasto";
            search.AdvertType = AdvertType.NaSprzedaz;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/,,dolnyśląsk%5E_wrocław%5E_Stare_Miasto,lok.html", url);
        }

        [TestMethod]
        public void PriceFromTo()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.RynekPierwotny;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.PriceFrom = 50000;
            search.PriceTo = 100000;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/deweloperzy-nowe-mieszkania/lista/dolnoslaskie,wroclaw,50000,100000,co,cd.html", url);
        }

        [TestMethod]
        public void RoomFromTo()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.RoomsFrom = Rooms.R1;
            search.RoomsTo = Rooms.R3;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,1,3,lpo,lpd.html", url);

        }

        [TestMethod]
        public void FloorFromTo()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.FloorsFrom = Floors.Parter;
            search.FloorsTo = Floors.F6;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,1,7,po,pd.html", url);
        }

        [TestMethod]
        public void FloorsInBuildingFromTo()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.FloorsInBuildingFrom = FloorsInBuilding.F1;
            search.FloorsInBuildingTo = FloorsInBuilding.Powyzej30;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,1,31,lo,ld.html", url);
        }

        [TestMethod]
        public void BuildingYearFromTo()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.BuildingYearFrom = BuildingYear.Lata40;
            search.BuildingYearTo = BuildingYear.Lata70;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,2,5,rbo,rbd.html", url);
        }

        [TestMethod]
        public void PriceForMeterFromTo()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.PriceForMeterFrom = 1000;
            search.PriceForMeterTo = 4002;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,1000,4002,cmo,cmd.html", url);
        }

        [TestMethod]
        public void ExtraStuff()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            var extra = new List<ExtraArea>(){ExtraArea.Balkon, ExtraArea.Strych, ExtraArea.Loggia};
            search.ExtraAreas = extra;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,1_2_7,pod.html", url);
        }

        [TestMethod]
        public void CreateDate()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.CreationDate = CreationDate.TrzyDni;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,3d,od.html", url);
        }

        [TestMethod]
        public void CreatedByTest()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.AddedBy = new List<AddedBy>() {AddedBy.BiuraNieruchomości, AddedBy.Gazety};

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,on,on,zg,za.html", url);
        }

        [TestMethod]
        public void AreaFromToTest()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            search.AreaFrom = 25;
            search.AreaTo = 40;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,25,40,mo,md.html", url);
        }

        [TestMethod]
        public void ComboTest()
        {
            var search = new SearchProperties();
            search.Localization = "dolnoslaskie,wroclaw";
            search.MarketType = MarketType.Wszystkie;
            search.AdvertType = AdvertType.NaSprzedaz;
            var extra = new List<ExtraArea>() { ExtraArea.Balkon, ExtraArea.Strych, ExtraArea.Loggia };
            search.ExtraAreas = extra;
            search.PriceFrom = 50000;
            search.PriceTo = 100000;
            search.RoomsFrom = Rooms.R1;
            search.RoomsTo = Rooms.R3;
            search.FloorsFrom = Floors.Parter;
            search.FloorsTo = Floors.F6;
            search.FloorsInBuildingFrom = FloorsInBuilding.F1;
            search.FloorsInBuildingTo = FloorsInBuilding.Powyzej30;
            search.BuildingYearFrom = BuildingYear.Lata40;
            search.BuildingYearTo = BuildingYear.Lata70;
            search.PriceForMeterFrom = 1000;
            search.PriceForMeterTo = 4002;
            search.CreationDate = CreationDate.Tydzien;
            search.AddedBy = new List<AddedBy>() { AddedBy.OsobyPrywatne, AddedBy.Gazety };
            search.AreaFrom = 35;
            search.AreaTo = 50;

            var construct = new ConstructUrl(search);
            var url = construct.Create();

            Assert.AreEqual("http://dom.gratka.pl/mieszkania-sprzedam/lista/dolnoslaskie,wroclaw,50000,100000,7d,1000,4002,35,50,on,on,1,3,1,31,1,7,1_2_7,2,5,co,cd,od,cmo,cmd,mo,md,zi,zg,lpo,lpd,lo,ld,po,pd,pod,rbo,rbd.html", url);

        }
    }
}
