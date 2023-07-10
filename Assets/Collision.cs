using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;
    private Color initialColor;
    [SerializeField] float flashtime = 0.1f;
    [SerializeField] private Color flashColor;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
    }

    void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("bop");
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = flashColor;
            Invoke("DelayedAction", flashtime);
        }
        
        private void DelayedAction()
        {
            spriteRenderer.color = initialColor;
            Debug.Log("Delayed action performed");
        }

        
    
}
