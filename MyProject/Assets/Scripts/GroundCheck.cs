using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    [SerializeField] private LayerMask platformLayerMask;
    private bool isGrounded;

    private void OnTriggerStay(Collider other)
    {
        isGrounded = (other != null && (((1 << other.gameObject.layer) & platformLayerMask) != 0));
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
