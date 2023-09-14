using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    public GameObject Player;

    public bool _instantiated2 = false;
    public bool _instantiated3 = false;
    public bool _instantiated4 = false;
    public bool _instantiated5 = false;
    public bool _instantiated6 = false;




    void Update()
    {
        if (ScoreManager.player_Count == 2 && !_instantiated2)
        {
            Instantiate(Player, new Vector3(-0.3f, 2.40f, 6.6f), Quaternion.Euler(0f, 90f, 0f));
            _instantiated2 = true;
        }

        if (ScoreManager.player_Count == 3 && !_instantiated3)
        {
            Instantiate(Player, new Vector3(-0.4f, 2.40f, 7.2f), Quaternion.Euler(0f, 90f, 0f));
            _instantiated3 = true;
        }

        if (ScoreManager.player_Count == 4 && !_instantiated4)
        {
            Instantiate(Player, new Vector3(-0.55f, 2.40f, 7.2f), Quaternion.Euler(0f, 90f, 0f));
            _instantiated4 = true;
        }

        if (ScoreManager.player_Count == 5 && !_instantiated5)
        {
            Instantiate(Player, new Vector3(-0.55f, 2.40f, 6.8f), Quaternion.Euler(0f, 90f, 0f));
            _instantiated5 = true;
        }

        if (ScoreManager.player_Count == 6 && !_instantiated6)
        {
            Instantiate(Player, new Vector3(-0.55f, 2.40f, 6.6f), Quaternion.Euler(0f, 90f, 0f));
            _instantiated6 = true;
        }


    }
}
