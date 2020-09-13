using UnityEngine;
using System.Collections;

// Add a thrust force to push an object in its current forward
// direction (to simulate a rocket motor, say).
public class roatt : MonoBehaviour
{
    public float thrust=2.0f;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * thrust);
    }
}