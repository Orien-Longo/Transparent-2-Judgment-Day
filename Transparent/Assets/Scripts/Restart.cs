using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Application.loadedLevel("LichHunt proto3");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
            Application.LoadLevel("LichHunt proto3");
            Debug.Log("Pressed left click.");

    }
}
