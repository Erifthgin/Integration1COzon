using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Domanes.Object;
using System.Collections.Generic;

namespace Integration1COzon.Application.Abstractions
{
    /// <summary>
    /// Интерфейс хендлера
    /// </summary>
    public interface IIntegrationHandler
    {
        void Handle();
        List<IntegrationData> Handle(StorageType storageType);
    }
}
