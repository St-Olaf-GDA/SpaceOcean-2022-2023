using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
