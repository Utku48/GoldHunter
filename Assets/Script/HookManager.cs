using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HookManager : MonoBehaviour
{
    [SerializeField] private GameObject hook;
    [SerializeField] private Transform holdPos;

    public static HookManager u { get; private set; }

    public bool isTook = false;

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
        if (other.gameObject.CompareTag("item") && isTook == false)
        {
            if (other.gameObject.GetComponent<PrefabEnumController>().prefabWeight == EnumWeight.Weight.heavy)
            {
                HookMovement.u.move_speed = 0.75f;
            }
            Transform itemTransform = other.transform;
            itemTransform.SetParent(hook.transform, false);

            itemTransform.localRotation = other.gameObject.transform.rotation;
            itemTransform.localScale = Vector3.one;

            itemTransform.position = holdPos.position;
            isTook = true;
            HookMovement.u.moveDown = false;
        }
    }
}
