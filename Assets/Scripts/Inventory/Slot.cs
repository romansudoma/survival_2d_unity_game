using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private Inventory inventory;
    public GameObject itemSprite;
    public int idItemInSlot;

    [SerializeField] private int numberOfSlot;
    [SerializeField] private ItemList item;
    private Transform player;

    public int countOfItemsInSlot;
    private Text textCountOfItems;

    public int GetNumberOfSlot()
    {
        return numberOfSlot;
    }

    private void Awake()
    {
        idItemInSlot = 0;
    }

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        textCountOfItems = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (itemSprite.GetComponent<Image>().sprite == null) { idItemInSlot = 0; itemSprite.SetActive(false); };
        if (!(itemSprite.GetComponent<Image>().sprite == null)) itemSprite.SetActive(true);

        if (countOfItemsInSlot == 0) 
        { 
            textCountOfItems.gameObject.SetActive(false);
            itemSprite.GetComponent<Image>().sprite = null;
            itemSprite.SetActive(false);
        }
        
        if (countOfItemsInSlot != 0) { SetCountOfItemsInSlot();  textCountOfItems.gameObject.SetActive(true); }
    }

    public void DropItem()
    {
        if (idItemInSlot != 0)
        {
            Vector2 playerPosition = new Vector2(player.position.x + 2, player.position.y - 1);
            Instantiate(item.GetItem(idItemInSlot), playerPosition, Quaternion.identity);         
            countOfItemsInSlot--;

            if (countOfItemsInSlot == 0)
            {
                //itemSprite.GetComponent<Image>().sprite = null;
                //itemSprite.SetActive(false);
                GetComponent<TakeItem>().DeleteItemFromHand();
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");

        DragItem.numberOfCurrentSlot = numberOfSlot;
        DragItem.dropInSlot = true;
    }

    public void SetCountOfItemsInSlot()
    {
        textCountOfItems.text = countOfItemsInSlot.ToString();
    }

}
