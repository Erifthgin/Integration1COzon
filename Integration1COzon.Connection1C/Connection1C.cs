using Integration1COzon.Application.Abstractions.Connection1C;
using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Domanes.Object.Connect1C;
using Integration1COzon.Application.Helpers;

using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using V83;

namespace Integration1COzon.Connection1C
{
    /// <summary>
    /// Класс для подключения к бд 1С
    /// </summary>
    public class Connection1C : IConnection1C
    {
        private static dynamic connection;
        public void Connect1C(string nameServer, string nameDb, string user, string password)
        {
            COMConnector connector = new COMConnector
            {
                PoolCapacity = 30,
                PoolTimeout = 60,
                MaxConnections = 2
            };
            var fromserver = "Srvr=\"" + nameServer + "\";Ref=\"" + nameDb + "\";Usr=\"" + user + "\";Pwd=\"" + password + "\"";
            connection = connector.Connect(fromserver);
        }

        public List<Connect1CData> Get(StorageType storageType)
        {
            dynamic reqBd = connection.NewObject("Запрос");
            reqBd.Текст = $@"
            ВЫБРАТЬ
                СправочникНоменклатура.Ссылка.Наименование,
                СправочникНоменклатура.Ссылка.Артикул,  
                ТоварыНаСкладахОстатки.СтруктурнаяЕдиница.Наименование КАК Склад,
                ЕСТЬNULL(ТоварыНаСкладахОстатки.КоличествоКонечныйОстаток, ""0.00"") КАК КоличествоОстаток
            ИЗ
                Справочник.Номенклатура КАК СправочникНоменклатура
                    ЛЕВОЕ СОЕДИНЕНИЕ РегистрНакопления.ЗапасыНаСкладах.ОстаткиИОбороты(, , Авто, Движения, ) КАК ТоварыНаСкладахОстатки
                    ПО(ТоварыНаСкладахОстатки.Номенклатура = СправочникНоменклатура.Ссылка)
                    ЛЕВОЕ СОЕДИНЕНИЕ РегистрСведений.ЦеныНоменклатуры.СрезПоследних КАК ЦеныНоменклатурыСрезПоследних
                    ПО(ЦеныНоменклатурыСрезПоследних.Номенклатура = СправочникНоменклатура.Ссылка)
            ГДЕ
                Родитель.Родитель.Наименование = ""ИНСтрумеНТЫ дЛя ЮвеЛИРов"" ИЛИ
                Родитель.Родитель.Родитель.Наименование = ""ИНСтрумеНТЫ дЛя ЮвеЛИРов"" ИЛИ
                Родитель.Родитель.Родитель.Родитель.Наименование = ""ИНСтрумеНТЫ дЛя ЮвеЛИРов"" ИЛИ
                Родитель.Родитель.Наименование = ""КАМНИ для ювелирных изделий"" ИЛИ
                Родитель.Родитель.Родитель.Наименование = ""КАМНИ для ювелирных изделий"" И
                Склад = ""{ EnumHelpers.GetEnumMemberAttributeValue(storageType)}""
            ";

            var respBd = reqBd.Выполнить().Выбрать();
            Marshal.Release(Marshal.GetIDispatchForObject(respBd));

            List<Connect1CData> listProd = new List<Connect1CData>();
            while (respBd.Следующий)
            {
                //using (StreamWriter file = new StreamWriter("file.txt", true, Encoding.Default))
                //{
                //    file.WriteLine(respBd.КоличествоОстаток.ToString());
                //}
                listProd.Add(new Connect1CData { Article = respBd.СсылкаАртикул.ToString(), Storage = EnumHelpers.GetEnumMemberAttributeValue(storageType), Count = respBd.КоличествоОстаток.ToString() });
            }
            Marshal.ReleaseComObject(respBd);
            return listProd;
        }
    }
}
