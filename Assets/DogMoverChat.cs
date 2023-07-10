using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMoverChat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float moveSpeed = 10f;
    public float rotateSpeed = 500f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0,verticalInput * moveSpeed, 0)  * Time.deltaTime;
        Vector3 steering = new Vector3(0,0,horizontalInput * -rotateSpeed)  * Time.deltaTime;
        transform.Translate(movement);
        transform.Rotate(steering);
    }

}
