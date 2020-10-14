using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionTest : MonoBehaviour
{
    
    public GameObject wall;
    public SphereMovement sphereMovement;

    private float xDistance;
    private float zDistance;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //检测是否与墙壁相撞
        Vector3 pos = transform.position;
        if (wall != null)
        {
            WallProperties wallProperties = wall.GetComponent<WallProperties>();
            Vector3 wallPos = wall.transform.position;
            Vector3 wallSize = wallProperties.wallSize;

            xDistance = Math.Abs(wallPos.x - pos.x);
            zDistance = Math.Abs(wallPos.z - pos.z);
            //Debug.Log(xDistance);

            //球体间碰撞检测，判断球心距离与墙壁之和
            //if (pos.x < wallPos.x && Vector3.Distance(pos, wallPos) < 0.5 + wallProperties.wallSzie.x/2)
            if ((pos.z < wallPos.z + wallSize.z / 2) && (pos.z > wallPos.z - wallSize.z) && (xDistance < wallSize.x/2 + 0.5) || 
                (pos.x < wallPos.x + wallSize.x / 2) && (pos.x > wallPos.x - wallSize.x) && (zDistance < wallSize.z/2 + 0.5))
            {
                Debug.Log("碰撞发生!");


                ////Vector3 v1 = gameObject.GetComponent<SphereMovement>().PreV;
                //Vector3 v1 = sphereMovement.preV;
                //float m1 = 1.0f; // 简单起见，认为自己的质量为1
                //Vector3 v2 = wallProperties.currentV;
                //float m2 = wallProperties.mass;

                sphereMovement.preV = Vector3.Reflect(sphereMovement.preV, wallProperties.hitNormal);
                //sphereMovememt.preV = ((m1 - m2) * v1 + 2 * m2 * v2) / (m1 + m2);
                //wallProperties.currentV = ((m2 - m1) * v2 + 2 * m1 * v1) / (m1 + m2);

                //如果有碰撞，位置回退，防止穿透
                transform.position = sphereMovement.prePos;

            }
        }
    }
}
