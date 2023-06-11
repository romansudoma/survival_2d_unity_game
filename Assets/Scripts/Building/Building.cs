using UnityEngine;

public class Building : MonoBehaviour
{
    public int idOfBuilding;

    public int[] idOfItemsNeedToBuild;
    public int[] countOfItemsNeedToBuild;

    public int generalCountOfItemsNeedToBuild;

    [SerializeField] private int idItemThatLootFromBuilding;
    private bool checkTrigger;


    private Transform player;
    [SerializeField] private ItemList item;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && checkTrigger == true) LootItemFromBuilding();
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            Debug.Log("Press E");
            checkTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        checkTrigger = false;
    }

    private void LootItemFromBuilding()
    {
        Vector2 playerPosition = new Vector2(player.position.x + 2, player.position.y - 1);
        Instantiate(item.GetItem(idItemThatLootFromBuilding), playerPosition, Quaternion.identity);
    }

}
