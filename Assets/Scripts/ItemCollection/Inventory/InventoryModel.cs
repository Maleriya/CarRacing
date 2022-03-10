using Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class InventoryModel : IInventoryModel
{
    private readonly List<IItem> _items = new List<IItem>();
    private readonly PlayerProfileModel _playerProfile;

    public IReadOnlyList<IItem> GetEquippedItems()
    {
        return _items;
    }
    public void EquipItem(IItem item)
    {
        if (_items.Contains(item))
            return;

        _items.Add(item);

        Debug.Log($"{item.Info.Title} надета");
    }

    public void UnequipItem(IItem item)
    {
        if (!_items.Contains(item))
            return;

        _items.Remove(item);

        Debug.Log($"{item.Info.Title} снята");
    }
}
