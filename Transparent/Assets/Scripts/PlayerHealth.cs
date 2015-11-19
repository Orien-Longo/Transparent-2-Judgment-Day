using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float currentHealth;
    public Slider healthSlider;

    public bool isDead = false;
    public bool damaged;

    public int playerAmt = 0;

    private GameObject healthBar;


    void Awake()
    {
        //players = new ArrayList[playerAmt];
        health = 10;
        currentHealth = health;
        if (gameObject.CompareTag("Player1")) { healthBar = GameObject.Find("HealthBar P1"); }
        if (gameObject.CompareTag("Player2")) { healthBar = GameObject.Find("HealthBar P2"); }
        if (gameObject.CompareTag("Player3")) { healthBar = GameObject.Find("HealthBar P3"); }


    }

    void Start()
    {



    }


    void Update()
    {


    }



    public void TakeDamage(float amount)
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

                    playerAmt = GameObject.FindGameObjectsWithTag("Soul").Length;

                    Debug.Log(playerAmt);

                    if (playerAmt != 1)
                    {
                        Destroy(healthBar);
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        Death();
                    }

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
