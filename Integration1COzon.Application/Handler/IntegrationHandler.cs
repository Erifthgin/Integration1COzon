using Integration1COzon.Application.Abstractions;
using Integration1COzon.Application.Abstractions.Connection1C;
using Integration1COzon.Application.Abstractions.Ozon;
using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Domanes.Object;
using Integration1COzon.Application.Domanes.Requests.Ozon;
using Integration1COzon.Application.Domanes.Responses.Ozon;
using Integration1COzon.Application.Handler.JsonHandlers;
using Integration1COzon.Application.Requests;

using RestSharp;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Integration1COzon.Application.Handler
{
    /// <summary>
    /// Бизнес-логика
    /// </summary>
    public class IntegrationHandler : IIntegrationHandler
    {
        
        private readonly ISingleMessageHandler<ProductStocksByWarehouseFbsResponse> _getProductStocksByWarehouse;
        private readonly ISingleMessageHandler<GetWarehouseListResponse> _getWarehouseListResponse;
        private readonly ISingleMessageHandler<GetProductInfoResopnse> _getProductInfoResopnse;
        private readonly IConnection1C _connection1c;

        private RequestArranger _requestArranger;
        private readonly RestClient _client=new RestClient("https://api-seller.ozon.ru");

        public IntegrationHandler(IOzonHandlerFactory ozonFactory, IConnection1C connection1c)
        {
            _getWarehouseListResponse = ozonFactory.CreateGetWarehouseListResponse();
            _getProductInfoResopnse = ozonFactory.CreateGetProductInfoResopnse();
            _getProductStocksByWarehouse = ozonFactory.CreateProductStocksByWarehouseFbsResponse();
            _connection1c = connection1c;
             _requestArranger = new RequestArranger(_apiKey, _apiClientId,_host);
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
                            Console.WriteLine(item.Article + " Название склада " + item.Storage + " Количество на складе " + item.Count + "  СкладОзон  " + items.Present);
                        }
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Вывод списка товаров со склада
        /// </summary>
        /// <param name="storageType"></param>
        /// <returns></returns>
        public List<IntegrationData> Handle(StorageType storageType)
        {
            _connection1c.Connect1C(_nameServer, _nameDb, _user, _password);
            var listProd = _connection1c.Get(storageType);
            var list = new List<IntegrationData>();
            foreach (var item in listProd)
            {
                var respProductInfo = _getProductInfoResopnse.HandleSingle(SendTest(new GetProductInfoRequest(item.Article)));
                if (respProductInfo.Result == null)
                {
                    //list.Add(new IntegrationData { Article=item.Article,Storage=item.Storage,Count1C=item.Count});
                    continue;
                }
                var respProductStocks = _getProductStocksByWarehouse.HandleSingle(SendTest(new ProductStocksByWarehouseFbsRequest(respProductInfo.Result.FbsSku)));
                //using (StreamWriter file = new StreamWriter("file.txt", true, Encoding.Default))
                //{
                //    file.WriteLine(SendTest(new ProductStocksByWarehouseFbsRequest(respProductInfo.Result.FbsSku)));
                //}
                foreach (var items in respProductStocks.Result)
                {
                    try
                    {
                        if (respProductStocks.Result == null)
                        {
                            list.Add(new IntegrationData { Article = item.Article, Storage = item.Storage, Count1C = item.Count});
                            continue;
                        }
                        if (storageType == StorageType.PgJeweler)
                        {
                            if (items.WarehouseName.Contains("Полигонная"))
                            {
                                list.Add(new IntegrationData { Article = item.Article, Storage = item.Storage, Count1C = item.Count, Name = respProductInfo.Result.Name, CountOzon = items.Present });
                            }
                        }
                        else
                        {
                            if (!items.WarehouseName.Contains("Полигонная"))
                            {
                                list.Add(new IntegrationData { Article = item.Article, Storage = item.Storage, Count1C = item.Count, Name = respProductInfo.Result.Name, CountOzon = items.Present });
                            }
                        }
                    }
                    catch { }
                }
            }
            return list;
        }

        /// <summary>
        /// Обновление товаров на складе Озон
        /// </summary>
        /// <param name="storageType"></param>
        public void Update(StorageType storageType)
        {
            _connection1c.Connect1C(_nameServer, _nameDb, _user, _password);
            var listProd = _connection1c.Get(storageType);
            foreach (var item in listProd)
            {
                var respProductInfo = _getProductInfoResopnse.HandleSingle(SendTest(new GetProductInfoRequest(item.Article)));
                if (respProductInfo.Result == null)
                {
                    continue;
                }
                var respProductStocks = _getProductStocksByWarehouse.HandleSingle(SendTest(new ProductStocksByWarehouseFbsRequest(respProductInfo.Result.FbsSku)));
                foreach (var items in respProductStocks.Result)
                {
                    try
                    {
                        if (respProductStocks.Result == null)
                        {
                            continue;
                        }
                        if (storageType == StorageType.PgJeweler)
                        {
                            if (items.WarehouseName.Contains("Полигонная"))
                            {
                                try
                                {
                                    var updateProd = SendTest(new UpdateProductsStocksRequest(respProductInfo.Result.Offerid, items.ProductId, item.Count, items.WarehouseId));
                                    using (StreamWriter file = new StreamWriter("file.txt", true, Encoding.Default))
                                    {
                                        file.WriteLine(updateProd);
                                    }
                                    //Thread.Sleep(800);
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            if (!items.WarehouseName.Contains("Полигонная"))
                            {
                                try
                                {
                                    var updateProd = SendTest(new UpdateProductsStocksRequest(respProductInfo.Result.Offerid, items.ProductId, item.Count, items.WarehouseId));
                                    using (StreamWriter file = new StreamWriter("file.txt", true, Encoding.Default))
                                    {
                                        file.WriteLine(updateProd);
                                    }
                                    //Thread.Sleep(800);
                                }
                                catch { }
                            }
                        }
                    }
                    catch { }
                }
            }
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
