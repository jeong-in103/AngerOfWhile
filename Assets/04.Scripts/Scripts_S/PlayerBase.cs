using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected enum State { IDLE, DIVE, ATTACK, DAMAGE };
    protected State state;

    // Variable
    protected float timeSpeed = 29f; // ���� �ð� �ӵ�
    protected float moveSpeed = 8f; // �̵� �ӵ�
    protected float InvincibleTime = 1f; // ���� �ð�

    protected int hp; // ü��
    protected int stemina; // ���޻��� �߰� HP
    protected int helmat; // ��� ����
}
