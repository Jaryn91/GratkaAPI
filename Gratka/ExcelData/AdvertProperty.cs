namespace Gratka.ExcelData
{
    public class AdvertProperty
    {
        public string NameOfPropertyInClass { get; set; }
        public string DisplayInExcel { get; set; }
        public int PositionInExcel { get; set; }

        public AdvertProperty(string nameOfPropertyInClass, string nameOfFiledOnWebsite, int positionInExcel)
        {
            NameOfPropertyInClass = nameOfPropertyInClass;
            DisplayInExcel = nameOfFiledOnWebsite;
            PositionInExcel = positionInExcel;
        }
    }
}
