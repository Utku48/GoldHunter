using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallManager : MonoBehaviour
{
    public static bool inPlayerWall = false;
    private Animator _anim;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            inPlayerWall = true;
            _anim = other.gameObject.GetComponent<Animator>();
            _anim.SetBool("inPlayerWall", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            inPlayerWall = false;
            _anim.SetBool("inPlayerWall", false);
        }


    }
}

