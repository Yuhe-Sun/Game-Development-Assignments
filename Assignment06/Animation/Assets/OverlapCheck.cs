using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCheck : MonoBehaviour
{
    public float radius = 1f;
    public Collider[] arrColliders;
    public bool nearCol = false;



    // Update is called once per frame
    void FixedUpdate()
    {
        nearCol = false;
        arrColliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach(Collider collider in arrColliders)
        {
            if (collider.gameObject.tag == "EnvironmentCollider")
            {
                nearCol = true;
            }
        }
        print(nearCol);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
         //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
