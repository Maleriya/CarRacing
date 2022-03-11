using UnityEngine;

public class BombAbility : IAbility
{
    private readonly AbilityItemConfig _config;

    public BombAbility(AbilityItemConfig config)
    {
        _config = config;
    }

    public int Id => _config.Id;
    public void Apply()
    {
        var bomb = Object.Instantiate(_config.View);
        var rigitBody = bomb.GetComponent<Rigidbody2D>();
        rigitBody.AddForce(Vector2.right * _config.Value, ForceMode2D.Impulse);
    }
}