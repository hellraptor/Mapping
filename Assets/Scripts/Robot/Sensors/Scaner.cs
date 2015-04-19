using UnityEngine;
using System.Collections;

public class Scaner : MonoBehaviour
{

    public float viewingAngle;
    public float resolution;
    int rayCount;
    public float detectionDistance;
    public Transform rayPattern;

    // Use this for initialization
    void Start()
    {
        rayCount = (int)(viewingAngle / resolution);
        //for (int i = 0; i < rayCount; i++)
        //{
        //    float rayDirection = (-viewingAngle * 0.5f) + (i * resolution);
        //    Transform ray = (Transform)Instantiate(rayPattern, transform.position, Quaternion.Euler(rayDirection, 0f, 0f));
        //    ray.SetParent(transform);
        //    ray.localScale = Vector3.one;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            Debug.DrawLine(transform.position, hit.point);
        }
    }
}




