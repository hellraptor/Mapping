using UnityEngine;
using System.Collections;

public class BinaryMap : MonoBehaviour {

    public Transform cell;
    public Transform mapPanel;
	// Use this for initialization
	void Start () { 
        Transform a = (Transform)Instantiate(mapPanel);
        a.SetParent(this.transform);   
        a.transform.position = new Vector3(0,0,0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
