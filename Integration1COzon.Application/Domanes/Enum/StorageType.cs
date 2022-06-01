using System.Runtime.Serialization;

namespace Integration1COzon.Application.Domanes.Enum
{
    /// <summary>
    /// Список складов
    /// </summary>
    public enum StorageType
    {
        [EnumMember(Value = "СТС склад ювелирных инструментов")]
        CTC,
        [EnumMember(Value = "Товары для ювелиров склад")]
        PgJeweler
    }
}
