
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 40f;

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;


        if (healthAmount <= 0)
        {
            EnemyInstantiate.Instance.current_enemy.Remove(this.GetComponent<EnemyMovement>());
            Destroy(gameObject);
            PlayerHealtManager.Instance.WallCheckEnemies();
        
        }
    }


}
