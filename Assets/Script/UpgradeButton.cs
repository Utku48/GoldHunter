using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public static int a = 0;

    public void On_Click()
    {
        if (a == 4)
        {
            Debug.Log("Silah Ekleyiniz");
            return;
        }

        PlayerBulletManager[] _playerBulletManagers = GameObject.FindObjectsOfType<PlayerBulletManager>();
        a++;
        if (a < 4)
        {
            foreach (var item in _playerBulletManagers)
            {
                if (!item.GetComponent<PlayerAnimController>()._knife.activeInHierarchy)
                {
                    item.SetGun(a);
                }


            }
        }
    }


}
