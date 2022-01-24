using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerPhysics : MonoBehaviour
{
    private PlayerController playerController;

    private BoxCollider boxCollider;

    public Vector3 boxSize = new Vector3(1.5f,1f,3f);
    public Vector3 upOffset = new Vector3(0f, 1f, 1.4f);
    public Vector3 downOffset = new Vector3(0f, -1.5f, 1.4f);

    private Vector3 colliderSize;
    private Vector3 colliderPosition;

    private Collider[] results = new Collider[1];
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        colliderSize = boxSize / 2f;
    }

    private void FixedUpdate()
    {
        if(playerController.state == PlayerController.State.IDLE)
        {
            boxCollider.center = new Vector3(boxCollider.center.x, 0.03f, boxCollider.center.z);
            //colliderPosition = transform.position + upOffset;
        }
        else if(playerController.state == PlayerController.State.DIVE)
        {
            boxCollider.center = new Vector3(boxCollider.center.x, -0.05f, boxCollider.center.z);
            //colliderPosition = transform.position + downOffset;
        }
        //BoxCollider();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            playerController.state = PlayerController.State.DAMAGE;
        }
    }

    private void BoxCollider()
    {
        int count = Physics.OverlapBoxNonAlloc(colliderPosition, colliderSize, results, Quaternion.identity, 1 << LayerMask.NameToLayer("Enemy"), QueryTriggerInteraction.Collide);

        if (count != 0)
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + upOffset, boxSize);
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position + downOffset, boxSize);
    }
}
