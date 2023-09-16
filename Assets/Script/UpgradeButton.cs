using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public GameObject[] _weapons;
    public Transform _gunPos;

    public void On_Click()
    {
        Destroy(_weapons[0]);
        Instantiate(_weapons[1], _gunPos);
    }

}
