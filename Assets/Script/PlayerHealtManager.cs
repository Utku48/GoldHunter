using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealtManager : MonoBehaviour
{

    public static PlayerHealtManager Instance { get; private set; }

    public Image healthBar;
    public float healthAmount = 1000f;

    public static bool player_alive = true;

    public GameObject _playerWall;
    public LayerMask enemyLayer;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        InvokeRepeating("HitEnemy", 2f, 2f);
    }

    private void Update()
    {
        WallCheckEnemies();

        if (healthAmount <= 0)
        {
            player_alive = false;
        }
    }
    public void TakeDamagePlayer(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;

    }



    public void WallCheckEnemies()
    {
        Collider[] inColliders = Physics.OverlapSphere(_playerWall.transform.position, .25f, enemyLayer);

        if (inColliders.Length == 0)
        {
            PlayerAnimController[] playerAnimControllers = GameObject.FindObjectsOfType<PlayerAnimController>();

            foreach (var anim in playerAnimControllers)
            {
                if (anim._knife.activeInHierarchy)
                {
                    DOVirtual.DelayedCall(Random.Range(0.1f, 0.5f), () => anim.GetComponent<PlayerBulletManager>().TweenControl());

                }
                anim.KnifeAnimationStop();
            }

        }

    }

    public void HitEnemy()
    {
        Collider[] inColliders = Physics.OverlapSphere(_playerWall.transform.position, .25f, enemyLayer);

        if (inColliders.Length > 0)
        {

            TakeDamagePlayer((2f * inColliders.Length));

            int m = GameObject.FindObjectsOfType<PlayerBulletManager>().Length;
            foreach (var item in inColliders)
            {
                item.GetComponent<EnemyHealthManager>().TakeDamage((10 * m));
            }

        }
    }



}
