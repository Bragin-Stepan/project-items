using System.Collections;
using UnityEngine;

public class SpeedFlaskItem : Item
{
    [SerializeField] private float _moveSpeedModifier;

    private const string ModifierName = "SpeedFlask";

    public override void Use(CharacterStats stats)
    {
        base.Use(stats);
        stats.MoveSpeed.AddModifier(_moveSpeedModifier, ModifierName);

        Execute();
    }
}
