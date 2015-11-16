using UnityEngine;
using System.Collections;

public class WinningCondition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player1")|| other.GetComponent<Collider>().CompareTag("Player2")|| other.GetComponent<Collider>().CompareTag("Player3"))
        {
            Application.LoadLevel("HumansWin");

        }

       
    
    }
}
