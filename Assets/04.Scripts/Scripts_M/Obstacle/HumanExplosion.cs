using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanExplosion : MonoBehaviour
{
    private Transform tr;
    [SerializeField]
    private Rigidbody[] humanObj;

    [SerializeField]
    private float explosionForce;
    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private float upwardsModifier;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        humanObj = GetComponentsInChildren<Rigidbody>();
        for(int i = 0; i < humanObj.Length; i++)
        {
            humanObj[i].gameObject.SetActive(false);
        }
    }

    public void ExpHuman(int value)
    {
        for (int i = 0; i < value; i++)
        {
            humanObj[i].gameObject.SetActive(true);

            if (humanObj[i] != null)
            {
                humanObj[i].mass = 1.0f;
                humanObj[i].AddExplosionForce(explosionForce, tr.position, explosionRadius, upwardsModifier);
            }
        }
    }
}
