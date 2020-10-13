using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionTest : MonoBehaviour
{

    public GameObject other;
    public SphereMovement sphereMovememt;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //检测是否与其他球相撞
        Vector3 pos = transform.position;
        if (other != null)
        {
            OtherSphere otherSphere = other.GetComponent<OtherSphere>();
            Vector3 otherPos = other.transform.position;

            //球体间碰撞检测，判断球心距离与两球半径之和即可
            if (Vector3.Distance(pos, otherPos) < 0.5 + otherSphere.radius) //简单起见，认为自己的半径为0.5
            {
                Debug.Log("碰撞发生!");
                //Vector3 v1 = gameObject.GetComponent<SphereMovement>().PreV;
                Vector3 v1 = sphereMovememt.preV;
                float m1 = 1.0f; // 简单起见，认为自己的质量为1
                Vector3 v2 = otherSphere.currentV;
                float m2 = otherSphere.mass;

                sphereMovememt.preV = ((m1 - m2) * v1 + 2 * m2 * v2) / (m1 + m2);
                otherSphere.currentV = ((m2 - m1) * v2 + 2 * m1 * v1) / (m1 + m2);

                //如果有碰撞，位置回退，防止穿透
                transform.position = sphereMovememt.prePos;
                Debug.Log(sphereMovememt.prePos);
                Debug.Log(sphereMovememt.preV);
            }
        }
    }
}
