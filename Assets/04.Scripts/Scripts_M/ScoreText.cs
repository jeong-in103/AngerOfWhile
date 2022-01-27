using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private Color alpha;

    private float moveSpeed;
    private float alphaSpeed;
    private float destroyTime;
    private float fontOriginSize;

    private bool isActive;

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        scoreText = GetComponentInChildren<TextMeshProUGUI>();

        alpha = new Color(1, 1, 1, 1);

        moveSpeed = 2.0f;
        alphaSpeed = 0.5f;
        destroyTime = 2.0f;
        fontOriginSize = scoreText.fontSize;

        isActive = false;
    }

    private void Update()
    {
        if(isActive)
        {
            // 텍스트 위치
            transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime));

            // 텍스트 알파값
            alpha.a = Mathf.Lerp(alpha.a, 0.5f, Time.deltaTime * alphaSpeed);
            scoreText.color = alpha;
        }
    }

    public void PrintScore(int Score)
    {
        if (Score <= 0)
        {
            Resetting();
        }

        scoreText.text = Score.ToString(); // 출력 값
        float temp = 1 + ((float)Score / 1000);
        scoreText.fontSize = temp > 2f ? (fontOriginSize * 2f) : fontOriginSize * temp;

        isActive = true;

        Invoke("Resetting", destroyTime);
    }


    private void Resetting()
    {
        alpha = new Color(1, 1, 1, 1);
        ObjectPool.ReturnObj(this.gameObject, (int)TypeID.TEXT);
    }
}
