using UnityEngine;
using System.Collections;

public class GlassDamage2 : MonoBehaviour {
    public int attackDamage = 5;
    public GameObject player;
    PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();


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
        if (other.CompareTag("Glass"))
        {
            //player = other.gameObject;
            Attack();
            Destroy(other.gameObject);
        }

    }

    void Attack()
    {

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }

    }
}
