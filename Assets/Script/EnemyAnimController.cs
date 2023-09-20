using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public Animator _Eanim;
    private float speed;

    public float _knifeDamage = 10f;

    public static bool wallTouch = false;
    private void Start()
    {
        speed = GetComponent<EnemyMovement>().hareketHizi;

        if (speed > 0.1f && speed <= 0.3f)
        {

            _Eanim.SetBool("isSlow", true);
        }

        else if (speed > 0.3f && speed <= 0.4f)
        {

            _Eanim.SetBool("isMedium", true);
        }

        else if (speed > 0.4f && speed <= 0.6f)
        {

            _Eanim.SetBool("isFast", true);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playerWall"))
        {
            wallTouch = true;
            _Eanim.SetBool("isFight", true);
            GetComponent<EnemyMovement>().hareketHizi = 0f;

            PlayerAnimController[] playerAnimControllers = GameObject.FindObjectsOfType<PlayerAnimController>();
            

            foreach (var anim in playerAnimControllers)
            {
                anim.KnifeAnimation();
         
            }

        }
    }


}
