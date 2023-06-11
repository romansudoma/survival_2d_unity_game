using UnityEngine;

public class BuildingsList : MonoBehaviour
{
    public Building[] buildingList;

    public Building GetBuilding(int _idBuilding)
    {
        return buildingList[_idBuilding];
    }
}
