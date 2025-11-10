using UnityEngine;

[SelectionBase]
public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 2f;

    public bool IsPickedUp { get; private set; }

    protected ItemVFX VFX { get; private set; }

    protected virtual void Awake()
    {
        VFX = GetComponentInChildren<ItemVFX>();
    }

    private void FixedUpdate()
    {
        if (IsPickedUp == false)
            HorizontalRotate();
    }

    public virtual void PickUp()
    {
        VFX.PickUpEffect();
        IsPickedUp = true;
    }

    public virtual void Destroy()
    {
        VFX.DestroyEffect();
        Destroy(gameObject);
    }

    public virtual void Use(GameObject user) => VFX.UseEffect();

    private void HorizontalRotate() => transform.Rotate(0, _rotateSpeed, 0);
}
