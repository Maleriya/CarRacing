using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour, IInventoryItemView, IPointerClickHandler
{
    [SerializeField]
    private Text _text;

    [SerializeField]
    private Image _image;

    private Image _mainImage;

    public int Id;
    public bool isSelect { get; private set; }
    public Text text { get => _text; set => _text = value; }
    public Image image { get => _image; set => _image = value; }

    public event Action<InventoryItemView> onClickSelect;
    public event Action<InventoryItemView> onClickDeselect;

    private void Awake()
    {
        _mainImage = GetComponent<Image>();
        Select();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isSelect)
            Deselect();
        else
            Select();

        Debug.Log("Click");
    }

    private void Select()
    {
        _mainImage.color = Color.yellow;
        isSelect = true;
        onClickSelect?.Invoke(this);
    }

    private void Deselect()
    {
        _mainImage.color = Color.white;
        isSelect = false;
        onClickDeselect?.Invoke(this);
    }
}

