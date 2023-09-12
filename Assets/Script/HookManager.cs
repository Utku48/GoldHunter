using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HookManager : MonoBehaviour
{
    [SerializeField] private GameObject hook;
    [SerializeField] private Transform holdPos;

    public static GameObject hold_Obj;
    public static HookManager u { get; private set; }

    public static bool isTook = false;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item") && !isTook)
        {
            hold_Obj = other.gameObject;

            if (hold_Obj.GetComponent<PrefabEnumController>().prefabWeight == EnumWeight.Weight.heavy)
            {
                HookMovement.u.move_speed = 0.75f;
            }

            Transform itemTransform = hold_Obj.transform;
            itemTransform.localRotation = hold_Obj.transform.rotation;

            itemTransform.SetParent(hook.transform);

            itemTransform.position = holdPos.position;
            isTook = true;
            HookMovement.u.moveDown = false;

            other.gameObject.GetComponent<PrefabEnumController>().spawnPosition.isEmpty = true;
        }
    }

}
