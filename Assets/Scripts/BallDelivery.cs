using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallDelivery : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;
    private new ParticleSystem particleSystem3;
    private Rigidbody2D rb;
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject deactivateThough = GameObject.FindGameObjectWithTag("Tought");
        GameObject playText = GameObject.FindGameObjectWithTag("thanks");
        //
        if (other.tag == "BallGoal" )
        {
            //Debug.Log("ball delivered");
            spriteRenderer = deactivateThough.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
            
            particleSystem3 = playText.GetComponent<ParticleSystem>();
            particleSystem3.Play();
            
            rb = GetComponent<Rigidbody2D>();
            Destroy(rb);
            
            
        }

    }
}
