using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DogMover : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 10f;
    [SerializeField]
    float steerSpeed = 400f;
    [SerializeField] 
    float fastSpeed = 20f;
    [SerializeField] 
    private float bumpspeed = 10f;

    
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")* steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount );
        transform.Translate(0, moveAmount , 0);
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "treat" )
        {
            Debug.Log("treat picked up");
            Destroy(other.gameObject);
            walkSpeed = fastSpeed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bump"))
        {
            Debug.Log("bumped into something");
            walkSpeed = bumpspeed;
        }
    }

}
