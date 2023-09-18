
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;


    private void Update()
    {
        if (healthAmount <= 0)
        {
            EnemyInstantiate.Instance.current_enemy.Remove(this.GetComponent<EnemyMovement>());
            Debug.Log("Enemys Died");
            Destroy(gameObject);

        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;
    }


}
