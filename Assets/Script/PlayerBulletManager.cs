using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
 
    private Vector3 initialPos;
    private Transform initial_Parent;

    private void Start()
    {
        initialPos = transform.position;
        initial_Parent = transform.parent;
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

        transform.SetParent(target.transform);

        transform.DOLocalMove(Vector3.up, .5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            target.GetComponent<EnemyHealthManager>().TakeDamage(10);
            transform.SetParent(initial_Parent);
            transform.position = initialPos;
            DOVirtual.DelayedCall(.2f, () => TweenControl());
        });

    }
}
