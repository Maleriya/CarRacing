using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryView : MonoBehaviour, IInventoryView
{
    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private InventoryItemView[] _itemsView;

    public event Action<IItem> onSelectedItem;
    public event Action<IItem> onDeselectedItem;

    private List<IItem> items = new List<IItem>();

    public void Display(IReadOnlyList<IItem> items)
    {
        _panel.SetActive(true);

        int i = 0;
        foreach (var item in items)
        {
            _itemsView[i].text.text = item.Info.Title;
            _itemsView[i].Id = item.Id;
            _itemsView[i].onClickSelect += SelectedItem;
            _itemsView[i].onClickDeselect += DeselectedItem;
            Debug.Log($"Id item: {item.Id}. Title item: {item.Info.Title}");
            i++;
            this.items.Add(item);
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
        return items.Where(i => i.Id == id).First();
    }

}