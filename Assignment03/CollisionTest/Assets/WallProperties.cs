using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallProperties : MonoBehaviour
{
    public float friction;
    public float mass;
    //public float radius;

    [NonSerialized]
    public Vector3 currentV;
    //[NonSerialized]
    public Vector3 wallSize;

    private Collider wallCollider;

    void Start()
    {
        //Fetch the Collider from the game object
        wallCollider = GetComponent<Collider>();

        //Fetch the size of the Collider volume
        wallSize = wallCollider.bounds.size;
    }

    // Update is called once per frame
    void Update()
    {

        //摩擦力
        Vector3 frictionDeltaV = -Time.deltaTime * friction * currentV.normalized;
        //防止摩擦力反向运动
        Vector3 finalV = currentV + frictionDeltaV;
        if (finalV.x * currentV.x <= 0)
            frictionDeltaV.x = -currentV.x;
        if (finalV.y * currentV.y <= 0)
            frictionDeltaV.y = -currentV.y;
        if (finalV.z * currentV.z <= 0)
            frictionDeltaV.z = -currentV.z;

        //应用加速度
        Vector3 curV = currentV + frictionDeltaV;
        transform.Translate((curV + currentV) * Time.deltaTime / 2);
        currentV = curV;

    }



}
