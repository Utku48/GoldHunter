using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target_Point;
    public float hareketHizi = 5f;
    public Animator _anim;


    PlayerHealtManager playerHealtManager;

    private void Start()
    {
        target_Point = GameObject.Find("Player").transform;

    }

    void Update()
    {

        Vector3 target_Pos = new Vector3(target_Point.position.x + .25f, transform.position.y, transform.position.z);
        Vector3 initial_Pos = transform.position;
        Vector3 move_direction = (target_Pos - initial_Pos).normalized;


        transform.position += move_direction * hareketHizi * Time.deltaTime;

        if (PlayerWallManager.inPlayerWall)
        {
            _anim.SetBool("inPlayerWall", true);
        }
        else
        {
            _anim.SetBool("inPlayerWall", false);
        }
    }


}

