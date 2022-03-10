using System;
using System.Collections.Generic;

public interface IAbilityCollectionView : IView
{
    event Action<IItem> UseRequesed;
    void Display(IReadOnlyList<IItem> abilityItems);
}