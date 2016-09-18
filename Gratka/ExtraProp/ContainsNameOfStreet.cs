using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratka.ExtraProp
{
    public class ContainsNameOfStreet : ExtraProperty
    {
        private readonly List<string> _streets; 

        public ContainsNameOfStreet(string path)
        {
            NameOfProp = "Nazwa ulicy";
            _streets = new List<string>();

            foreach (var line in File.ReadLines(path))
            {
                _streets.Add(line);
            }
        }

        public override string GetPropertValue(Advert advert)
        {
            var matchingvalues = _streets.Any(stringToCheck => advert.Tytul.ToLower().Contains(stringToCheck.ToLower()));
            if (matchingvalues)
                return "Tak";

            return "Nie";
        }
    }
}
