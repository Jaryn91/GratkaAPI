namespace Gratka.ExtraProp
{
    public class LastFloor : ExtraProperty
    {
        public LastFloor()
        {
            NameOfProp = "Ostatnie piętro?";
        }

        public override string GetPropertValue(Advert advert)
        {
            if (advert.Pietro == advert.LiczbaPieter)
                return "Tak";

            return "Nie";
        }
    }
}
