using UnityEngine;
using System.Collections;

public class GlassDestroy : MonoBehaviour
{

    public int attackDamage = 5;
    public GameObject player1, player2, player3;
    PlayerHealth playerHealth1, playerHealth2, playerHealth3;

    void Awake()
    {
        playerHealth1 = player1.GetComponent<PlayerHealth>();
        playerHealth2 = player2.GetComponent<PlayerHealth>();
        playerHealth3 = player3.GetComponent<PlayerHealth>();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2") || other.CompareTag("Player3"))
        {
            //player = other.gameObject;
            Attack();
            Destroy(this.gameObject);
        }
    }

    void Attack()
    {

        if (playerHealth1.currentHealth > 0)
        {
            playerHealth1.TakeDamage(attackDamage);
        }
        if (playerHealth2.currentHealth > 0)
        {         
            playerHealth2.TakeDamage(attackDamage);
        }
        if (playerHealth3.currentHealth > 0)
        {                        
            playerHealth3.TakeDamage(attackDamage);
        }
    }
}
