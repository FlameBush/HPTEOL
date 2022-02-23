using UnityEngine;

public class Skeleton : BaseEnemy
{
    [Header("Skeleton Stats")]
    [Range(0, 100)]
    [SerializeField] int FlameChance = 6;

    private Animator animator;

    public override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    /// <summary>
    /// Implement skeleton flame
    /// </summary>
    public override void Target()
    {
        if (Random.Range(0, 1000) < FlameChance)
        {
            Debug.Log("Flame");
        }
        base.Target();
    }
}
