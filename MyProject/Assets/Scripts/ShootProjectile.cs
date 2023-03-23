using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private GameObject cam;

    Vector3 shootingPoint;
    
    Vector3 position;
    Quaternion rotation;

    [Header("Keybinds")]
    [SerializeField] private KeyCode shootKey = KeyCode.Space;

    [SerializeField] private float shootCooldown;
    bool readyToShoot;

    void Awake()
    {
        readyToShoot = true;
    }

    private void FixedUpdate()
    {
        position = cam.transform.position;
        rotation = transform.rotation;
        shootingPoint = cam.transform.GetChild(0).gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(shootKey) && readyToShoot)
        {
            readyToShoot = false;

            Shoot();

            Invoke(nameof(ResetShoot), shootCooldown);
        }
    }

    private void Shoot()
    {
        Transform projectile = Instantiate(prefab, position, rotation);

        Vector3 direction = shootingPoint - position;

        projectile.GetComponent<ProjectileBehaviour>().Setup(direction);
    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }

}
