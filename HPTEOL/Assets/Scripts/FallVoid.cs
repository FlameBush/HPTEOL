using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallVoid : MonoBehaviour
{
        [SerializeField] float DeathPoint = -10;

        void FixedUpdate()
        {
            if (transform.position.y < DeathPoint)
                transform.position = new Vector3(0, 5, 0);
        }
}
