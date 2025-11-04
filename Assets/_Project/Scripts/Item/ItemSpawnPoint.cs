using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    public Item Item { get; private set; }

    public bool IsEmpty
    {
        get
        {
            if (Item == null)
                return true;

            if (Item.gameObject == null)
                return true;

            return false;
        }
    }

    public void Occupy(Item item) => Item = item;
}
