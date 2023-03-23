using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject crosshair;

    Animator animator;

    Vector3 shootingPoint;
    Vector3 targetPoint;
    Quaternion rotation;

    [Header("Keybinds")]
    [SerializeField] private KeyCode shootKey = KeyCode.Space;

    [SerializeField] private float shootCooldown;
    bool readyToShoot;

    void Awake()
    {
        animator = transform.GetChild(2).gameObject.GetComponent<Animator>();
        readyToShoot = true;
    }

    private void FixedUpdate()
    {
        shootingPoint = gun.transform.position;
        targetPoint = crosshair.transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shootKey))
        {
            animator.SetBool("isShooting", true);
            
            if (readyToShoot)
            {
                readyToShoot = false;

                Shoot();

                Invoke(nameof(ResetShoot), shootCooldown);
            }
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    private void Shoot()
    {
        Transform projectile = Instantiate(prefab, shootingPoint, rotation);

        Vector3 direction = (targetPoint - shootingPoint).normalized;

        projectile.GetComponent<ProjectileBehaviour>().Setup(direction);
    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }

}
