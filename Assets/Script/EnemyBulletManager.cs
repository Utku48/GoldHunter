using DG.Tweening;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    public PlayerHealtManager _player_health_Manager;
    public CarHealthManager _car_health_Manager;

    public Transform player_wall;
    public Transform car;
    private Vector3 initialPos;

    private float damage_value = 5;


    private void Start()
    {
        initialPos = transform.position;
        TweenControl();
    }


    public void TweenControl()
    {
        if (PlayerHealtManager.player_alive == true)
        {
            Vector3 target_pos = new Vector3(player_wall.position.x + .5f, transform.position.y, transform.position.z);
            transform.DOMove(target_pos, .5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.position = initialPos;
                TweenControl();
            });
        }
        else
        {
            Vector3 target_pos = new Vector3(car.position.x, transform.position.y, transform.position.z);
            transform.DOMove(target_pos, .5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.position = initialPos;
                TweenControl();
            });
        }

    }

}