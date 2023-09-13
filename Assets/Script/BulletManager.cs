using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public HealthManager healthManager;

    public Transform initialPos;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy_Wall"))
        {
            healthManager.TakeDamage(20);
        }
    }
}
