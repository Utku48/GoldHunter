using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TookLineController : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            Destroy(other.gameObject);
            ScoreManager.money += other.gameObject.GetComponent<PrefabEnumController>().value * 10;
        }

    }

}
