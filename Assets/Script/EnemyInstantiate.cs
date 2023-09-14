using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    public static EnemyInstantiate Instance { get; private set; }

    public List<GameObject> _enemys = new List<GameObject>();

    public List<EnemyMovement> current_enemy = new List<EnemyMovement>();

    public Transform instantiatePos;

    public int wave_value;

    void Start()
    {
        for (int i = 0; i < wave_value; i++)
        {
            Vector3 newPosition = instantiatePos.position;

            newPosition.x += i * .5f;


            EnemyMovement e = Instantiate(_enemys[i], newPosition, Quaternion.Euler(0f, -90f, 0f)).GetComponent<EnemyMovement>();
            current_enemy.Add(e); //oluşturulan enemyler
        }

    }
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
    }



}
