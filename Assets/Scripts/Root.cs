using Game.Controllers;
using Profile;
using Profile.Analytic;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;

    private MainController _mainController;

    [SerializeField]
    private UnityAdsTools _placeForAdsi;

    [SerializeField]
    private InventoryView _inventoryView;

    [SerializeField]
    List<ItemConfig> _itemConfigs;

    private void Awake()
    {
        IAnalyticTools analyticTool = new UnityAnalyticTools();
        PlayerProfileModel playerProfile = new PlayerProfileModel(15f, analyticTool, _placeForAdsi);
        playerProfile.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, playerProfile, _itemConfigs);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
