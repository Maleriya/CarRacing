using UnityEngine;

public interface IItem
{
    int Id { get; }
    ItemInfo Info { get; }
    Sprite Sprite { get; }
}

