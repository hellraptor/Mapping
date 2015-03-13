using UnityEngine;
using System.Collections;

public class BinaryMap : MonoBehaviour {

    public RectTransform cell;
    public RectTransform mapPanel;
	// Use this for initialization
	void Start () {        
        for (int i=0; i<10; i++)
        {
            ((RectTransform)Instantiate(cell,  new Vector3(i * 2f, 50, 0) , Quaternion.identity)).SetParent(this.transform);            
        }	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
