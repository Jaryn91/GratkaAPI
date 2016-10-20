using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratka.Search.SearchEnum
{
    public sealed class AddedBy
    {
        private readonly string _name;
        private readonly int _order;

        public static readonly AddedBy BiuraNieruchomości = new AddedBy("za", 3);
        public static readonly AddedBy Gazety = new AddedBy("zg", 2);
        public static readonly AddedBy OsobyPrywatne = new AddedBy("zi", 1);
        public static readonly AddedBy Inne = new AddedBy("zin", 4);


        private AddedBy(string name, int order)
        {
            this._name = name;
            this._order = order;
        }

        public override String ToString()
        {
            return _name;
        }

        public int GetOrder()
        {
            return _order;
        }

    }
}
