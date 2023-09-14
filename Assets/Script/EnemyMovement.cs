using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target_Point;
    public float hareketHizi = 5f;

    private void Start()
    {
        target_Point = GameObject.Find("goldCar").transform;
    }

    void Update()
    {

        Vector3 target_Pos = new Vector3(target_Point.position.x, transform.position.y, transform.position.z);
        Vector3 initial_Pos = transform.position;
        Vector3 move_direction = (target_Pos - initial_Pos).normalized;


        transform.position += move_direction * hareketHizi * Time.deltaTime;
    }
}

