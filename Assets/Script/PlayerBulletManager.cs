using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    public Gun gun;

    public GameObject bullet;
    public Transform _gunParent;

    public GameObject _playerWall;

    private void Start()
    {
        TweenControl();
    }

    public void TweenControl()
    {

        EnemyMovement target = null;
        float distance = 999f;

        foreach (var item in EnemyInstantiate.Instance.current_enemy) //üzerimize koşan enemy'leri gez
        {
            if (Vector3.Distance(item.transform.position, transform.position) < distance) //enemy bize 999'dan daha yakınsa
            {
                target = item;
                distance = Vector3.Distance(item.transform.position, transform.position);
            }
        }

        if (target == null)
        {
            if (!GetComponent<PlayerAnimController>()._knife.activeInHierarchy)
            {
                DOVirtual.DelayedCall(gun._fireRate, () => TweenControl());
            }
            return;
        }

        GameObject inst_bullet = Instantiate(gun._bulletPrefab, gun._instantiate_BulletPos.transform);
        inst_bullet.transform.SetParent(target.transform);

        inst_bullet.transform.DOLocalMove(new Vector3(0, inst_bullet.transform.localPosition.y, 0), gun._bulletDuration).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (target.gameObject != null)
            {
                target.GetComponent<EnemyHealthManager>().TakeDamage(gun._bulletDamage);
                Destroy(inst_bullet);
            }

        });

        if (!GetComponent<PlayerAnimController>()._knife.activeInHierarchy)
        {
            DOVirtual.DelayedCall(gun._fireRate + 0.02f, () => TweenControl());
        }

    }


    public void SetGun(int gunIndex)
    {
        TurnOffGuns(false);

        _gunParent.GetChild(gunIndex).gameObject.SetActive(true);

        gun = _gunParent.GetChild(gunIndex).GetComponent<Gun>();
    }
    //
    public void TurnOffGuns(bool onOffGuns)
    {
        foreach (Transform item in _gunParent)
        {
            item.gameObject.SetActive(onOffGuns);
        }
    }

}
