using Game.InputLogic;
using Game.TapeBackGround;
using Profile;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Game.Controllers
{
    internal class GameController : BaseController
    {
        public GameController(PlayerProfileModel profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);

            var carController = new CarController();
            AddController(carController);
        }
    }


}
