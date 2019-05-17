using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunctionality : MonoBehaviour
{
    const int cantParedes = 2;
    GameObject[] paredes;
    PlayerController ball;
    void Start()
    {
        paredes = new GameObject[cantParedes];
        for(int i=0;i<cantParedes;i++)
        {
            paredes[i] = null;
        }
        ball = GameObject.Find("Sphere").GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        if (paredes[0] != null && paredes[1] != null)
        {
            //if (paredes[0].transform.position.z == paredes[1].transform.position.z)
            //{
            //    float distance0 = paredes[0].transform.position.x - ball.position.x;
            //    float distance1 = paredes[1].transform.position.x - ball.position.x;

            //    if(Mathf.Abs(distance0)> Mathf.Abs(distance1))
            //    {
            //        ball.position = new Vector3(ball.position.x + distance0 - distance1, ball.position.y, ball.position.z);
            //    }

            //    if(Mathf.Abs(distance0) < Mathf.Abs(distance1))
            //    {
            //        ball.position = new Vector3(ball.position.x + distance1 - distance0, ball.position.y, ball.position.z);
            //    }
            //}

            //if (paredes[0].transform.position.x == paredes[1].transform.position.x)
            //{
            //    float distance0 = paredes[0].transform.position.z - ball.position.z;
            //    float distance1 = paredes[1].transform.position.z - ball.position.z;

            //    int dis0 = (int)distance0;
            //    int dis1 = (int)distance1;

            //    if (dis0 != dis1)
            //    {
            //        if (Mathf.Abs(distance0) > Mathf.Abs(distance1))
            //        {
            //            ball.position = new Vector3(ball.position.x, ball.position.y, ball.position.z + dis0 + dis1);
            //        }

            //        if (Mathf.Abs(distance0) < Mathf.Abs(distance1))
            //        {
            //            ball.position = new Vector3(ball.position.x, ball.position.y, ball.position.z + dis1 + dis0);
            //        }
            //    }
            //}
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "NormalWall")
        {
            //for (int i = 0; i < cantParedes; i++)
            //{
            //    if (paredes[i] == null)
            //    {
            //        paredes[i] = col.gameObject;
            //        col.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            //        break;
            //    }
            //}

            if (this.gameObject.name == "ColliderZ")
            {
                ball.move[(int)PlayerController.Moves.up] = false;
                ball.move[(int)PlayerController.Moves.down] = false;
            }

            if (this.gameObject.name == "ColliderX")
            {
                ball.move[(int)PlayerController.Moves.left] = false;
                ball.move[(int)PlayerController.Moves.right] = false;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "NormalWall")
        {
            //for (int i = 0; i < cantParedes; i++)
            //{
            //    if (paredes[i])
            //    {
            //        if (paredes[i].transform.position == col.gameObject.transform.position)
            //        {
            //            paredes[i] = null;
            //            col.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            //            break;
            //        }
            //    }
            //}

            if (this.gameObject.name == "ColliderZ")
            {
                ball.move[(int)PlayerController.Moves.up] =true;
                ball.move[(int)PlayerController.Moves.down] =true;
            }                                               
                                                            
            if (this.gameObject.name == "ColliderX")        
            {                                              
                ball.move[(int)PlayerController.Moves.left] =true;
                ball.move[(int)PlayerController.Moves.right] = true;
            }
        }
    }
}
