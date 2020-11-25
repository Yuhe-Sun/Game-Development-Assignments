using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform playerRightHandBone;

    void Start()
    {
        Transform weaponTrans = Instantiate(Resources.Load<Transform>("JTS_Wakizashi/Prefabs/Wakizashi"));

        weaponTrans.parent = playerRightHandBone;
        weaponTrans.localPosition = new Vector3(-0.07f, 0.1f, 0.0f);
        weaponTrans.localRotation = Quaternion.Euler(168, 90, 0);
        weaponTrans.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
