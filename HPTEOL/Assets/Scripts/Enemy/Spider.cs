using UnityEngine;
using System.Collections;

public class Spider : BaseEnemy
{
    [Header("Spider Stats")]
    [Range(0, 100)]
    [SerializeField] int JumpChance = 100;
    [Range(0f, 20f)]
    [SerializeField] float JumpPower = 6;
    [Range(0f, 20f)]
    [SerializeField] float JumpLeap = 2;

    /// <summary>
    /// Implement spider jumping
    /// </summary>
    public override void Target()
    {
        if (Random.Range(0, 100) < JumpChance)
        {
            if (Player.position.x < 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(Player.position.x + JumpLeap, transform.position.y + JumpPower), JumpPower * Time.deltaTime);
            } else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(Player.position.x - JumpLeap, transform.position.y + JumpPower), JumpPower * Time.deltaTime);
            }
        }
        base.Target();
    }
}
