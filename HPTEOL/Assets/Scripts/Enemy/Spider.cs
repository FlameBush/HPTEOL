using UnityEngine;

// WIP Script
// WIP stands for?

public class Spider : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; //Rigidbody for Sipder.
    [SerializeField] Transform StartPosition, EndPosition; //Start and end position in which the spider would move.
    float distA, distB;
    // Update is called once per frame
    void Update()
    {
        distA = Vector2.Distance(transform.position, StartPosition.position);
        distB = Vector2.Distance(transform.position, EndPosition.position);
        if (groundCheck())
        {
            move();
        }
    }


    [Range(0f,10f)]
    [SerializeField] float speed;
    private bool goRight = true;
    /// <summary>
    /// this function is used to move the enemy left or right.
    /// </summary>
    void move()
    {
        if (goRight)
        {
            transform.position = Vector3.MoveTowards(transform.position,EndPosition.position,speed*Time.deltaTime);
            if (distB < 1)
            {
                goRight = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,StartPosition.position,speed*Time.deltaTime);
            if (distA < 1)
            {
                goRight = true;
            }
        }
    }


    [SerializeField] float k_GroundedRadius;
    [SerializeField] private LayerMask m_WhatIsGround;
    bool groundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, k_GroundedRadius);
    }
}
