using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPositionTrigger : MonoBehaviour
{
    GameObject bomb;

    void Start()
    {
        bomb = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name=="NormalWall")
        {
            float xDifference = col.transform.position.x - transform.position.x;
            float zDifference = col.transform.position.z - transform.position.z;
            if (Mathf.Abs(xDifference) < col.transform.localScale.x / 2 || Mathf.Abs(zDifference) < col.transform.localScale.z / 2)
            {
                if (Mathf.Abs(xDifference) > Mathf.Abs(zDifference))
                {
                    float value = col.transform.localScale.x;
                    if (xDifference > 0)
                    {
                        value = -value;
                    }
                    bomb.transform.position = new Vector3(col.transform.position.x + value, transform.position.y, col.transform.position.z);
                }
                if (Mathf.Abs(xDifference) < Mathf.Abs(zDifference))
                {
                    float value = col.transform.localScale.z;
                    if (zDifference > 0)
                    {
                        value = -value;
                    }
                    bomb.transform.position = new Vector3(col.transform.position.x, transform.position.y, col.transform.position.z + value);
                }
            }
            else
            {
                float xValue = col.transform.position.x;
                float zValue = col.transform.position.z;
                if(xDifference>0)
                {
                    xValue -= col.transform.localScale.x;
                }
                else
                {
                    xValue += col.transform.localScale.x;
                }
                if(zDifference>0)
                {
                    zValue -= col.transform.localScale.z;
                }
                else
                {
                    zValue += col.transform.localScale.z;
                }
                bomb.transform.position = new Vector3(xValue, bomb.transform.position.y, zValue);
            }
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
