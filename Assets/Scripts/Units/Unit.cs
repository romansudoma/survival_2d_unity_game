using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int lives;

    private void FixedUpdate()
    {
        if (lives <= 0) Die();
    }

    public virtual void ReceiveDamage()
    {
        lives--;
        Debug.Log(lives);
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Die");
    }
}
