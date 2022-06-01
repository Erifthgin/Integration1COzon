using Integration1COzon.Application.Abstractions.Connection1C;
using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Domanes.Object.Connect1C;
using Integration1COzon.Application.Helpers;

using System.Collections.Generic;

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
	            ЗапасыНаСкладахОстаткиИОбороты.Номенклатура.Артикул,
	            ЗапасыНаСкладахОстаткиИОбороты.СтруктурнаяЕдиница,
	            ЗапасыНаСкладахОстаткиИОбороты.КоличествоКонечныйОстаток
            ИЗ
	            РегистрНакопления.ЗапасыНаСкладах.ОстаткиИОбороты(, , Авто, Движения, ) КАК ЗапасыНаСкладахОстаткиИОбороты
            ГДЕ
	            СтруктурнаяЕдиница.Наименование = ""{EnumHelpers.GetEnumMemberAttributeValue(storageType)}""
            ";

            var respBd = reqBd.Выполнить().Выбрать();
            List<Connect1CData> listProd = new List<Connect1CData>();
            while (respBd.Следующий)
            {
                listProd.Add(new Connect1CData { Article = respBd.Номенклатура.Артикул, Name = respBd.Номенклатура.Наименование, Storage = respBd.СтруктурнаяЕдиница, Count = respBd.КоличествоКонечныйОстаток });
            }
            return listProd;
        }
    }
}
