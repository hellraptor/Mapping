using UnityEngine;
using System.Collections;

public class Scaner : MonoBehaviour
{

    public float viewingAngle;
    public float resolution;
    int rayCount;
    public float detectionDistance;
    public Transform rayPattern;

    void Start()
    {
        rayCount = (int)(viewingAngle / resolution);
    }

    void Update()
    {
        Vector3 fwd;
        for (float i = (-viewingAngle * 0.5f); i < (viewingAngle * 0.5); i += resolution)
        {
            fwd = calculateDirection(i);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, fwd, out hit, 10))
            {
                Debug.DrawLine(transform.position, hit.point);
            }
        }
    }

    private Vector3 calculateDirection(float angle)
    {
        Vector3 fwd = Quaternion.AngleAxis(angle, Vector3.up) * transform.TransformDirection(Vector3.forward);
        return fwd;
    }
}




