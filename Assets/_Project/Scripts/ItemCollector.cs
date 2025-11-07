using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = GetComponentInParent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.gameObject.GetComponent<Item>();

        if (item != null)
            _inventory.TryAddItem(item);
    }
}
