using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("Camera Follow Options")]
    [SerializeField] GameObject thingToFollow;

    void LateUpdate() 
    {
        transform.position = thingToFollow.transform.position + new Vector3(0f,0f,-10f);
        
    }
}
