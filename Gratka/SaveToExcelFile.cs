using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Gratka.ExcelData;
using Microsoft.Office.Interop.Excel;

namespace Gratka
{
    public class SaveToExcelFile
    {
        private IList<Advert> _adverts;
        private IGetExcelOrder _getExcelOrderOrder;
        private readonly object _misValue = Missing.Value;
        private Workbook _xlWorkBook;
        private Worksheet _xlWorkSheet;
        private Application _xlApp;
        private readonly string _filePath;

        public SaveToExcelFile(IList<Advert> adverts, IGetExcelOrder getExcelOrderOrder, string filePath)
        {
            _adverts = adverts;
            _getExcelOrderOrder = getExcelOrderOrder;
            _filePath = filePath;
            InitNewWorkbook();
        }

        private void InitNewWorkbook()
        {
            _xlApp = new Application();
            _xlWorkBook = _xlApp.Workbooks.Add(_misValue);
            _xlWorkSheet = (Worksheet)_xlWorkBook.Worksheets.Item[1];
        }

        private void CreateLink(Advert advert, int row)
        {
            _xlWorkSheet.Hyperlinks.Add(_xlWorkSheet.Cells[row, 1], advert.Url, Type.Missing, advert.Tytul, advert.Tytul);
        }

        public void FillExcelWorkSheet()
        {           
            FillInHeader();

            var advertType = GetTypeOfAdvert();
            int row = 1;
            
            foreach (var advert in _adverts)
            {
                row++;
                AddAdvertToWorkSheet(row, advert, advertType);
                CreateLink(advert, row);
            }
            SaveAndCloseExcel();
        }

        private Type GetTypeOfAdvert()
        {
            return new Advert().GetType();
        }

        public bool HasProperty(Type obj, string propertyName)
        {
            return obj.GetProperty(propertyName) != null;
        }

        private void AddAdvertToWorkSheet(int row, Advert advert, Type advertType)
        {            
            foreach (var prop in _getExcelOrderOrder.GetOrder())
            {
                if (HasProperty(advertType, prop.NameOfPropertyInClass))
                {
                    var value = (string)advertType.GetProperty(prop.NameOfPropertyInClass).GetValue(advert);
                    if (CheckIfPropertyShouldBeDisplayed(prop))
                    {
                        _xlWorkSheet.Cells[row, prop.PositionInExcel] = value;
                    }
                }
            }

            foreach (var extraProp in advert.ExtraProperties)
            {
                var advertProperty = _getExcelOrderOrder.GetOrder().First(l => l.DisplayInExcel == extraProp.Key);
                if (CheckIfPropertyShouldBeDisplayed(advertProperty))
                {
                    _xlWorkSheet.Cells[row, advertProperty.PositionInExcel] = extraProp.Value;
                }
            }
        }

        private bool CheckIfPropertyShouldBeDisplayed(AdvertProperty prop)
        {
            return prop.PositionInExcel != 0;
        }

        private void FillInHeader()
        {
            foreach (var property in _getExcelOrderOrder.GetOrder())
            {
                _xlWorkSheet.Cells[1, property.PositionInExcel] = property.DisplayInExcel;
            }
        }

        private void SaveAndCloseExcel()
        {
            _xlWorkBook.SaveAs(_filePath, XlFileFormat.xlWorkbookNormal, _misValue, _misValue, _misValue, _misValue, XlSaveAsAccessMode.xlExclusive, _misValue, _misValue, _misValue, _misValue, _misValue);
            _xlWorkBook.Close(true, _misValue, _misValue);
            _xlApp.Quit();
        }

        
    }
}

