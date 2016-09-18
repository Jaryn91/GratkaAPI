using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratka.ExcelData
{
    public class RentExcelOrder : IGetExcelOrder
    {
        public IList<AdvertProperty> GetOrder()
        {
            return new List<AdvertProperty>()
            {
                new AdvertProperty("Tytul", "Tytuł", 1),
                new AdvertProperty("Ostatnie piętro?", "Ostatnie piętro?", 2),
                new AdvertProperty("Rozkładowe", "Rozkładowe", 3),
                new AdvertProperty("Podtytul", "Podtytuł", 4),
                new AdvertProperty("Cena", "Cena", 5),
                new AdvertProperty("Srednia", "Średnia", 6),
                new AdvertProperty("WolneOd", "Wolne Od", 7),
                new AdvertProperty("NaOkres", "Na okres", 8),
                new AdvertProperty("Powierzchnia", "Powierzchnia", 9),
                new AdvertProperty("Pietro", "Piętro", 10),
                new AdvertProperty("LiczbaPokoi", "Liczba pokoi", 11),
                new AdvertProperty("StanMieszkania", "Stan mieszkania", 12),
                new AdvertProperty("Glosnosc", "Głośność", 13),
                new AdvertProperty("StanInstalacji", "Stan instalacji", 14),
                new AdvertProperty("PowierzchniaDodatkowa", "Powierzchnia dodatkowa", 15),
                new AdvertProperty("TypBudynku", "Typ budynku", 16),
                new AdvertProperty("LiczbaPieter", "Liczba pięter", 17),
                new AdvertProperty("Material", "Materiał", 18),
                new AdvertProperty("RokBudowy", "Rok budowy", 19),
                new AdvertProperty("NumerOferty", "Numer oferty", 20),
                new AdvertProperty("DoplataWProgramieMdm", "Dopłata w programie MdM", 21),
                new AdvertProperty("Kuchnia", "Kuchnia", 22),
                new AdvertProperty("Lazienka", "Łazienka", 23),
                new AdvertProperty("Okna", "Okna", 24),
                new AdvertProperty("Zrodlo", "Źródło", 25),
                new AdvertProperty("Rynek", "Rynek", 26),
                new AdvertProperty("Dodano", "Dodano", 27),
                new AdvertProperty("Aktualizacja", "Aktualizacja", 28),
                new AdvertProperty("LiczbaOdslon", "Liczba odsłon", 29),
                new AdvertProperty("StanLazienki", "Stan łazienki", 30),
                new AdvertProperty("LiczbaPoziomow", "Liczba poziomów", 31),
                new AdvertProperty("UsytuowanieWzglStronSwiata", "Usytuowanie wzgl. stron świata", 32),

            };
        }
    }
}
