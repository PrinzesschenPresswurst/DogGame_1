using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPickup : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool hasStick = false;
    private new ParticleSystem particleSystem4;
    [SerializeField] float destroyTimer = 1;

    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject activateStick = GameObject.FindGameObjectWithTag("CarriedStick");
        GameObject hideStick = GameObject.FindGameObjectWithTag("CarriedStick");
        GameObject stickDeliveredText = GameObject.FindGameObjectWithTag("deliveredStickText");

        if (other.tag == "Stick" && !hasStick)
        {
            Debug.Log("stick picked up");
            Destroy(other.gameObject, destroyTimer);
            spriteRenderer = activateStick.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = true;
            hasStick = true;
        }
        
        else if (other.tag == "Stick" && hasStick)
        {
            Debug.Log("you can only carry 1 stick at a time");
        }

        else if (other.tag == "House" && hasStick)
        {
            Debug.Log("house entered");
            spriteRenderer = hideStick.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
            particleSystem4 = stickDeliveredText.GetComponent<ParticleSystem>();
            particleSystem4.Play();
            hasStick = false;
        }
    }
}
