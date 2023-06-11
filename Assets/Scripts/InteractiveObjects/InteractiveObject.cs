using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private int lives;
    private bool checkTrigger = false;
    private Character player;

    [SerializeField] private ItemList item;

    [SerializeField] private int idInstrumentCanExtractThisObject;
    [SerializeField] private int idResourcesThatDroped;

    [SerializeField] private float yPositionMinus;

    private int countOfDroppedItem;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    private void Update()
    {
        if (lives <= 0) { StartCoroutine(DestroyObject()); }

        if (Input.GetKeyDown(KeyCode.E) && checkTrigger == true) ExtractObject();
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

    private void ExtractObject()
    {
        if (idInstrumentCanExtractThisObject == player.idItemInHand && !player.isExtracting)
        {
            player.StartCoroutine(player.DoExtract());
            lives--;
            Debug.Log(lives);
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(4.0f);

        Destroy(gameObject);
        Vector2 interactiveObjectPosition = new Vector2(transform.position.x, transform.position.y - yPositionMinus);

        countOfDroppedItem = Random.Range(1, 5);

        for (int i = 1; i <= countOfDroppedItem; i++) 
        { 
            Instantiate(item.GetItem(idResourcesThatDroped), interactiveObjectPosition, Quaternion.identity); 
        }
        
    }

}
