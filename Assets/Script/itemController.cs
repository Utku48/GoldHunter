using UnityEngine;


public class itemController : MonoBehaviour
{
    public GameObject[] diamonds;
    public GameObject[] stones;
    public GameObject[] golds;

    public SpawnPosEnumController[] spawnPoints;


    private void Start()
    {
        foreach (var item in spawnPoints)
        {
            switch (item.placeType)
            {
                case Enumİtems.ItemPlacePositions.Gold:
                    InstantiateRandomItem(golds, item.transform.position);
                    break;
                case Enumİtems.ItemPlacePositions.Stone:
                    InstantiateRandomItem(stones, item.transform.position);
                    break;
                case Enumİtems.ItemPlacePositions.Diamond:
                    InstantiateRandomItem(diamonds, item.transform.position);
                    break;
                default:
                    break;
            }

        }


    }
    private void InstantiateRandomItem(GameObject[] items, Vector3 position)
    {
        if (items.Length > 0)
        {
            int randomIndex = Random.Range(0, items.Length);
            GameObject itemToSpawn = items[randomIndex];
            Instantiate(itemToSpawn, position, Quaternion.Euler(-90f, 0f, 0f));

        }
    }
}
