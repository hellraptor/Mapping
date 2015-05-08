using UnityEngine;
using System.Collections;
using Assets.Scripts.Robot.Sensors;
using System.Collections.Generic;

public class Scaner : MonoBehaviour
{

    public float viewingAngle;
    public float resolution;
    int rayCount;
    public float detectionDistance;
    public Transform rayPattern;
    List<Vector3> pointsCloud;
    public GameObject map;
    

    void Start()
    {
        rayCount = (int)(viewingAngle / resolution);
    }

    void Update()
    {
        List <Vector3> pointsCloud = Scan();
        ((BinaryMap)map.GetComponent("BinaryMap")).updateMap(pointsCloud);       
    }

    void OnGUI()
    {
        if (GUI.changed)
        {
            Debug.Log("KPKPKPKK");
        }
    }

    List<Vector3> Scan()
    {
        pointsCloud = new List<Vector3>();
        Vector3 fwd;
        for (float i = (-viewingAngle * 0.5f); i < (viewingAngle * 0.5); i += resolution)
        {
            fwd = calculateDirection(i);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, fwd, out hit, detectionDistance))
            {
                Debug.DrawLine(transform.position, hit.point);
                if (!pointsCloud.Contains(hit.point))
                {
                    pointsCloud.Add(hit.point);
                }
            }
        }
        return pointsCloud;
    }

   

    private Vector3 calculateDirection(float angle)
    {
        Vector3 fwd = Quaternion.AngleAxis(angle, Vector3.up) * transform.TransformDirection(Vector3.forward);
        return fwd;
    }
}




