using Tools;

namespace Profile
{
    internal class PlayerProfileModel
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }

        public PlayerProfileModel(float speed)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speed);
        }
    }
}
