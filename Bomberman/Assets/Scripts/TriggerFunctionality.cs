using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunctionality : MonoBehaviour
{
    const int cantParedes = 2;
    GameObject[] paredes;
    Transform ball;
    PlayerController p;
    void Start()
    {
        paredes = new GameObject[cantParedes];
        for(int i=0;i<cantParedes;i++)
        {
            paredes[i] = null;
        }
        ball = GameObject.Find("Sphere").transform;

        p = ball.GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);

        if (paredes[0] && paredes[1])
        {
            if (paredes[0].gameObject.name == paredes[1].gameObject.name)
            {
                if ((this.gameObject.name == "ColliderZ" && (Mathf.Abs(paredes[0].transform.position.z - paredes[1].transform.position.z) > paredes[0].transform.localScale.z * 2 / 3)) ||
                    (this.gameObject.name == "ColliderX" && (Mathf.Abs(paredes[0].transform.position.x - paredes[1].transform.position.x) > paredes[0].transform.localScale.x * 2 / 3)))
                {
                    if (paredes[0].transform.position.z == paredes[1].transform.position.z)
                    {
                        float distance0 = paredes[0].transform.position.x - ball.position.x;
                        float distance1 = paredes[1].transform.position.x - ball.position.x;

                        if (distance0 != distance1)
                        {
                            if (Mathf.Abs(distance0) > Mathf.Abs(distance1))
                            {
                                ball.position = new Vector3(ball.position.x + (distance0 + distance1) / 2, ball.position.y, ball.position.z);
                            }

                            if (Mathf.Abs(distance0) < Mathf.Abs(distance1))
                            {
                                ball.position = new Vector3(ball.position.x + (distance1 + distance0) / 2, ball.position.y, ball.position.z);
                            }

                            if (this.gameObject.name == "ColliderX")
                            {
                                ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.left] = false;
                                ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.right] = false;
                            }
                        }
                    }

                    if (paredes[0].transform.position.x == paredes[1].transform.position.x)
                    {
                        float distance0 = paredes[0].transform.position.z - ball.position.z;
                        float distance1 = paredes[1].transform.position.z - ball.position.z;

                        if (distance0 != distance1)
                        {
                            if (Mathf.Abs(distance0) > Mathf.Abs(distance1))
                            {
                                ball.position = new Vector3(ball.position.x, ball.position.y, ball.position.z + (distance0 + distance1) / 2);
                            }

                            if (Mathf.Abs(distance0) < Mathf.Abs(distance1))
                            {
                                ball.position = new Vector3(ball.position.x, ball.position.y, ball.position.z + (distance1 + distance0) / 2);
                            }

                            if (this.gameObject.name == "ColliderZ")
                            {
                                ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.up] = false;
                                ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.down] = false;
                            }
                        }
                    }
                }
            }
        }
        
        

        //else if((paredes[0]==null && paredes[1]!=null) || (paredes[0] != null && paredes[1] == null))
        //{
        //    GameObject pared = new GameObject();
        //    for(int i=0;i<cantParedes;i++)
        //    {
        //        if(paredes[i]!=null)
        //        {
        //            Destroy(pared.gameObject);
        //            pared = paredes[i];
        //            break;
        //        }
        //    }

        //    if(this.gameObject.name == "ColliderZ")
        //    {
        //        if(pared.transform.position.z>ball.position.z)
        //        {
        //            if(ball.transform.position.z>pared.transform.position.z-pared.transform.localScale.z)
        //            {
        //                ball.position = new Vector3(ball.position.x, ball.position.y, pared.transform.position.z - pared.transform.localScale.z);
        //                p.move[(int)PlayerController.Moves.up] = false;
        //            }
        //        }
        //        else
        //        {
        //            if (ball.transform.position.z < pared.transform.position.z + pared.transform.localScale.z)
        //            {
        //                ball.position = new Vector3(ball.position.x, ball.position.y, pared.transform.position.z + pared.transform.localScale.z);
        //                p.move[(int)PlayerController.Moves.down] = false;
        //            }
        //        }
        //    }

        //    if (this.gameObject.name == "ColliderX")
        //    {
        //        if (pared.transform.position.x > ball.position.x)
        //        {
        //            ball.position = new Vector3(pared.transform.position.x - pared.transform.localScale.x, ball.position.y, ball.position.z);
        //        }
        //        else
        //        {
        //            ball.position = new Vector3(pared.transform.position.x + pared.transform.localScale.x, ball.position.y, ball.position.z);
        //        }
        //    }
        //}

        mostrarParedes();
    }

    GameObject paredEnCola;
    GameObject paredEnCola2;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "NormalWall" || col.gameObject.name == "DestroyableWall")
        {
            bool hayLugar = false;
            for (int i = 0; i < cantParedes; i++)
            {
                if (paredes[i] == null)
                {
                    Color color = Color.blue;
                    if(col.gameObject.name == "DestroyableWall")
                    {
                        color = Color.magenta;
                    }
                    paredes[i] = col.gameObject;
                    col.gameObject.GetComponent<MeshRenderer>().material.color = color;
                    hayLugar = true;
                    break;
                }
            }
            if(!hayLugar)
            {
                if(!paredEnCola)
                {
                    paredEnCola = col.gameObject;
                }
                else if(!paredEnCola2)
                {
                    paredEnCola2 = col.gameObject;
                }
            }
        }

        //else if (col.gameObject.name == "DestroyableWall")
        //{
        //    for(int i = 0;i<cantParedes;i++)
        //    {
        //        if(paredes[i]==null)
        //        {
        //            paredes[i] = col.gameObject;
        //            col.gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
        //            break;
        //        }
        //    }
        //}
    }

    private void OnTriggerStay(Collider col)
    {
        //for (int i = 0; i < cantParedes; i++)
        //{
        //    if (!paredes[i])
        //    {
        //        paredEnCola = col.gameObject;
        //        break;
        //    }
        //}
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "NormalWall" || col.gameObject.name == "DestroyableWall")
        {
            for (int i = 0; i < cantParedes; i++)
            {
                if (paredes[i])
                {
                    if (paredes[i] == col.gameObject)
                    {
                        Color color = Color.red;
                        if(col.gameObject.name == "DestroyableWall")
                        {
                            color = Color.yellow;
                        }
                        paredes[i] = null;
                        col.gameObject.GetComponent<MeshRenderer>().material.color = color;
                        if(paredEnCola)
                        {
                            paredes[i] = paredEnCola;
                            paredEnCola = null;
                        }
                        else if(paredEnCola2)
                        {
                            paredes[i] = paredEnCola2;
                            paredEnCola2 = null;
                        }
                        break;
                    }
                    if(paredEnCola == col.gameObject)
                    {
                        paredEnCola = null;
                    }
                }
            }

            if (this.gameObject.name == "ColliderZ")
            {
                ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.up] =true;
                ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.down] =true;
            }                                               
                                                          
            if (this.gameObject.name == "ColliderX")        
            {                                              
                ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.left] =true;
                ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.right] = true;
            }
        }

        //else if (col.gameObject.name == "DestroyableWall")
        //{
        //    for (int i = 0; i < cantParedes; i++)
        //    {
        //        if (paredes[i])
        //        {
        //            if (paredes[i] == col.gameObject)
        //            {
        //                paredes[i] = null;
        //                col.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        //                break;
        //            }
        //        }
        //    }

        //    if (this.gameObject.name == "ColliderZ")
        //    {
        //        if (col.transform.position.z > ball.position.z)
        //        {
        //            ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.up] = true;
        //        }
        //        else
        //        {
        //            ball.GetComponent<PlayerController>().move[(int)PlayerController.Moves.down] = true;
        //        }
        //    }

        //}
    }


    void mostrarParedes()
    {
        if (paredes[0] && paredes[1])
        {
            //Debug.Log(name + "- ambas");
        }
        else if (!paredes[0] && !paredes[1])
        {
            
            
        }
        else
        {
            for(int i=0;i<cantParedes;i++)
            {
                if(paredes[i])
                {
                    Debug.Log(name + "- una" + paredes[i].transform.position);
                    break;
                }
            }
            
        }
    }
}
