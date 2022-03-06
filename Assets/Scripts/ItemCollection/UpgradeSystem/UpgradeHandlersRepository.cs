using Game.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class UpgradeHandlersRepository : BaseController
{
    public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;
    private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeCarHandler>();

    #region life cycle

    public UpgradeHandlersRepository(List<UpgradeItemConfig> upgradeItemConfigs)
    {
        PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
    }

    protected override void OnDispose()
    {
        _upgradeItemsMapById.Clear();
        _upgradeItemsMapById = null;
    }
    #endregion

    #region Methods

    private void PopulateItems(
        ref Dictionary<int, IUpgradeCarHandler> upgradeItemsMapById, 
        List<UpgradeItemConfig> upgradeItemConfigs)
    {
        foreach (var config in upgradeItemConfigs)
        {
            if (upgradeItemsMapById.ContainsKey(config.Id))
                continue;

            upgradeItemsMapById.Add(config.Id, CreateHandlerByType(config));
        }
    }

    private IUpgradeCarHandler CreateHandlerByType(UpgradeItemConfig config)
    {
        switch (config.type)
        {
            case UpgradeType.Speed:
                return new SpeedUpgradeCarHandler(config.value);
            default:
                return StubUpgradeCarHandler.Default;
        }
    }

    #endregion
}
