using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    //[SerializeField] private GameObject WorldEnd;
    [SerializeField] private Transform SpawningPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "End of World")
        {
            transform.position = SpawningPoint.position;
        }
    }
}
