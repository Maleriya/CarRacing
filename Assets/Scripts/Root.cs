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

    [SerializeField]
    List<AbilityItemConfig> _abilityConfigs;

    [SerializeField]
    AbilityCollectionView _abilityCollectionView;

    [SerializeField]
    DailyRewardView _dailyRewardView;

    [SerializeField]
    FightWindowView _fightWindowView;

    [SerializeField]
    CurrencyView _currencyView;

    [SerializeField]
    StartFightView _startFightView;

    private void Awake()
    {
        IAnalyticTools analyticTool = new UnityAnalyticTools();
        PlayerProfileModel playerProfile = new PlayerProfileModel(15f, analyticTool, _placeForAdsi);
        playerProfile.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, playerProfile, _itemConfigs, _inventoryView, _abilityConfigs, _abilityCollectionView,
            _dailyRewardView, _fightWindowView, _currencyView, _startFightView);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
