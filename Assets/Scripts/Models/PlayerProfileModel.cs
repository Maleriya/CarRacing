using Profile.Analytic;
using Tools;

namespace Profile
{
    public class PlayerProfileModel
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; }
        public IAdsShower AdsShower { get; }

        public PlayerProfileModel(float speed, IAnalyticTools analyticTools, IAdsShower adsShower)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speed);
            AnalyticTools = analyticTools;
            AdsShower = adsShower;
        }
    }
}
