using System.Collections;
using UnityEngine;

public class FireBallItem : Item
{
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private float _speed = 5f;

    private float _time;
    private bool _isFlying;
    private Vector3 _flyDirection;

    protected override void Update()
    {
        base.Update();

        if (_isFlying)
            FlyingProcess();
    }

    private void FlyingProcess()
    {
        _time += Time.deltaTime;

        transform.position += _flyDirection * _speed * Time.deltaTime;

        if (_time >= _lifeTime)
            Execute();
    }

    public override void Use(CharacterStats stats)
    {
        _flyDirection = Inventory.transform.forward;

        base.Use(stats);

        _isFlying = true;
        _time = 0f;
    }
}
