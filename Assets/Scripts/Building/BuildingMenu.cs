using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    public BuildingSlot[] buildingSlots;
    [SerializeField] private GameObject buildingMenu;

    private bool buildingMenuOn = false;

    private void Awake()
    {
        buildingMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) OpenBuildingMenu(); 
    }

    public void OpenBuildingMenu()
    {
        if (buildingMenuOn == false)
        {
            buildingMenuOn = true;
            buildingMenu.SetActive(true);
        }
        else if (buildingMenuOn == true)
        {
            buildingMenuOn = false;
            buildingMenu.SetActive(false);
        }
    }

}
