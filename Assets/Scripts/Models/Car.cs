namespace Profile
{
    public class Car : IUpgradableCar
    {
        #region Fields
        private readonly float _defaultSpeed;
        #endregion

        #region Life cycle
        public Car(float speed)
        {
            Speed = speed;
        }

        #endregion

        #region IUpgradableCar
        public float Speed { get; set; }
        public void Restore()
        {
            Speed = _defaultSpeed;
        }

        #endregion
    }
}