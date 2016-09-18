using System.Collections.Generic;
using HtmlAgilityPack;

namespace Gratka
{
    public class GetAdvertsUrl
    {
        private List<string> _urls;
        private string _sellOrRentOption;

        public GetAdvertsUrl()
        {
            _urls = new List<string>();
        }

        public IList<string> GetUrlsToAdverts(string webUrl)
        {
            _sellOrRentOption = webUrl.Split('/')[3];
            while (webUrl != "")
            {
                var hw = new HtmlWeb();
                var htmlPage = hw.Load(webUrl);
                var nodes = FindNodesWithAdverts(htmlPage);
                foreach (var node in nodes)
                {
                    var url = GetAdvertUrl(node);
                    _urls.Add(url);
                }

                webUrl = GetUrlFromNextPage(htmlPage);
            }
            return _urls;
        }

        private string GetAdvertUrl(HtmlNode node)
        {
            var advertUrl = node.InnerHtml.Split('"');
            var url = GratkaMainData.Address + advertUrl[1].Remove(0, 1);
            return url;
        }

        private HtmlNodeCollection FindNodesWithAdverts(HtmlDocument htmlPage)
        {
            return htmlPage.DocumentNode.SelectNodes("//li[starts-with(@id, 'lista-wiersz-')]");
        } 
 

        private string GetUrlFromNextPage(HtmlDocument htmlPage)
        {
            var nextPageNode = FindNextPageButton(htmlPage);
            if (nextPageNode == null)
                return "";
            
            return ConcatNextPageUrl(nextPageNode);
        }

        private HtmlNodeCollection FindNextPageButton(HtmlDocument htmlPage)
        {
            return htmlPage.DocumentNode.SelectNodes("//li[@class='stronaNastepna']");
        }

        private string ConcatNextPageUrl(HtmlNodeCollection nextPageNode)
        {
            var nextPageSubUrl = nextPageNode[0].InnerHtml.Split('"');
            var nextPageUrl = GratkaMainData.Address + _sellOrRentOption + @"/lista/" + nextPageSubUrl[5];
            return nextPageUrl;
        }
    }
}
