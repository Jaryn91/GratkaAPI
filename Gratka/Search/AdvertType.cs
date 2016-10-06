using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratka.Search
{
    public enum AdvertType
    {
        NaSprzedaz,
        DoWynajecia,
        Inne

    }

    public class AdvertTypeURLString
    {
        public IDictionary<AdvertType, string> ypeDictionary = new Dictionary<AdvertType, string>
        {
            { AdvertType.NaSprzedaz, "mieszkania-sprzedam" },
            { AdvertType.DoWynajecia, "mieszkania-do-wynajecia" },
            { AdvertType.Inne, "mieszkania-inne" },
        };
    }


}
