using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemConfig/Item", order = 0)]
public class ItemConfig : ScriptableObject
{
    public int id;
    public string title;
    public Sprite sprite;
}
