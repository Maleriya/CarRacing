using Game.Controllers;
using UnityEngine;

public class CurrencyController : BaseController
{
    public CurrencyController(Transform placeForUI, CurrencyView currencyView)
    {
        var currencyViewInstance = GameObject.Instantiate(currencyView, placeForUI);
        AddGameObject(currencyViewInstance.gameObject);
    }
}