using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerPhysics : MonoBehaviour
{
    // Component
    private PlayerController playerController;
    private BoxCollider boxCollider;

    // Variable
    public Vector3 boxSize = new Vector3(1.5f,1f,3f); //Default Box Size
    public Vector3 upOffset = new Vector3(0f, 1f, 1.4f); //Idle 
    public Vector3 downOffset = new Vector3(0f, -1.5f, 1.4f); // Dive

    private Vector3 colliderStartSize;
    private Vector3 colliderSize;
    private Vector3 colliderPosition;

    private GameObject enemy;
    
    private Collider[] results = new Collider[1];

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        colliderStartSize = boxCollider.size;
        colliderSize = boxSize / 2f;
    }

    private void Update()
    {
        //Box Collider 위치 사이즈 조정 (모델 리소스 문제로 하드코딩)
        if(playerController.state == PlayerController.State.IDLE)
        {
            boxCollider.enabled = true;
            boxCollider.center = new Vector3(0.04f, 0.03f, boxCollider.center.z);
            boxCollider.size = colliderStartSize;
        }
        else if(playerController.state == PlayerController.State.DIVE)
        {
            boxCollider.enabled = true;
            boxCollider.center = new Vector3(0.04f, -0.05f, boxCollider.center.z);
            boxCollider.size = colliderStartSize;
        }
        else if (playerController.state == PlayerController.State.ATTACK)
        {
            if(playerController.animator.GetCurrentAnimatorStateInfo(0).normalizedTime>0.4f)
            {
                boxCollider.enabled = false;
            }
            else
            {
                boxCollider.enabled = true;
            }
            boxCollider.center = new Vector3(0.06f, 0.03f, boxCollider.center.z);
            boxCollider.size = new Vector3(0.15f, 0.03f, 0.1f);
        }
        else
        {
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (enemy == other.gameObject)
            {
                return;
            }
            if ((playerController.state == PlayerController.State.IDLE || playerController.state == PlayerController.State.DIVE))
            {
                enemy = other.gameObject;
                playerController.OnDamage();
            }
            if ((playerController.state == PlayerController.State.ATTACK))
            {
                other.gameObject.GetComponent<ObstacleAttacked>().Attacked();
            }
        }else if(other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            if(other.GetComponent<ObstacleCtrl>().GetObstacleType == TypeID.HEL1)
            {
                playerController.HelmatEffect(1);
            }
            else if (other.GetComponent<ObstacleCtrl>().GetObstacleType == TypeID.HEL2)
            {
                playerController.HelmatEffect(2);
            }
            else if (other.GetComponent<ObstacleCtrl>().GetObstacleType == TypeID.KIT1)
            {
                playerController.AidKitEffect(1);
            }
            else if (other.GetComponent<ObstacleCtrl>().GetObstacleType == TypeID.KIT2)
            {
                playerController.AidKitEffect(2);
            }
            else if (other.GetComponent<ObstacleCtrl>().GetObstacleType == TypeID.CLOCK)
            {

            }
            other.gameObject.SetActive(false);
        }
    }
}
