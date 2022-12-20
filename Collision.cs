using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool pickedUp = false;

    [SerializeField] Color32 hasFood = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasNoFood = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food" && pickedUp == false)
        {
            Debug.Log("Picked Up Food");
            pickedUp = true;
            Destroy(collision.gameObject, 0.2f);
            spriteRenderer.color = hasFood;
        }

        if (collision.tag == "deliver" && pickedUp == true)
        {
            Debug.Log("Delivered");
            pickedUp = false;
            spriteRenderer.color = hasNoFood;
        }
        
    }
}
