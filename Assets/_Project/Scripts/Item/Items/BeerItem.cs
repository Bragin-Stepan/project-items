using System.Collections;
using UnityEngine;

public class BeerItem : Item
{
    [SerializeField] private float _healthModifier;

    private const string ModifierName = "Beer";

    public override void Use(CharacterStats stats)
    {
        base.Use(stats);
        stats.Health.AddModifier(_healthModifier, ModifierName);

        Execute();
    }
}
