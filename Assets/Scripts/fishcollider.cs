using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishcollider : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth script;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mine")
        {
            script = player.GetComponent<PlayerHealth>();
            script.mineExplosion();
            print("explosion!!!");
        }
        else if (other.tag == "boost")
        {
            player.GetComponent<PlayerMovement>().speed = 10f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
