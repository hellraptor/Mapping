using UnityEngine;
using System.Collections;

public class RayCastEventProcessor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("1111");
    }
}
