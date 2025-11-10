using System.Collections;
using UnityEngine;

public class FireBallItem : Item
{
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private float _speed = 5f;

    private float _time;
    private bool _isFlying;
    private Vector3 _flyDirection;

    private void Update()
    {
        if (_isFlying)
            FlyingProcess();
    }

    private void FlyingProcess()
    {
        _time += Time.deltaTime;

        transform.position += _flyDirection * _speed * Time.deltaTime;

        if (_time >= _lifeTime)
            Destroy();
    }

    public override void Use(GameObject user)
    {
        _flyDirection = user.transform.forward;

        base.Use(user);

        _isFlying = true;
        _time = 0f;
    }
}
