using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public float min_Z = 45f, max_Z = 135f;
    public float rotate_Speed = 25f;

    private float rotate_Angle;
    private bool rotate_Right;
    private bool canRotate;

    public float move_speed = 3f;
    private float initial_Move_Speed;

    public float min_Y = -20f;
    private float initial_Y;
    private Vector3 initial_pos;

    public bool moveDown;
    public static HookMovement u { get; private set; }


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (u != null && u != this)
        {
            Destroy(this);
        }
        else
        {
            u = this;
        }
    }
    void Start()
    {
        initial_Y = transform.position.y;
        initial_Move_Speed = move_speed;
        initial_pos = transform.position;

        canRotate = true;
    }


    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }


    void Rotate()
    {
        if (!canRotate)
            return;

        if (rotate_Right)
        {
            rotate_Angle += rotate_Speed * Time.deltaTime;
        }
        else
        {
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);

        if (rotate_Angle >= max_Z)
        {
            rotate_Right = false;
        }
        else if (rotate_Angle <= min_Z)
        {
            rotate_Right = true;

        }

    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;
            }
        }
    }

    void MoveRope()
    {
        if (canRotate)
            return;

        if (!canRotate)
        {
            Vector3 temp = transform.position;

            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime * move_speed;

            }
            else
            {
                temp += transform.up * Time.deltaTime * move_speed;
            }

            transform.position = temp;


            if (temp.y <= min_Y)//Maks hook high.y
            {

                moveDown = false;

            }

            if (temp.y >= initial_Y)
            {

                canRotate = true;

                move_speed = initial_Move_Speed;

                transform.position = initial_pos;
            }

        }

    }

}






