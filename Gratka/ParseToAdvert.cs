using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Gratka
{
    public class ParseToAdvert
    {


        public IList<Advert> ParseCollection(IList<string> urls)
        {
            var adverts = new List<Advert>();
            foreach (var url in urls)
            {
                var advert = Parse(url);
                advert.SaveValuesToProperties();
                adverts.Add(advert);
            }
            return adverts;
        }

        public Advert Parse(string url)
        {
            var advert = new Advert();
            advert.Url = url;
            var hw = new HtmlWeb();
            var htmlPage = hw.Load(url);

            GetAdvertTitles(htmlPage, advert);
            //Section can not exist.
            try
            {
                AddPropFromSectionToAdvert(htmlPage, GratkaMainData.MainInformationCssClass, advert);
            }
            catch
            { }
            try
            {
                AddPropFromSectionToAdvert(htmlPage, GratkaMainData.FlatCssClass, advert);
            }
            catch
            {
            }
            try
            {
                AddPropFromSectionToAdvert(htmlPage, GratkaMainData.BuildingCssClass, advert);
            }
            catch
            {
            }
            try
            {
                AddDescription(htmlPage, advert);
            }
            catch            
            {
                advert.Opis = "";
            }

            try
            {
                GetStatistics(htmlPage, advert);
            }
            catch { }


            return advert;
        }

        private void GetStatistics(HtmlDocument htmlPage, Advert advert)
        {
            var node = htmlPage.DocumentNode.Descendants("ul").First(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("statystyki"));
            var subcollection = node.InnerText.Split('\n');
            foreach (var str in subcollection)
            {
                if (str.Trim() != "")
                {
                    CreatePropSplitByColon(str, advert);
                }
            }
        }

        private void CreatePropSplitByColon(string str, Advert advert)
        {
            var subcollection = str.Split(':');
            var key = subcollection[0].Trim();
            var value = subcollection[1].Trim();
            advert.Properties.Add(key, value);
        }

        private void GetAdvertTitles(HtmlDocument htmlPage, Advert advert)
        {
            var node = htmlPage.DocumentNode.SelectNodes("//div[@class='clearOver clear']")[0];
            var subcollection = node.InnerText.Split('\n');
            advert.Properties.Add(GratkaMainData.Title, subcollection[2].Trim());
            advert.Properties.Add(GratkaMainData.Subtitle, subcollection[5].Trim());
        }

        private void AddDescription(HtmlDocument htmlPage, Advert advert)
        {
            HtmlNode description = GetFirstNodeWithCssClassName(htmlPage, GratkaMainData.DescriptionCssClass);
            advert.Opis = description.InnerText;
        }

        private void AddPropFromSectionToAdvert(HtmlDocument htmlPage, string sectionName, Advert advert)
        {
            var homeInformations = GetFirstNodeWithCssClassName(htmlPage, sectionName);
            var sectionProp = GetSectionProp(homeInformations);
            AddAllPropsFromSectionToAdvert(sectionProp, advert);
            
        }

        private void AddAllPropsFromSectionToAdvert(IEnumerable<HtmlNode> sectionProp, Advert advert)
        {
            foreach (var propNode in sectionProp)
            {
                var prop = CreateProp(propNode);
                if (IsPropIsPrice(prop))
                {
                    AddPricesProp(prop, advert);
                }
                else if (IsPropIsArea(prop))
                {
                    AddSizeOfArea(prop, advert);
                }
                else
                    advert.Properties.Add(prop.Key, prop.Value);
            }
        }

        private bool IsPropIsPrice(KeyValuePair<string, string> prop)
        {
            return prop.Key == GratkaMainData.PriceProp;
        }

        private bool IsPropIsArea(KeyValuePair<string, string> prop)
        {
            return prop.Key == GratkaMainData.Area;
        }

        private void AddSizeOfArea(KeyValuePair<string, string> prop, Advert advert)
        {
            var area = prop.Value.Split('m').ToList();
            var totalArea = area[0].Replace(',', '.').Trim();
            advert.Properties.Add(GratkaMainData.Area, totalArea);
        }

        private void AddPricesProp(KeyValuePair<string, string> priceProp, Advert advert)
        {
            var totalPrice = GetTotalPrice(priceProp);
            advert.Properties.Add(GratkaMainData.PriceProp, totalPrice);

            var average = GetAvgPricePerMeter(priceProp);
            advert.Properties.Add(GratkaMainData.AvgProp, average);
        }


        private string GetTotalPrice(KeyValuePair<string, string> priceProp)
        {
            var subcollection = priceProp.Value.Split('z').ToList();
            subcollection[0] = subcollection[0].Replace(" ", "");
            var totalPrice = subcollection[0].Trim();
            return totalPrice;
        }

        private string GetAvgPricePerMeter(KeyValuePair<string, string> priceProp)
        {
            var subcollection = priceProp.Value.Split('z').ToList();
            var openBracket = subcollection[1].IndexOf("(");
            var average = subcollection[1].Substring(openBracket + 1).Trim().Replace(" ", "");
            return average;
        }

        private KeyValuePair<string, string> CreateProp(HtmlNode propNode)
        {
            var keyAndValue = propNode.InnerText.Split('\n');
            var key = keyAndValue[1].Trim();
            var value = keyAndValue[2].Trim();
            var prop = new KeyValuePair<string, string>(key, value);
            return prop;
        }

        private IEnumerable<HtmlNode> GetSectionProp(HtmlNode homeInformations)
        {
            return homeInformations.ChildNodes[3].ChildNodes.Where(node => node.Name == "li");
        }

        //css class has the same name like section name
        private HtmlNode GetFirstNodeWithCssClassName(HtmlDocument htmlPage, string className)
        {           
            return htmlPage.DocumentNode.SelectNodes("//div[@class='" + className + "']")[0];
        }

    }
}
