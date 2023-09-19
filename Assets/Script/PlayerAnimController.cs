using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private EnemyHealthManager enemyHealthManager;

    private Animator _anim;
    public static int _gunValue;
    public GameObject _knife;


    private void Start()
    {
        _anim = GetComponent<Animator>();
        enemyHealthManager = GetComponent<EnemyHealthManager>();
    }

    private void Update()
    {

        GunAnimations();

        if (EnemyAnimController.wallTouch)
        {
            KnifeAnimation();
        }
        else
        {
            KnifeAnimationStop();
        }
    }

    private void GunAnimations()
    {

        _anim.SetBool("isPistol", false);
        _anim.SetBool("isShotgun", false);
        _anim.SetBool("isUzi", false);
        _anim.SetBool("isAk", false);

        switch (_gunValue)
        {
            case 1:
                _anim.SetBool("isPistol", true);
                break;
            case 2:
                _anim.SetBool("isShotgun", true);
                break;
            case 3:
                _anim.SetBool("isUzi", true);
                break;
            case 4:
                _anim.SetBool("isAk", true);
                break;
        }
    }

    private void KnifeAnimation()
    {
        _anim.SetBool("isKnife", true);
        _knife.SetActive(true);
        enemyHealthManager.TakeDamage(40f);
    }

    private void KnifeAnimationStop()
    {
        _anim.SetBool("isKnife", false);
        _knife.SetActive(false);
    }
}
