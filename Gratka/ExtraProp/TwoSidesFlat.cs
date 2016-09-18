namespace Gratka.ExtraProp
{
    public class TwoSidesFlat : ExtraProperty
    {        
        public TwoSidesFlat()
        {
            NameOfProp = "Rozkładowe";
        }

        public override string GetPropertValue(Advert advert)
        {

            if (advert.Opis.Contains("rozkład") || advert.Opis.Contains("dwustron"))
                return "Tak";

            return "Nie";
        }
    }
}
