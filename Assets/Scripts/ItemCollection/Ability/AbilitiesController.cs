using Game.Controllers;
using System.Collections.Generic;
using System.Linq;

internal class AbilitiesController : BaseController
{
    private readonly IAbilityRepository _abilityRepository;
    private readonly IAbilityCollectionView _abilityCollectionView;
    public AbilitiesController(List<AbilityItemConfig> itemConfigs, IAbilityCollectionView abilityCollectionView)
    {
        _abilityRepository = new AbilityItemRepository(itemConfigs);
        _abilityCollectionView = abilityCollectionView;
        _abilityCollectionView.UseRequesed += ApplyAbility;
    }

    private void ApplyAbility(IItem item)
    {
        _abilityRepository.AbilityMapByItemId.First(x => x.Key == item.Id).Value.Apply();
    }
    public void ShowAbilities()
    {
        _abilityCollectionView.Display(_abilityRepository.ItemMapByItemId.Select(kvp => kvp.Value).ToList());
    }

    protected override void OnDispose()
    {
        _abilityCollectionView.UseRequesed -= ApplyAbility;
    }
}
