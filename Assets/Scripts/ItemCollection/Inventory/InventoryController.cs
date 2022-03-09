using Game.Controllers;
using Profile;
using System;
using System.Collections.Generic;

internal class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryView;
    public InventoryController(List<ItemConfig> itemConfigs, IInventoryView inventoryView)
    {
        _inventoryModel =  new InventoryModel();     
        _itemsRepository = new ItemsRepository(itemConfigs);
        _inventoryView = inventoryView;

        _inventoryView.onSelectedItem += _inventoryModel.EquipItem;
        _inventoryView.onDeselectedItem += _inventoryModel.UnequipItem;
    }

    public void HideInventory()
    {
        throw new NotImplementedException();
    }

    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
            _inventoryModel.EquipItem(item);

        var equippedItems = _inventoryModel.GetEquippedItems();
        _inventoryView.Display(equippedItems);
    }
}
