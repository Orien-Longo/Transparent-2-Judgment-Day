using UnityEngine;
using System.Collections;

public class WinningCondition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            Application.LoadLevel("HumansWin");

        }

       
    
    }
}
