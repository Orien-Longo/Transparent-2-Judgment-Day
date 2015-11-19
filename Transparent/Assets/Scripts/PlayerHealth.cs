using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int currentHealth;
    public Slider healthSlider;

    public bool isDead = false;
    public bool damaged;

    public int playerAmt = 0;
    

    


    void Awake()
    {
        //players = new ArrayList[playerAmt];
        health = 100;
        currentHealth = health;
        
    }

    void Start()
    {



    }


    void Update()
    {
        Debug.Log(health);
        //var players = GameObject.FindGameObjectsWithTag("Player");
        playerAmt = GameObject.FindGameObjectsWithTag("Soul").Length;
        //playerAmt = GameObject.FindObjectsOfType<PlayerHealth>().Length;
        //foreach("Player" in tag)
        //playerAmt = players.GetLength(GameObject.FindGameObjectsWithTag("Player"));

        Debug.Log(playerAmt);
    }


    //void OnTriggerEnter(Collider other){
    //	if (other.CompareTag("Glass"))
    //	{
    //		health -= 1;

    //	}
    //}

    public void TakeDamage(int amount)
    {
        
   
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth < health)
        {
            damaged = true;

            if (currentHealth <= 0)
            {
                isDead = true;
                if (isDead)
                {


                   

                    Destroy(this.gameObject);

                    //var players = GameObject.FindGameObjectsWithTag("Player");

                    //playerAmt = players.GetLength(players.Length);

                    //Debug.Log(playerAmt);

                    //for (int i = 0; i < 3;) {
                    //    if (players.GetLength(playerAmt)>1)
                    //    {
                    //        playerAmt++;
                    //        Debug.Log(playerAmt);
                    //    }
                    //}
                    //Death();
                }
                
            }
            

        }
    }

    void Death()
    {
        

        if (isDead)
        {
            
            Application.LoadLevel("LichWins");

        }
    }
}
