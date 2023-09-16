using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallManager : MonoBehaviour
{
    public static bool inPlayerWall = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            inPlayerWall = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            inPlayerWall = false;
        }


    }
}

