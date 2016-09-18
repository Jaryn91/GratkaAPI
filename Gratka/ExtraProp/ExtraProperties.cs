using System.Collections.Generic;

namespace Gratka.ExtraProp
{
    public class ExtraProperties
    {
        private IList<Advert> _adverts;
        private List<ExtraProperty> _extraProperty;

        public ExtraProperties(IList<Advert> adverts, List<ExtraProperty> extraProperty)
        {
            _adverts = adverts;
            _extraProperty = extraProperty;
        }

        public void Excecute()
        {
            foreach (var extraProp in _extraProperty)
            {
                foreach (var advert in _adverts)
                {
                    var value = extraProp.GetPropertValue(advert);
                    advert.ExtraProperties.Add(extraProp.NameOfProp, value);
                }
            }
        }

    }
}