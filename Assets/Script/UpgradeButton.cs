using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{

    int a = 0;
    public void On_Click()
    {

        PlayerBulletManager[] _playerBulletManagers = GameObject.FindObjectsOfType<PlayerBulletManager>();
        a++;

        foreach (var item in _playerBulletManagers)
        {
            item.SetGun(a);

        }
    }

}
