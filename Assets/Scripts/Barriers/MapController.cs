using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour
{


		public Transform barrier;
		public int  barrierCount = 10;
		public Vector2 mapSize = new Vector2 (20, 20);
		// Use this for initialization
		void Start ()
		{
				for (int i=0; i<barrierCount; i++) {
						Instantiate (barrier, new Vector3 (i * 2.0F, 1, 0), Quaternion.identity);
				}
	
		}

}
