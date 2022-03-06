using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class InventoryModel : IInventoryModel
{
    private static readonly List<IItem> _emptyColection = new List<IItem>();
    private readonly List<IItem> _items = new List<IItem>();

    public IReadOnlyList<IItem> GetEquippedItems()
    {
        return _items ?? _emptyColection;
    }
    public void EquipItem(IItem item)
    {
        if (_items.Contains(item))
            return;

        _items.Add(item);
    }

    public void UnequipItem(IItem item)
    {
        if (!_items.Contains(item))
            return;

        _items.Remove(item);
    }
}
