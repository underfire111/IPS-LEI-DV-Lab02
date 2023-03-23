using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    Vector3 direction;

    void Start()
    {
        Destroy(gameObject, 10f);
    }
    

    void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void Setup(Vector3 direction)
    {
        this.direction = direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
