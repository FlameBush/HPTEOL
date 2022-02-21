using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; //Rigidbody for Sipder.
    [SerializeField] Transform StartPosition, EndPosition; //Start and end position in which the spider would move.
    [SerializeField] bool grounded; //to check whether the spider is grounded.


    // Update is called once per frame
    void Update()
    {
        groundCheck();
        if (grounded)
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
    void groundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }


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
