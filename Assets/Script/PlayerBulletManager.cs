using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    public EnemyHealthManager _enemy_health_Manager;

    public Transform enemy_wall;
    private Vector3 initialPos;


    public float damage_value;


    private void Start()
    {
        initialPos = transform.position;
        TweenControl();
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy_Wall"))
        {
            _enemy_health_Manager.TakeDamage(damage_value);
        }
    }

    public void TweenControl()
    {
        Vector3 target_pos = new Vector3(enemy_wall.position.x + .5f, transform.position.y, transform.position.z);

        //SetEase merminin hızının giderek değişmemesini sağlar
        transform.DOMove(target_pos, .5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.position = initialPos;
            TweenControl();
        });

    }
}
