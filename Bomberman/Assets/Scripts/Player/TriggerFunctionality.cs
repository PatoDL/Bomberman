using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunctionality : MonoBehaviour
{
    const int cantParedes = 2;
    public GameObject[] paredes;
    Transform par;
    EnemyBehaviour enemyBeh;
    PlayerController p;
    PlayerController.Moves lastCol;
    void Start()
    {
        paredes = new GameObject[cantParedes];
        for(int i=0;i<cantParedes;i++)
        {
            paredes[i] = null;
        }

        par = transform.parent.transform;
        
        p = par.GetComponent<PlayerController>();

        enemyBeh = par.GetComponent<EnemyBehaviour>();
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
                        float distance0 = paredes[0].transform.position.x - par.position.x;
                        float distance1 = paredes[1].transform.position.x - par.position.x;

                        if (distance0 != distance1)
                        {
                            if (Mathf.Abs(distance0) > Mathf.Abs(distance1))
                            {
                                par.position = new Vector3(par.position.x + (distance0 + distance1) / 2, par.position.y, par.position.z);
                            }

                            if (Mathf.Abs(distance0) < Mathf.Abs(distance1))
                            {
                                par.position = new Vector3(par.position.x + (distance1 + distance0) / 2, par.position.y, par.position.z);
                            }

                            if (this.gameObject.name == "ColliderX")
                            {
                                if (par.name == "Player")
                                {
                                    p.move[(int)PlayerController.Moves.left] = false;
                                    p.move[(int)PlayerController.Moves.right] = false;
                                }
                            }
                        }
                    }

                    if (paredes[0].transform.position.x == paredes[1].transform.position.x)
                    {
                        float distance0 = paredes[0].transform.position.z - par.position.z;
                        float distance1 = paredes[1].transform.position.z - par.position.z;

                        if (distance0 != distance1)
                        {
                            if (Mathf.Abs(distance0) > Mathf.Abs(distance1))
                            {
                                par.position = new Vector3(par.position.x, par.position.y, par.position.z + (distance0 + distance1) / 2);
                            }

                            if (Mathf.Abs(distance0) < Mathf.Abs(distance1))
                            {
                                par.position = new Vector3(par.position.x, par.position.y, par.position.z + (distance1 + distance0) / 2);
                            }

                            if (this.gameObject.name == "ColliderZ")
                            {
                                if (par.name == "Player")
                                {
                                    p.move[(int)PlayerController.Moves.up] = false;
                                    p.move[(int)PlayerController.Moves.down] = false;
                                }
                            }
                        }
                    }

                    if (par.name != "Player")
                    {
                        if (gameObject.name == "ColliderZ")
                        {
                            enemyBeh.wallCollisionZ = 2;
                        }
                        else
                        {
                            enemyBeh.wallCollisionX = 2;
                        }
                    }
                }
            }
        }

        else if ((paredes[0] == null && paredes[1] != null) || (paredes[0] != null && paredes[1] == null))
        {
            GameObject pared = new GameObject();
            for (int i = 0; i < cantParedes; i++)
            {
                if (paredes[i] != null)
                {
                    Destroy(pared.gameObject);
                    pared = paredes[i];
                    break;
                }
            }

            if (this.gameObject.name == "ColliderZ")
            {
                if (pared.transform.position.z > par.position.z)
                {
                    if (par.transform.position.z > pared.transform.position.z - pared.transform.localScale.z)
                    {
                        par.position = new Vector3(par.position.x, par.position.y, pared.transform.position.z - pared.transform.localScale.z);
                        if (par.name == "Player")
                            p.move[(int)PlayerController.Moves.up] = false;
                    }
                }
                else
                {
                    if (par.transform.position.z < pared.transform.position.z + pared.transform.localScale.z)
                    {
                        par.position = new Vector3(par.position.x, par.position.y, pared.transform.position.z + pared.transform.localScale.z);
                        if (par.name == "Player")
                            p.move[(int)PlayerController.Moves.down] = false;
                    }
                }
                if (par.name != "Player")
                    enemyBeh.wallCollisionZ = 1;
            }

            if (this.gameObject.name == "ColliderX")
            {
                if (pared.transform.position.x > par.position.x)
                {
                    if (par.transform.position.x > pared.transform.position.x - pared.transform.localScale.x)
                    {
                        par.position = new Vector3(pared.transform.position.x - pared.transform.localScale.x, par.position.y, par.position.z);
                        if (par.name == "Player")
                            p.move[(int)PlayerController.Moves.right] = false;
                    }
                }
                else
                {
                    if (par.transform.position.x < pared.transform.position.x + pared.transform.localScale.x)
                    {
                        par.position = new Vector3(pared.transform.position.x + pared.transform.localScale.x, par.position.y, par.position.z);
                        if (par.name == "Player")
                            p.move[(int)PlayerController.Moves.left] = false;
                        
                    }
                }
                if(par.name!="Player")
                enemyBeh.wallCollisionX = 1;
            }

            if (par.name != "Player")
            {
                if (enemyBeh.wallCollisionX == 2 || enemyBeh.wallCollisionZ == 1)
                {
                    if (pared.transform.position.z > par.position.z)
                    {
                        enemyBeh.m = 1;
                        lastCol = PlayerController.Moves.up;
                    }
                    else
                    {
                        enemyBeh.m = 0;
                        lastCol = PlayerController.Moves.down;
                    }
                }
                else if (enemyBeh.wallCollisionZ == 2 || enemyBeh.wallCollisionX == 1)
                {
                    if (pared.transform.position.x > par.position.x)
                    {
                        enemyBeh.m = 2;
                        lastCol = PlayerController.Moves.right;
                    }
                    else
                    {
                        enemyBeh.m = 3;
                        lastCol = PlayerController.Moves.left;
                    }
                }
            }
            
        }
        else if(!paredes[0] && !paredes[1])
        {
            if (par.name != "Player")
            {
                if (gameObject.name == "ColliderZ")
                {
                    enemyBeh.wallCollisionZ = 0;
                }
                else
                {
                    enemyBeh.wallCollisionX = 0;
                }

                if (enemyBeh.wallCollisionX == 0 && enemyBeh.wallCollisionZ == 0)
                {
                    enemyBeh.m = Random.Range(0, 3);
                    while (enemyBeh.m == (int)lastCol)
                    {
                        enemyBeh.m = Random.Range(0, 3);
                    }
                }
                else if (enemyBeh.wallCollisionX == 2 && enemyBeh.wallCollisionZ == 0)
                {
                    if (lastCol == PlayerController.Moves.up)
                        enemyBeh.m = 1;
                    else
                        enemyBeh.m = 0;
                }
                else if (enemyBeh.wallCollisionX == 0 && enemyBeh.wallCollisionZ == 2)
                {
                    if (lastCol == PlayerController.Moves.left)
                        enemyBeh.m = 3;
                    else
                        enemyBeh.m = 2;
                }
            }
        }
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
                    paredes[i] = col.gameObject;
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
                        paredes[i] = null;
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

            if (par.name == "Player")
            {
                if (this.gameObject.name == "ColliderZ")
                {
                    par.GetComponent<PlayerController>().move[(int)PlayerController.Moves.up] = true;
                    par.GetComponent<PlayerController>().move[(int)PlayerController.Moves.down] = true;
                }

                if (this.gameObject.name == "ColliderX")
                {
                    par.GetComponent<PlayerController>().move[(int)PlayerController.Moves.left] = true;
                    par.GetComponent<PlayerController>().move[(int)PlayerController.Moves.right] = true;
                }
            }
        }
    }
}
