using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    public static EnemyInstantiate Instance { get; private set; }

    public List<GameObject> _enemys = new List<GameObject>();

    public List<EnemyMovement> current_enemy = new List<EnemyMovement>();

    public Transform instantiatePos;



    void Start()
    {
        SpawnWave();
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

    private void Update()
    {

        CheckWaveCompletion();
    }

    void CheckWaveCompletion()
    {

        if (current_enemy.Count == 0) //düşmanların hepsi öldüyse yeni dalgayı oluştur
        {
            ScoreManager.wave_value++;
            SpawnWave();
        }
    }

    void SpawnWave()
    {

        for (int i = 0; i < ScoreManager.wave_value; i++)
        {
            Vector3 newPosition = instantiatePos.position;
            newPosition.x += i * 0.5f;
            EnemyMovement e = Instantiate(_enemys[i % _enemys.Count], newPosition, Quaternion.Euler(0f, -90f, 0f)).GetComponent<EnemyMovement>();
            e.GetComponent<EnemyMovement>().hareketHizi = Random.Range(0.1f, 0.5f);
            current_enemy.Add(e);
            PlayerWallManager.inPlayerWall = false;
        }
    }
}
