using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int idItem;
    public string nameItem;
    public Sprite spriteItem;
    public int countOfItemsCanBeInSlot;

    private Inventory inventory;

    [SerializeField] private LayerMask player;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 1.0F, player)) { PickUpItem(); }
    }

    public void SetItem(int _id, string _name)
    {
        this.idItem = _id;
        this.nameItem = _name;
    }


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        PickUpItem();
    //    }
    //}

    private void PickUpItem()
    {
        bool isAdded = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].idItemInSlot == idItem && inventory.slots[i].countOfItemsInSlot < countOfItemsCanBeInSlot)
            {
                AddItem(i);
                isAdded = true;
                break;
            }
        }

        if (!isAdded)
        { 
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].idItemInSlot == 0)
                {
                    AddItem(i);
                    break;
                }
            }
        }

    }

    private void AddItem(int _numberOfSlot)
    {
        inventory.slots[_numberOfSlot].idItemInSlot = idItem;
        inventory.slots[_numberOfSlot].itemSprite.GetComponent<Image>().sprite = spriteItem;
        inventory.slots[_numberOfSlot].itemSprite.SetActive(true);
        inventory.slots[_numberOfSlot].countOfItemsInSlot++;
        Destroy(gameObject);
    }


}
