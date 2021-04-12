using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Picking up an item");
            Inventory.instance.Add(item);
            Destroy(gameObject);
        }
    }
}
