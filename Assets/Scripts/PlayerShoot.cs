using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laser;
    public GameObject player;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static Vector3 cursorWorldPosOnNCP
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.nearClipPlane));
        }
    }

    private static Vector3 cameraToCursor
    {
        get
        {
            return cursorWorldPosOnNCP - Camera.main.transform.position;
        }
    }

    private Vector3 cursorOnTransform
    {
        get
        {
            Vector3 camToTrans = transform.position - Camera.main.transform.position;
            return Camera.main.transform.position +
                cameraToCursor *
                (Vector3.Dot(Camera.main.transform.forward, camToTrans) / Vector3.Dot(Camera.main.transform.forward, cameraToCursor));
        }
    }


    void Update()
    {
        /*Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        Physics.Raycast(rayOrigin, out hitInfo);
        
        Vector3 direction = hitInfo.point - player.transform.position;*/

        if (Input.GetMouseButtonDown(0))
        {
            print("spawn");
            /*Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print(mousePosition);
            Vector3 direction = (mousePosition - transform.position).normalized;
            GameObject pew = Instantiate(laser, player.transform.position, Quaternion.identity);
            pew.GetComponent<Rigidbody>().velocity = direction * speed;*/

            GameObject pew = Instantiate(laser, player.transform.position, Quaternion.identity);
            pew.GetComponent<Rigidbody>().velocity = ((cursorOnTransform - transform.position).normalized + new Vector3(0,0,1)) * speed;
        }

            
        

    }
}
