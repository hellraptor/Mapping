using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class RobotController : MonoBehaviour
{
    public GUIText textInfo;
    float rotationAngle = 0;
    public float rotationSpeed = 1;
    public float moveSpeed = 1;
    public Vector3 position;
    public Transform map;
    public Transform point;
    string collisionCount = "";
    HashSet<ContactPoint> pointsCloud;

    void Start()
    {
        textInfo.text = "Velcome. Info about will bee heare:";
        position = new Vector3(0, 0.5f, 0);
        pointsCloud = new HashSet<ContactPoint>();

    }

    void FixedUpdate()
    {
        UpdateRobotDirection();
        UpdateRobotPosition();
        UpdateGameTextInfo(rotationAngle, 0f);                  
    }

    void UpdateRobotDirection()
    {
        if (rotationAngle > 360 || rotationAngle < -360)
            rotationAngle = 0;
        rotationAngle += Input.GetAxisRaw("Horizontal") * rotationSpeed;
        Quaternion target = Quaternion.Euler(0, rotationAngle, 90);
        transform.rotation = target;
    }

    /**
     * 
     * calls on every collision robot with somthing
     * and writes coordinates of the collision in the 
     * pointsCloud {@code HashSet}
    */
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts [0];   
        pointsCloud.Add(contact);
        collisionCount = pointsCloud.Count().ToString();
    }

    void UpdateRobotPosition()
    {
        float dZ = Mathf.Sin(Mathf.Deg2Rad * rotationAngle) * moveSpeed * Input.GetAxisRaw("Vertical");
        float dX = Mathf.Cos(Mathf.Deg2Rad * rotationAngle) * moveSpeed * Input.GetAxisRaw("Vertical");
        position = new Vector3(position.x + dZ, 0.5f, position.z + dX);
        transform.position = position;
    }

    void UpdateGameTextInfo(float angle, float offset)
    {
        textInfo.text = "";
        textInfo.text += "\nRotation Angle: " + angle.ToString();               
        textInfo.text += "\nPosition: " + position.ToString();  
        textInfo.text += "\nOffset: " + offset.ToString();  
        textInfo.text += "\nX: " + transform.position.x;    
        textInfo.text += "\nZ: " + transform.position.z;  
        textInfo.text += "\nCollision point: " + collisionCount;  

    }
}

