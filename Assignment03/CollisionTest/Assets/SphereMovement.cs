using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float force;
    public float friction;


    //上一帧结束时的速度
    [NonSerialized]
    public Vector3 preV;
    //上一帧结束时的位置
    [NonSerialized]
    public Vector3 prePos;

    void Start()
    {
        preV = Vector3.zero;
    }

    void Update()
    {
        //摩擦力
        Vector3 frictionDeltaV = -Time.deltaTime * friction * preV.normalized;
        //防止摩擦力反向运动
        Vector3 finalV = preV + frictionDeltaV;
        if (finalV.x * preV.x <= 0)
            frictionDeltaV.x = -preV.x;
        if (finalV.y * preV.y <= 0)
            frictionDeltaV.y = -preV.y;
        if (finalV.z * preV.z <= 0)
            frictionDeltaV.z = -preV.z;

        //计算用户用力方向
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 fDir = new Vector3(moveHorizontal, 0.0f, moveVertical);
        fDir.Normalize();


        //计算加速度
        Vector3 acceleration = force * fDir;

        prePos = transform.position;

        //应用加速度
        Vector3 curV = preV + Time.deltaTime * acceleration + frictionDeltaV;
        transform.Translate((curV + preV) * Time.deltaTime / 2);
        preV = curV;
    }

}
