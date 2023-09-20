using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public Animator _anim;

    public GameObject _knife;

    public PlayerBulletManager[] PlayerBulletManagers;
    private void Start()
    {
        _anim = GetComponent<Animator>();

    }

    private void Update()
    {

        GunAnimations();
    }

    private void GunAnimations()
    {

        _anim.SetBool("isPistol", false);
        _anim.SetBool("isShotgun", false);
        _anim.SetBool("isUzi", false);
        _anim.SetBool("isAk", false);

        switch (UpgradeButton.a)
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

    public void KnifeAnimation()
    {
        GetComponent<PlayerBulletManager>().TurnOffGuns(false);
        _anim.SetBool("isKnife", true);
        _knife.SetActive(true);

    }

    public void KnifeAnimationStop()
    {
        GetComponent<PlayerBulletManager>().SetGun(UpgradeButton.a);
        _anim.SetBool("isKnife", false);
        _knife.SetActive(false);
    }
}
