using UnityEngine;

[CreateAssetMenu(fileName = "AbilityItemConfig", menuName = "Ability/AbilityItemConfig", order = 0)]
public class AbilityItemConfig : ScriptableObject
{
    [SerializeField]
    private ItemConfig _itemConfig;
    //TODO заменить на вьюшку AbilityView
    [SerializeField]
    private GameObject _view;
    [SerializeField]
    private AbilityType _type;
    [SerializeField]
    private float _value;

    public ItemConfig ItemConfig => _itemConfig;
    public GameObject View => _view;
    public AbilityType Type => _type;
    public float Value => _value;
    public int Id => _itemConfig.id;
}