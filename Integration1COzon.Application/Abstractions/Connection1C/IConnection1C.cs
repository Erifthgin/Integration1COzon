using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Domanes.Object.Connect1C;
using System.Collections.Generic;

namespace Integration1COzon.Application.Abstractions.Connection1C
{
    /// <summary>
    /// Интерфейс
    /// </summary>
    public interface IConnection1C
    {
        void Connect1C(string nameServer, string nameDb, string user, string password);
        List<Connect1CData> Get(StorageType storageType);
    }
}
