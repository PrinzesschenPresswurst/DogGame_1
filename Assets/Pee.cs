using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pee : MonoBehaviour
{
   
    public new ParticleSystem particleSystem1;
    public new ParticleSystem particleSystem2;
    public new ParticleSystem particleSystem3;
    private bool hasWater = false;
    private bool waterFull = false;
    private SpriteRenderer spriteRenderer1;
    private SpriteRenderer spriteRenderer2;
    GameObject objectToDestroy;
    GameObject objectToBurn;
    


    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject peeBar1 = GameObject.FindGameObjectWithTag("peeGauge");
        GameObject peeBar2 = GameObject.FindGameObjectWithTag("peeGauge2");

        if (other.tag == "water")
        {
            Debug.Log("water drank");
            hasWater = true;
            waterFull = true;
            spriteRenderer1 = peeBar1.GetComponent<SpriteRenderer>();
            spriteRenderer1.enabled =true;
            spriteRenderer2 = peeBar2.GetComponent<SpriteRenderer>();
            spriteRenderer2.enabled =true;
        }
        if (other.tag == "PeeSpot" && hasWater && waterFull)
        {
            Debug.Log("pee1");
            PlayPeeAnim();
            spriteRenderer2 = peeBar2.GetComponent<SpriteRenderer>();
            spriteRenderer2.enabled = false;
            waterFull = false;
            objectToDestroy = other.gameObject;
            objectToBurn = other.transform.parent.gameObject;
            DestroyPeeSpot();
            
        }
        
        else if (other.tag == "PeeSpot" && hasWater && !waterFull)
        {
            Debug.Log("pee2");
            PlayPeeAnim();
            hasWater = false;
            spriteRenderer1 = peeBar1.GetComponent<SpriteRenderer>();
            spriteRenderer1.enabled = false;
            waterFull = false;
            objectToDestroy = other.gameObject;
            objectToBurn = other.transform.parent.gameObject;
            DestroyPeeSpot();
        }

        else if (other.tag == "PeeSpot" && !hasWater)
        {
            Debug.Log("you need to drink first");
        }
        
    }

    void PlayPeeAnim()
    {
        particleSystem1.Play();
        particleSystem2.Play();  
    }
    
    void DestroyPeeSpot()
    {
        Debug.Log("pee spot gets destroyed");
        Destroy(objectToDestroy);
        particleSystem3= objectToBurn.GetComponent<ParticleSystem>();
        particleSystem3.Play();
        Invoke("BurnDownObject", 3f);
    }

    void BurnDownObject()
    {
        Debug.Log("Parent object: " + objectToBurn.name);
        Destroy(objectToBurn);
    }
    
}
