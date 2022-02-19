using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayerScript : MonoBehaviour
{
    [SerializeField] Skeleton skeleton;

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("NO");
        }
    }

}
