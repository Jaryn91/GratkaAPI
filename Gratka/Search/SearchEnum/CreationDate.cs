using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratka.Search.SearchEnum
{
    public sealed class CreationDate
    {
        private readonly String name;

        public static readonly CreationDate Dzien = new CreationDate("1d");
        public static readonly CreationDate TrzyDni = new CreationDate("3d");
        public static readonly CreationDate Tydzien = new CreationDate("7d");
        public static readonly CreationDate DwaTygodnie = new CreationDate("`4d");
        public static readonly CreationDate Miesiac = new CreationDate("1m");
        public static readonly CreationDate TrzyMiesiace = new CreationDate("3m");


        private CreationDate(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            return name;
        }

    }
}
