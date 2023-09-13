using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabEnumController : MonoBehaviour
{
    public SpawnPosition spawnPosition;

    public EnumWeight.Weight prefabWeight;
    public float value;

    private void Update()
    {
        if (gameObject.transform.localScale.x <= .35f)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
    }

}
