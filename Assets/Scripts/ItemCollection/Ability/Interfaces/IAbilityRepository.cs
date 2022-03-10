using System.Collections.Generic;

public interface IAbilityRepository
{
    IReadOnlyDictionary<int, IAbility> AbilityMapByItemId { get; }
    IReadOnlyDictionary<int, IItem> ItemMapByItemId { get; }
}