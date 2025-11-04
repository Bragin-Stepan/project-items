using System.Collections;
using UnityEngine;

public class RotateObject
{
    private Transform _transform;

    public RotateObject(Transform transform)
    {
        _transform = transform;
    }

    public void To(Vector3 direction, float speed = 800f)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = speed * Time.deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }
}
