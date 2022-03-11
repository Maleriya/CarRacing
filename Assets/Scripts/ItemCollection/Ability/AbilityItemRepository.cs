using Game.Controllers;
using System.Collections.Generic;
using UnityEngine;

internal class AbilityItemRepository : BaseController, IAbilityRepository
    {
    public IReadOnlyDictionary<int, IAbility> AbilityMapByItemId => _abilityMapById;
    private Dictionary<int, IAbility> _abilityMapById = new Dictionary<int, IAbility>();
    public IReadOnlyDictionary<int, IItem> ItemMapByItemId => _itemMapById;
    private Dictionary<int, IItem> _itemMapById = new Dictionary<int, IItem>();

    public AbilityItemRepository(List<AbilityItemConfig> abilityItemConfigs)
    {
        PopulateItems(abilityItemConfigs);
        SetAbilityAsItem(abilityItemConfigs);
    }

    private void PopulateItems(List<AbilityItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (_abilityMapById.ContainsKey(config.Id))
                continue;

            var ability = CreateAbility(config);
            _abilityMapById.Add(config.Id, CreateAbility(config));
        }
    }

    private IAbility CreateAbility(AbilityItemConfig config)
    {
        switch (config.Type)
        {
            case AbilityType.Gun:
                return new BombAbility(config);

            default:
                Debug.LogError("Not type Ability");
                return null;
        }
    }

    private void SetAbilityAsItem(List<AbilityItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (_itemMapById.ContainsKey(config.Id))
                continue;

            _itemMapById.Add(config.Id, CreateItem(config.ItemConfig));
        }
    }

    private IItem CreateItem(ItemConfig config)
    {
        return new Item
        {
            Id = config.id,
            Info = new ItemInfo { Title = config.title },
            Sprite = config.sprite           
        };
    }
    protected override void OnDispose()
    {
        _abilityMapById.Clear();
        _itemMapById.Clear();
    }
}

