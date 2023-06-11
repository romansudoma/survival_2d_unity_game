using UnityEngine;

public class Enemy : Unit
{

    [SerializeField] int idItem;

    private void Update()
    {
        idItem = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().idItemInHand;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if( (unit & unit is Character) && idItem == 5)
        {
            ReceiveDamage();
        }    
        else if (unit & unit is Character)
        {
            unit.ReceiveDamage();
        }

    }


}
