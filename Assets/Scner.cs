using UnityEngine;
using System.Collections;

public class Scner : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 100))
        {
            print("There is something in front of the object!");
            Debug.DrawRay(fwd, transform.position, Color.green);
        }
    }
}
