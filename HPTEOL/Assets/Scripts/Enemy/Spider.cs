using UnityEngine;

// WIP Script

public class Spider : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; //Rigidbody for Sipder.
    [SerializeField] Transform StartPosition, EndPosition; //Start and end position in which the spider would move.

    // Update is called once per frame
    void Update()
    {
        if (groundCheck())
        {
            move();
        }
    }


    [Range(0f,10f)]
    [SerializeField] float speed;
    void move()
    {
        transform.position += (StartPosition.position*speed*Time.deltaTime);
    }


    //RaycastHit2D hit;
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

        //hit = Physics2D.Raycast(transform.position, Vector2.down,groundCheckLength);
        ////Debug.Log(hit.collider.gameObject.name);
        //if (hit.collider.gameObject.CompareTag("Floor"))
        //{
        //    Debug.Log("On Floor");
        //    grounded = true;
        //}
        //else
        //    grounded = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, k_GroundedRadius);

    }
}
