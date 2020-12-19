using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public string itemType;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
