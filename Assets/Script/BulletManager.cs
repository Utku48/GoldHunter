using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public Transform initialPos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy_Wall"))
        {

        }
    }
}
