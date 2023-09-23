using UnityEngine;
using DG.Tweening;


public class ItemController : MonoBehaviour
{
    public GameObject[] diamonds;
    public GameObject[] value_stones;
    public GameObject[] golds;
    public GameObject[] rock;

    public SpawnPosition[] spawnPoints;



    private void Start()
    {
        foreach (var item in spawnPoints)
        {
            switch (item.placeType)
            {
                case Enumİtems.ItemPlacePositions.Gold:
                    InstantiateRandomItem(golds, item);
                    break;
                case Enumİtems.ItemPlacePositions.ValueStone:
                    InstantiateRandomItem(value_stones, item);
                    break;
                case Enumİtems.ItemPlacePositions.Diamond:
                    InstantiateRandomItem(diamonds, item);
                    break;
                case Enumİtems.ItemPlacePositions.Rock:
                    InstantiateRandomItem(rock, item);
                    break;
                default:
                    break;
            }

        }

        InvokeRepeating("ReInstantiate", 0f, 7f);

    }
    private void InstantiateRandomItem(GameObject[] items, SpawnPosition pos)
    {
        if (items.Length > 0)
        {
            int randomIndex = Random.Range(0, items.Length);
            GameObject itemToSpawn = items[randomIndex];
            GameObject instantiated_obj = Instantiate(itemToSpawn, pos.transform.position, Quaternion.identity);

            Vector3 newScale = instantiated_obj.transform.localScale + new Vector3(0.2f, 0.2f, 0.2f);
            instantiated_obj.transform.DOScale(newScale, 1f);


            pos.isEmpty = false;

            instantiated_obj.GetComponent<PrefabEnumController>().spawnPosition = pos;
        }
    }


    private void ReInstantiate()
    {
        foreach (var item in spawnPoints)
        {
            if (item.isEmpty)
            {
                switch (item.placeType)
                {
                    case Enumİtems.ItemPlacePositions.Gold:
                        InstantiateRandomItem(golds, item);
                        break;
                    case Enumİtems.ItemPlacePositions.ValueStone:
                        InstantiateRandomItem(value_stones, item);
                        break;
                    case Enumİtems.ItemPlacePositions.Diamond:
                        InstantiateRandomItem(diamonds, item);
                        break;
                    case Enumİtems.ItemPlacePositions.Rock:
                        InstantiateRandomItem(rock, item);
                        break;
                    default:
                        break;
                }
                break;

            }

        }
    }
}
