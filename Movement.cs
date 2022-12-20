using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
 

    [SerializeField] float speed = 6f;
    [SerializeField] float moveSpeedRL = 0.1f;
    [SerializeField] float moveSpeedUD = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float upDownAmount = Input.GetAxis("Vertical") * moveSpeedUD * Time.deltaTime;
        float upRightLeft = Input.GetAxis("Horizontal") * moveSpeedRL * Time.deltaTime;

        transform.Translate(upRightLeft, 0, 0);
        transform.Translate(0, upDownAmount, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "boost")
        {
            Debug.Log("Picked up boost");
            moveSpeedRL = 10f;
            moveSpeedUD = 10f;
            Destroy(collision.gameObject, 0.2f);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeedRL = speed;
        moveSpeedUD = speed;
    }



}
