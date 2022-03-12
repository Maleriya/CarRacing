using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    private const string WoodKey = nameof(WoodKey);
    private const string DiamondKey = nameof(DiamondKey);

    public static CurrencyView Instance { get; private set; }

    [SerializeField]
    private TMP_Text _currentCountWood;

    [SerializeField]
    private TMP_Text _currentCountDiamond;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentCountWood.text = GetCurrentCount(WoodKey).ToString();
        _currentCountDiamond.text = GetCurrentCount(DiamondKey).ToString();
    }

    public void AddWood(int value)
    {
        SaveNewCounInPlayerPref(WoodKey, value);
        _currentCountWood.text = GetCurrentCount(WoodKey).ToString();
    }

    public void AddDiamonds(int value)
    {
        SaveNewCounInPlayerPref(DiamondKey, value);
        _currentCountDiamond.text = GetCurrentCount(DiamondKey).ToString();
    }

    private void SaveNewCounInPlayerPref(string key, int value)
    {
        var newCount = GetCurrentCount(key) + value;
        PlayerPrefs.SetInt(key, newCount);
    }

    private int GetCurrentCount(string key)
    {
        return PlayerPrefs.GetInt(key, 0);
    }
}