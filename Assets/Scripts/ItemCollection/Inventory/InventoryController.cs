using Game.Controllers;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryView;
    public InventoryController(List<ItemConfig> itemConfigs)
    {
        _inventoryModel =  new InventoryModel();
        _itemsRepository = new ItemsRepository(itemConfigs);
        _inventoryView = new InventoryView();
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
