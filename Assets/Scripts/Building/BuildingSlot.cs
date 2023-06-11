using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    private BuildingMenu buildingMenu;

    [SerializeField] private int idOfBuildingInSlot;
    [SerializeField] private BuildingsList buildingsList;

    [SerializeField] private Building building;

    private Inventory inventory;
    private Transform playerTransform;
    private Character player;

    private void Start()
    {
        buildingMenu = GameObject.FindGameObjectWithTag("Player").GetComponent<BuildingMenu>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        //building = buildingsList.GetBuilding(idOfBuildingInSlot);
    }

    public void BuildAHouse()
    {

        if (player.GetIsGrounded())
        {
            int countOfItemsThatBeUsed = 0;
            //int countOfItemsNeedToBeUsed = 0;

            int[] numberOfSlots = new int[building.generalCountOfItemsNeedToBuild];

            for (int i = 0; i < building.idOfItemsNeedToBuild.Length; i++)
            {

                for (int j = 0; j < building.countOfItemsNeedToBuild[i]; j++)
                {
                    //countOfItemsNeedToBeUsed++;

                    for (int k = 0; k < inventory.slots.Length; k++)
                    {
                        if (inventory.slots[k].idItemInSlot == building.idOfItemsNeedToBuild[i])
                        {
                            //inventory.slots[k].countOfItemsInSlot--;
                            numberOfSlots[countOfItemsThatBeUsed] = k;
                            countOfItemsThatBeUsed++;
                        }
                    }
                }
            }

            if (countOfItemsThatBeUsed == building.generalCountOfItemsNeedToBuild)
            {
                for (int i = 0; i < building.generalCountOfItemsNeedToBuild; i++)
                {
                    inventory.slots[numberOfSlots[i]].countOfItemsInSlot--;
                    //if ()
                }

                Vector2 playerPosition = new Vector2(playerTransform.position.x + 1, playerTransform.position.y + 2);
                Instantiate(building, playerPosition, Quaternion.identity);
            }
        }
        
    }

}
