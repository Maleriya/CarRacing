using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryView : MonoBehaviour, IInventoryView, IDisposable
{
    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private InventoryItemView[] _itemsView;

    public event Action<IItem> onSelectedItem;
    public event Action<IItem> onDeselectedItem;

    private List<IItem> _items = new List<IItem>();

    public void Display(IReadOnlyList<IItem> items)
    {
        _panel.SetActive(true);

        for (int i = 0; i < items.Count; i++)
        {
            _itemsView[i].text.text = items[i].Info.Title;
            _itemsView[i].Id = items[i].Id;
            _itemsView[i].onClickSelect += SelectedItem;
            _itemsView[i].onClickDeselect += DeselectedItem;
            Debug.Log($"Id item: {items[i].Id}. Title item: {items[i].Info.Title}");
            _items.Add(items[i]);
        }
    }

    public void SelectedItem(InventoryItemView item)
    {
        Debug.Log($"Выбран предмет с id {item.Id} {item.text.text}");
        onSelectedItem?.Invoke(FindById(item.Id));
    }

    public void DeselectedItem(InventoryItemView item)
    {
        Debug.Log($"Выбор снят с предмета с id {item.Id} {item.text.text}");
        onDeselectedItem?.Invoke(FindById(item.Id));
    }

    private IItem FindById(int id)
    {
        return _items.First(i => i.Id == id);
    }

    public void Dispose()
    {
        foreach (var item in _itemsView)
        {
            item.onClickSelect -= SelectedItem;
            item.onClickDeselect -= DeselectedItem;
        }
    }
}