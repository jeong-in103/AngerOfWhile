using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartControl : MonoBehaviour
{
    public Image[] heartsParent;

    public Image[] addHeart; //�߰� ü��
    private Image[] hearts;  //�⺻ ü��


    private void Awake()
    {
        hearts = new Image[heartsParent.Length];
    }

    private void Start()
    {
        for (int i = 0; i < heartsParent.Length; i++)
        {
            hearts[i] = heartsParent[i].transform.GetChild(0).GetComponent<Image>();
        }

        //�ʱ� HP 3�� �̿��� UI Off
        for (int i=0; i < addHeart.Length; i++)
        {
            addHeart[i].gameObject.SetActive(false);
        }
    }
    //�߰� ü��
    public void AddHeart()
    {
        if (!addHeart[0].gameObject.activeSelf)
        {
            addHeart[0].gameObject.SetActive(true);
        }
        else if (!addHeart[1].gameObject.activeSelf)
        {
            addHeart[1].gameObject.SetActive(true);
        }
    }

    //�߰� ü�� ����
    public void RemoveHeart()
    {
        if (addHeart[0].gameObject.activeSelf)
        {
            addHeart[0].gameObject.SetActive(false);
        }
        else if (addHeart[1].gameObject.activeSelf)
        {
            addHeart[1].gameObject.SetActive(false);
        }
    }

    //ü�� ȸ��,����
    public void ChangeHP(int currentHP)
    {
        for (int i = 0; i < heartsParent.Length; i++)
        {
            if (i <= currentHP - 1)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}