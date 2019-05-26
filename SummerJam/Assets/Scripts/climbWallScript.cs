using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbWallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("YouShouldBeClimbing");
        if (other.attachedRigidbody)
            //other.attachedRigidbody.AddForce(Vector3.up * 0);
            other.attachedRigidbody.velocity = new Vector3(0, -1.0F, 0);
            Physics.gravity = new Vector3(0, -1.0F, 0);
    }
}
