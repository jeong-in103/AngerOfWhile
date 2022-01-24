using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected enum State { IDLE, DIVE, ATTACK, DAMAGE };
    protected State state;

    // Variable
    protected float timeSpeed = 29f; // 정지 시간 속도
    protected float moveSpeed = 8f; // 이동 속도
    protected float InvincibleTime = 1f; // 무적 시간

    protected int hp; // 체력
    protected int stemina; // 구급상자 추가 HP
    protected int helmat; // 헬멧 갯수
}
