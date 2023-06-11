using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Slot[] slots;

    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private GameObject inventoryFull;

    private bool inventoryOn = false;

    private void Awake()
    {
        inventoryFull.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) OpenInventory();
        TakeSlot();
    }

    public void OpenInventory()
    {
        if(inventoryOn == false)
        {
            inventoryOn = true;
            inventoryFull.SetActive(true);
        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventoryFull.SetActive(false);
        }
    }

    private void TakeSlot()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) slots[0].GetComponent<TakeItem>().TakeItemFromSlot();
        if (Input.GetKeyDown(KeyCode.Keypad2)) slots[1].GetComponent<TakeItem>().TakeItemFromSlot();
        if (Input.GetKeyDown(KeyCode.Keypad3)) slots[2].GetComponent<TakeItem>().TakeItemFromSlot();
        if (Input.GetKeyDown(KeyCode.Keypad4)) slots[3].GetComponent<TakeItem>().TakeItemFromSlot();
        if (Input.GetKeyDown(KeyCode.Keypad5)) slots[4].GetComponent<TakeItem>().TakeItemFromSlot();

        if (Input.GetKeyDown(KeyCode.Alpha1)) slots[0].GetComponent<TakeItem>().TakeItemFromSlot();
        if (Input.GetKeyDown(KeyCode.Alpha2)) slots[1].GetComponent<TakeItem>().TakeItemFromSlot();
        if (Input.GetKeyDown(KeyCode.Alpha3)) slots[2].GetComponent<TakeItem>().TakeItemFromSlot();
        if (Input.GetKeyDown(KeyCode.Alpha4)) slots[3].GetComponent<TakeItem>().TakeItemFromSlot();
        if (Input.GetKeyDown(KeyCode.Alpha5)) slots[4].GetComponent<TakeItem>().TakeItemFromSlot();

    }
}
