using System.Collections.Generic;

namespace Gratka.ExcelData
{
    public interface IGetExcelOrder
    {
        IList<AdvertProperty> GetOrder();
    }
}