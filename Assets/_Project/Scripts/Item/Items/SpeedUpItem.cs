using System.Collections;
using UnityEngine;

public class SpeedUpItem : Item
{
    [SerializeField] private float _moveSpeedModifier;

    private const string ModifierKey = "SpeedUpItem";

    public override void Use(GameObject user)
    {
        base.Use(user);

        if (user.TryGetComponent(out CharacterStats stats))
            stats.MoveSpeed.AddModifier(new StatModifier(ModifierKey, _moveSpeedModifier));

        Execute();
    }
}
