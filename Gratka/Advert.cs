using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Gratka
{
    public class Advert
    {
        public string Tytul { get; set; }
        public string Url { get; set; }
        public string Opis { get; set; }
        public string Podtytul { get; set; }
        public string Cena { get; set; }
        public string Srednia { get; set; }
        public string FormaWlasnosci { get; set; }
        public string Powierzchnia { get; set; }
        public string Pietro { get; set; }
        public string LiczbaPokoi { get; set; }
        public string LiczbaPoziomow { get; set; }
        public string StanMieszkania { get; set; }
        public string Glosnosc { get; set; }
        public string StanInstalacji { get; set; }
        public string PowierzchniaDodatkowa { get; set; }
        public string TypBudynku { get; set; }
        public string LiczbaPieter { get; set; }
        public string Material { get; set; }
        public string RokBudowy { get; set; }
        public string NumerOferty { get; set; }
        public string DoplataWProgramieMdm { get; set; }
        public string Kuchnia { get; set; }
        public string Lazienka { get; set; }
        public string Okna { get; set; }
        public string Zrodlo { get; set; }
        public string Rynek { get; set; }
        public string Dodano { get; set; }
        public string Aktualizacja { get; set; }
        public string LiczbaOdslon { get; set; }
        public string StanLazienki { get; set; }
        public string Kredyt { get; set; }
        public string UsytuowanieWzglStronSwiata { get; set; }
        public string Wykonczenie { get; set; }
        public string WolneOd { get; set; }
        public string NaOkres { get; set; }
        public Dictionary<string, string> ExtraProperties { get; set; }


        public Dictionary<string, string> Properties { get; set; }

        public Advert()
        {
            Properties = new Dictionary<string, string>();
            ExtraProperties = new Dictionary<string, string>();
        }

        public void SaveValuesToProperties()
        {
            var type = this.GetType();
            foreach (var prop in Properties)
            {
                var nameOfProp = GetNameOfProperty(prop.Key);
                type.GetProperty(nameOfProp).SetValue(this, prop.Value);
            }
        }

        private string GetNameOfProperty(string key)
        {
            var noDiacritics = RemoveDiacritics(key);
            var noDot = RemoveDot(noDiacritics);
            var capitalization = BigLetterAfterSpace(noDot);
            var nameOfProperty = RemoveSpaceBetweenWords(capitalization);
            return nameOfProperty;
        }

        private string RemoveDot(string text)
        {
            return text.Replace(".", string.Empty);
        }

        private string RemoveDiacritics(string accentedStr)
        {
            var tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr);
            string asciiStr = Encoding.UTF8.GetString(tempBytes);
            return asciiStr;
        }

        private string BigLetterAfterSpace(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        private string RemoveSpaceBetweenWords(string text)
        {
            return text.Replace(" ", string.Empty);
        }

    }
}
