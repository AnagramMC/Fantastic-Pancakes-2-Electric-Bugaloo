using UnityEngine;
using System.Collections;

public class ObjectPoolManagement : MonoBehaviour {

    public GameObject[] splats;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < splats.Length; i++)
        {
            splats.SetValue(transform.GetChild(i).gameObject, i);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
