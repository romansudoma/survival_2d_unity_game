using UnityEngine;

public class ItemList : MonoBehaviour
{
    public Item[] itemList;

    public Item GetItem(int _idItem)
    {
        return itemList[_idItem];
    }
}
