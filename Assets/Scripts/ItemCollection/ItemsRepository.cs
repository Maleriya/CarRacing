using Game.Controllers;
using System.Collections.Generic;
using UnityEngine;

internal class ItemsRepository : BaseController, IItemsRepository
{
    public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

    #region Life cycle
    public ItemsRepository(List<ItemConfig> upgradeItemConfigs)
    {
        PopulateItems(upgradeItemConfigs);
    }

    protected override void OnDispose()
    {
        _itemsMapById.Clear();
        _itemsMapById = null;
    }
    #endregion

    #region Metods
    private void PopulateItems(List<ItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (_itemsMapById.ContainsKey(config.id))
                continue;

            IItem itemConfig = CreateItem(config);
            _itemsMapById.Add(config.id, itemConfig);
        }
    }

    private IItem CreateItem(ItemConfig config)
    {
        return new Item
        {
            Id = config.id,
            Info = new ItemInfo { Title = config.title }
        };
    }
    #endregion
}

