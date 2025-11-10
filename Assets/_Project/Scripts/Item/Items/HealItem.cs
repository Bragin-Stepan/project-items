using System.Collections;
using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private float _healthModifier;

    private const string ModifierKey = "HealItem";

    public override void Use(GameObject user)
    {
        base.Use(user);

        if (user.TryGetComponent(out CharacterStats stats))
            stats.Health.AddModifier(new StatModifier(ModifierKey, _healthModifier));

        Destroy();
    }
}
