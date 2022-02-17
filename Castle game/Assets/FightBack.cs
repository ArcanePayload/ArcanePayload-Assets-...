using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightBack : MonoBehaviour
{
    public BoxCollider territory;
    GameObject player;
    bool playerInTerritory;

    public GameObject thePlayer;
    BasicEnemy1 basicenemy;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        basicenemy = GetComponent<BasicEnemy1>();
        playerInTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTerritory == true)
        {
            basicenemy.MoveToPlayer(player.transform);
        }

        if (playerInTerritory == false)
        {
            basicenemy.Rest();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTerritory = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTerritory = false;
            player = null;
        }
    }
}

