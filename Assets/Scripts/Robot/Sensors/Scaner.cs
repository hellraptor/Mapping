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
    List<Vector3> pointCloud;
    

    void Start()
    {
        rayCount = (int)(viewingAngle / resolution);
    }

    void Update()
    {
        pointCloud = new List<Vector3>();
        Vector3 fwd;
        for (float i = (-viewingAngle * 0.5f); i < (viewingAngle * 0.5); i += resolution)
        {
            fwd = calculateDirection(i);
            RaycastHit hit =new RaycastHit();
            if (Physics.Raycast(transform.position, fwd, out hit, 10))
            {
                Debug.DrawLine(transform.position, hit.point);
                if (!pointCloud.Contains(hit.point))
                {
                    pointCloud.Add(hit.point);
                }
            }                        
        }
        
        ((RobotController)transform.parent.GetComponent("RobotController")).mergeCloud(pointCloud);
    }

    private Vector3 calculateDirection(float angle)
    {
        Vector3 fwd = Quaternion.AngleAxis(angle, Vector3.up) * transform.TransformDirection(Vector3.forward);
        return fwd;
    }
}




