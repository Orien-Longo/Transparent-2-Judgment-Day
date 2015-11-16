using UnityEngine;
using System.Collections;

public class LosingConditions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player1") && other.GetComponent<Collider>().CompareTag("Player2") && other.GetComponent<Collider>().CompareTag("Player3"))
        {
            Application.LoadLevel("LichWins");

        }

       
    
    }
}
