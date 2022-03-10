using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityItemView : MonoBehaviour, IInventoryItemView, IPointerClickHandler
{
    [SerializeField]
    private Text _text;

    [SerializeField]
    private Image _image;

    private Image _mainImage;
    private bool isBusy;

    public int Id;
    public Text text { get => _text; set => _text = value; }
    public Image image { get => _image; set => _image = value; }

    public event Action<AbilityItemView> onClick;
    private void Awake()
    {
        _mainImage = GetComponent<Image>();
        isBusy = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isBusy)
        {
            Debug.Log("It's not time yet!");
            return;
        }

        OnBusy();
    }

    private void OnBusy()
    {
        _mainImage.color = Color.red;
        isBusy = true;
        onClick?.Invoke(this);
        Invoke("OffBusy", 0.5f);
    }

    private void OffBusy()
    {
        _mainImage.color = Color.white;
        isBusy = false;
    }
}