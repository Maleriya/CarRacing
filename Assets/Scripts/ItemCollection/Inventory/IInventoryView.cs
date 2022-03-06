using System;
using System.Collections.Generic;

internal interface IInventoryView
{
    void Display(IReadOnlyList<IItem> items);
}

