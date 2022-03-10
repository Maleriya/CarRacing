using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
{
    [SerializeField]
    private AbilityItemView[] _itemsView;

    private IReadOnlyList<IItem> _abilityItems;

    public event Action<IItem> UseRequesed;

    private void OnUseRequested(IItem item)
    {
        UseRequesed?.Invoke(item);
    }
    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        _abilityItems = abilityItems;
        for (int i = 0; i < _abilityItems.Count; i++)
        {
            _itemsView[i].text.text = _abilityItems[i].Info.Title;
            _itemsView[i].image.sprite = _abilityItems[i].Sprite;
            _itemsView[i].Id = _abilityItems[i].Id;
            _itemsView[i].onClick += ClickItem;
        }       
    }
    public void ClickItem(AbilityItemView item)
    {
        Debug.Log($"Выбран предмет с id {item.Id} {item.text.text}");
        OnUseRequested(FindById(item.Id));
    }
    public void Hide()
    {
        
    }

    public void Show()
    {
        
    }

    private IItem FindById(int id)
    {
        return _abilityItems.Where(i => i.Id == id).First();
    }
}