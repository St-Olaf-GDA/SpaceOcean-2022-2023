using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laser;
    public GameObject player;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject pew = Instantiate(laser, player.transform.position + new Vector3(0,1,1), Quaternion.identity);
            print("spawn");
            pew.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 20);
        }
    }
}
