using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform draggingParent;
    [SerializeField] private Transform originalParent;

    [SerializeField] private Slot slot;

    [SerializeField] private Slot copySlot;

    public static int numberOfCurrentSlot;

    private Inventory inventory;
    [SerializeField] private ItemList item;

    public static bool dropInSlot = false;

    private Character player;

    public void Awake()
    {
        originalParent = transform.parent;
        draggingParent = GameObject.FindGameObjectWithTag("inventory").GetComponent<Canvas>().transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        copySlot = GameObject.FindGameObjectWithTag("CopySlot").GetComponent<Slot>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();

    }

    public void OnBeginDrag(PointerEventData evenData)
    {
        transform.SetParent(draggingParent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        Debug.Log("start drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        //Debug.Log("dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

       if (dropInSlot)
       {
            if (inventory.slots[numberOfCurrentSlot].idItemInSlot == slot.idItemInSlot)
            {
                int copyCountOfItem = slot.countOfItemsInSlot;

                for (int i = 0; i < copyCountOfItem; i++)
                {
                    if (inventory.slots[numberOfCurrentSlot].countOfItemsInSlot == item.GetItem(slot.idItemInSlot).countOfItemsCanBeInSlot)
                    {
                        break;
                    }

                    inventory.slots[numberOfCurrentSlot].countOfItemsInSlot++;
                    slot.countOfItemsInSlot--;
                }             
             
            }
            else
            {
                copySlot.idItemInSlot = inventory.slots[numberOfCurrentSlot].idItemInSlot;
                copySlot.countOfItemsInSlot = inventory.slots[numberOfCurrentSlot].countOfItemsInSlot;
                copySlot.itemSprite.GetComponent<Image>().sprite = inventory.slots[numberOfCurrentSlot].itemSprite.GetComponent<Image>().sprite;

                inventory.slots[numberOfCurrentSlot].idItemInSlot = slot.idItemInSlot;
                inventory.slots[numberOfCurrentSlot].countOfItemsInSlot = slot.countOfItemsInSlot;
                inventory.slots[numberOfCurrentSlot].itemSprite.GetComponent<Image>().sprite = slot.itemSprite.GetComponent<Image>().sprite;

                slot.idItemInSlot = copySlot.idItemInSlot;
                slot.countOfItemsInSlot = copySlot.countOfItemsInSlot;
                slot.itemSprite.GetComponent<Image>().sprite = copySlot.itemSprite.GetComponent<Image>().sprite;

                dropInSlot = false;

                numberOfCurrentSlot = -1;

                if (slot.GetNumberOfSlot() == player.numberOfSlotHaveItemInHand)
                {
                    slot.GetComponent<TakeItem>().DeleteItemFromHand();
                }
            }

        }

        transform.position = originalParent.position;
        transform.SetParent(originalParent);

        Debug.Log("end drag");
    }

   


}
