using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float upperLimit;
    [SerializeField]
    private float botomLimit;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
        Vector3 position = target.position;         position.y = 0.0F;  position.z = -10.0F; 
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            transform.position.y,
            transform.position.z
            );

    }

    

}
