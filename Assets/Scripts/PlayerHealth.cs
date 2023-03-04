using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int playerHealth = 100;
    public GameObject player;

    public void mineExplosion()
    {
        playerHealth -= 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            player.SetActive(false);
        }
    }
}
