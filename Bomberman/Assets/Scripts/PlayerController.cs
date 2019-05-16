using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject wall;
    Vector3 zMovement;
    Vector3 xMovement;
    void Start()
    {
        zMovement = new Vector3(0, 0, 1);
        xMovement = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += zMovement * wall.transform.localScale.x;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += zMovement * -wall.transform.localScale.x;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += xMovement * -wall.transform.localScale.x;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += xMovement * wall.transform.localScale.x;
        }
    }
}
