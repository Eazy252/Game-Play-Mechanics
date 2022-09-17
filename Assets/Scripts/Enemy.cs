using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRB;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        // this section of code calculate the distance between the player and the enemy
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // The force is applied to the enemy so its moves toward the direction of the player with hope of kicking the player out.
        enemyRB.AddForce(lookDirection* speed);
        
    }
}
