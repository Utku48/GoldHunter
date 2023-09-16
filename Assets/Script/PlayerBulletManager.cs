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
    public Transform bullet_instantiate_pos;
    private void Start()
    {
        SetBulletPos();
        TweenControl();
    }

    public void TweenControl()
    {

        EnemyMovement target = null;
        float distance = 999f;

        foreach (var item in EnemyInstantiate.Instance.current_enemy) //üzerimize koşan enemy'leri gez
        {
            if (Vector3.Distance(item.transform.position, transform.parent.position) < distance) //enemy bize 999'dan daha yakınsa
            {
                target = item;
                distance = Vector3.Distance(item.transform.position, transform.parent.position);
            }
        }

        if (target == null)
        {
            DOVirtual.DelayedCall(.5f, () => TweenControl());
            return;
        }

        GameObject inst_bullet = Instantiate(bullet, gun._instantiate_BulletPos.transform);
        inst_bullet.transform.SetParent(target.transform);

        inst_bullet.transform.DOLocalMove(new Vector3(0, inst_bullet.transform.localPosition.y, 0), .5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (target.gameObject != null)
            {
                target.GetComponent<EnemyHealthManager>().TakeDamage(10);
                Destroy(inst_bullet);
            }

        });
        DOVirtual.DelayedCall(.52f, () => TweenControl());
    }
    private void Update()
    {
        SetBulletPos();
    }
    public void SetBulletPos()
    {
        gun = GameObject.FindGameObjectWithTag("weapon").GetComponent<Gun>();

        GameObject weapon = GameObject.FindGameObjectWithTag("weapon");
        gun._instantiate_BulletPos = weapon.transform.Find("BulletPos");
    }
}
