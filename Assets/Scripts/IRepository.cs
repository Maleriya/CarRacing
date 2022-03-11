using System.Collections.Generic;

public interface IRepository<Tkey, TValue>
{
    IReadOnlyDictionary<Tkey, TValue> AbilityMapByItemId { get; }
}