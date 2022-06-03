using Integration1COzon.Application.Abstractions;
using Integration1COzon.Application.Abstractions.Connection1C;
using Integration1COzon.Application.Abstractions.Ozon;
using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Domanes.Requests.Ozon;
using Integration1COzon.Application.Domanes.Responses.Ozon;
using Integration1COzon.Application.Handler.JsonHandlers;
using Integration1COzon.Application.Requests;

using RestSharp;
using Excel = Microsoft.Office.Interop.Excel;

using System;

namespace Integration1COzon.Application.Handler
{
    /// <summary>
    /// Бизнес-логика
    /// </summary>
    public class IntegrationHandler : IIntegrationHandler
    {
       

        public IntegrationHandler(IOzonHandlerFactory ozonFactory, IConnection1C connection1c)
        {
            _getWarehouseListResponse = ozonFactory.CreateGetWarehouseListResponse();
            _getProductInfoResopnse = ozonFactory.CreateGetProductInfoResopnse();
            _getProductStocksByWarehouse = ozonFactory.CreateProductStocksByWarehouseFbsResponse();
            _connection1c = connection1c;
        }

        public void Handle()
        {
            _connection1c.Connect1C(_nameServer, _nameDb, _user, _password);
            var listProd = _connection1c.Get(StorageType.PgJeweler);
            foreach (var item in listProd)
            {
                var respProductInfo = _getProductInfoResopnse.HandleSingle(SendTest(new GetProductInfoRequest(item.Article)));
                if (respProductInfo.Result == null)
                {
                    continue;
                }
                var respProductStocks = _getProductStocksByWarehouse.HandleSingle(SendTest(new ProductStocksByWarehouseFbsRequest(respProductInfo.Result.FbsSku)));
                //Объявляем приложение
                Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
                //Отобразить Excel
                ex.Visible = true;
                //Количество листов в рабочей книге
                ex.SheetsInNewWorkbook = 2;
                //Добавить рабочую книгу
                Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
                //Отключить отображение окон с сообщениями
                ex.DisplayAlerts = false;
                //Получаем первый лист документа (счет начинается с 1)
                Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
                //Название листа (вкладки снизу)
                sheet.Name = "Отчет за 13.12.2017";
                int i = 1;
                foreach (var items in respProductStocks.Result)
                {
                    try
                    {
                        if (respProductStocks.Result == null)
                        {
                            continue;
                        }
                        if (items.WarehouseName.Contains("Полигонная"))
                        {
                            sheet.Cells[i, 1] = String.Format(item.Article, i, 1);
                            sheet.Cells[i, 2] = String.Format(item.Storage, i, 2);
                            sheet.Cells[i, 3] = String.Format(item.Count, i, 3);
                            sheet.Cells[i, 4] = String.Format(items.Present.ToString(), i, 4);
                            sheet.Cells[i, 5] = String.Format(items.FbsSku.ToString(), i, 5);
                            i++;
                            Console.WriteLine(item.Article + " Название склада " + item.Storage + " Количество на складе " + item.Count + "  СкладОзон  " + items.Present);
                        }
                    }
                    catch { }
                }
                //Захватываем диапазон ячеек
                Excel.Range range1 = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[9, 9]);
                //Шрифт для диапазона
                range1.Cells.Font.Name = "Tahoma";
                //Размер шрифта для диапазона
                range1.Cells.Font.Size = 10;
                //Захватываем другой диапазон ячеек
                Excel.Range range2 = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[9, 2]);
                range2.Cells.Font.Name = "Times New Roman";
                ex.Application.ActiveWorkbook.SaveAs("doc.xlsx", Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }

            //var respWarehouse = _getWarehouseListResponse.HandleSingle(SendTest(new GetWarehouseListRequest()));
            //var respProductInfo = _getProductInfoResopnse.HandleSingle(SendTest(new GetProductInfoRequest(arcticleProduct)));
            //var respProductStocks = _getProductStocksByWarehouse.HandleSingle(SendTest(new ProductStocksByWarehouseFbsRequest(respProductInfo.Result.FbsSku)));

            //var test = SendTest(new ProductStocksByWarehouseFbsRequest(respProductInfo.Result.FbsSku));
            //var fromserver = "Srvr=\"localhost\";Ref=\"SmallBisness\";Usr=\"ХимичОА\";Pwd=\"276555\"";

            //throw new NotImplementedException();
        }

        private string SendTest(AuthRequest payload)
        {
            var request = _requestArranger.Arrange(payload);
            var req = new RestRequest(request.Query, MapRequestMethod(request.Method));

            if (request.Body != null)
            {
                req.RequestFormat = DataFormat.Json;
                req.AddJsonBody(request.Body);
            }

            if (request.Headers != null)
            {
                foreach (var header in request.Headers)
                {
                    req.AddHeader(header.Key, header.Value);
                }
            }
            var result = _client.Execute(req);

            return (result?.Content);
        }

        private static Method MapRequestMethod(RequestMethod method)
        {
            switch (method)
            {
                case RequestMethod.Get:
                    return Method.GET;
                case RequestMethod.Post:
                    return Method.POST;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
