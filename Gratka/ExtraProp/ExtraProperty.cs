namespace Gratka.ExtraProp
{
    public abstract class ExtraProperty
    {
        public string NameOfProp;
        public abstract string GetPropertValue(Advert advert);
    }
}