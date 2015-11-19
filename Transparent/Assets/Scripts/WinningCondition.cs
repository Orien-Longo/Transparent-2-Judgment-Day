using UnityEngine;
using System.Collections;

public class WinningCondition : MonoBehaviour {

    public int playerAmt = 0;

    void Start () {
        Cursor.visible = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        PlayerCheck();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player1")|| other.GetComponent<Collider>().CompareTag("Player2")|| other.GetComponent<Collider>().CompareTag("Player3"))
        {
            Application.LoadLevel("HumansWin");

        }

       
    
    }
    void PlayerCheck()
    {
        Debug.Log(playerAmt);
        playerAmt = GameObject.FindGameObjectsWithTag("Soul").Length;
        if (playerAmt == 0)
        {
            Application.LoadLevel("LichWins");
        }
    }
}
