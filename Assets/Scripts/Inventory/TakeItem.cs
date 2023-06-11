using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    [SerializeField] Slot slot;
    private Character player;

    [SerializeField] private SpriteRenderer idleInstrumentSprite;
    [SerializeField] private SpriteRenderer jumpInstrumentSprite;
    [SerializeField] private SpriteRenderer runTopInstrumentSprite;
    [SerializeField] private SpriteRenderer runBottomInstrumentSprite;
    [SerializeField] private SpriteRenderer lootBottomInstrumentSprite;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    public void TakeItemFromSlot()
    {
        if (slot.idItemInSlot != 0) AddItemToHand();
        else if (slot.idItemInSlot == 0) DeleteItemFromHand();
    }

    private void AddItemToHand()
    {
        idleInstrumentSprite.sprite = slot.itemSprite.GetComponent<Image>().sprite;
        jumpInstrumentSprite.sprite = slot.itemSprite.GetComponent<Image>().sprite;
        runTopInstrumentSprite.sprite = slot.itemSprite.GetComponent<Image>().sprite;
        runBottomInstrumentSprite.sprite = slot.itemSprite.GetComponent<Image>().sprite;
        lootBottomInstrumentSprite.sprite = slot.itemSprite.GetComponent<Image>().sprite;

        player.idItemInHand = slot.idItemInSlot;
        player.numberOfSlotHaveItemInHand = slot.GetNumberOfSlot();
    }

    public void DeleteItemFromHand()
    {
        idleInstrumentSprite.sprite = null;
        jumpInstrumentSprite.sprite = null;
        runTopInstrumentSprite.sprite = null;
        runBottomInstrumentSprite.sprite = null;
        lootBottomInstrumentSprite.sprite = null;

        player.idItemInHand = 0;
    }

}
