using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiate : MonoBehaviour
{
    public GameObject bullet;
    public Transform bullet_instantiate_pos;


    private void Start()
    {
        Instantiate(bullet, bullet_instantiate_pos);
    }
}
