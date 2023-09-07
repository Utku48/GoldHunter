using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TookLineController : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            HookManager.u.isTook = false;
            Destroy(other.gameObject);
        }
    }
}
