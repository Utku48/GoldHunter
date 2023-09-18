using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public Animator _anim;
    private float speed;

    private void Start()
    {
        speed = GetComponent<EnemyMovement>().hareketHizi;
        Debug.Log(speed);
        if (speed > 0.1f && speed <= 0.3f)
        {
          
            _anim.SetBool("isSlow", true);
        }

        else if (speed > 0.3f && speed <= 0.4f)
        {
       
            _anim.SetBool("isMedium", true);
        }

        else if (speed > 0.4f && speed <= 0.6f)
        {
        
            _anim.SetBool("isFast", true);
        }

    }



}
