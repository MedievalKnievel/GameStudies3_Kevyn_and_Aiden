using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Rigidbody weaponRb;
    public GameObject endPos;

    void start()
    {
        endPos.SetActive(false);
    }
    public void OnCollisionEnter(Collision collision)
    {
        weaponRb.isKinematic = true;
        endPos.SetActive(true);
        endPos.transform.position = transform.position;

    }
}

/*   

     References:
     1. [Code Bot]. (2021, February 2). Unity 3D - New Input System, First Person Control [Video]. Youtube.com. https://www.youtube.com/watch?v=w4IMYgpqgdQ

*/