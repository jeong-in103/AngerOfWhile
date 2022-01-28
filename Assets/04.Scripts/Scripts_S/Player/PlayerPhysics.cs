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
    private GameObject enemy;
    private Vector3 colliderStartSize;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        colliderStartSize = boxCollider.size;
    }

    private void Update()
    {
        //Box Collider ��ġ ������ ���� (�� ���ҽ� ������ �ϵ��ڵ�)
        if (playerController.state == PlayerController.State.IDLE)
        {
            boxCollider.enabled = true;
            boxCollider.center = new Vector3(0.06f, 0.03f, boxCollider.center.z);
            boxCollider.size = colliderStartSize;
        }
        else if (playerController.state == PlayerController.State.DIVE)
        {
            boxCollider.enabled = true;
            boxCollider.center = new Vector3(0.04f, -0.05f, boxCollider.center.z);
            boxCollider.size = colliderStartSize;
        }
        else if (playerController.state == PlayerController.State.ATTACK)
        {
            if (playerController.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f)
            {
                boxCollider.enabled = false;
            }
            else
            {
                boxCollider.enabled = true;
            }
            boxCollider.center = new Vector3(0.06f, 0.03f, boxCollider.center.z);
            boxCollider.size = new Vector3(0.15f, 0.3f, 0.1f);
        }
        else
        {
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //���� �� �ε��� ��� �Ѿ��
            if (enemy == other.gameObject)
            {
                return;
            }

            //�� �ε��� ��� �����
            if ((playerController.state == PlayerController.State.IDLE || playerController.state == PlayerController.State.DIVE))
            {
                enemy = other.gameObject;

                //�� �浹�� Anger Gage �ø���
                if (enemy.CompareTag("Sub"))
                {
                    GameManager.angerValue += 50;
                }
                else
                {
                    GameManager.angerValue += 10;
                }
                //����� ȿ��
                playerController.OnDamage();
            }

            // ������ ��츸 Attakced ��Ű��
            if ((playerController.state == PlayerController.State.ATTACK))
            {
                enemy = other.gameObject;
                if (other.gameObject.CompareTag("Oil")) //�⸧ �������� ��� ������ 
                {
                    //����� ȿ��
                    playerController.OnDamage();

                }

                other.gameObject.GetComponent<ObstacleAttacked>().Attacked(1);
            }
        }
        //������ �ε��� ���
        else if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            if (other.GetComponent<ObstacleCtrl>().GetObstacleType == TypeID.HEL1)
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

            other.gameObject.SetActive(false);
        }
    }
}