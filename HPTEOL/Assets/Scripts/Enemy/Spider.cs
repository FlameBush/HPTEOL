using UnityEngine;

public class Spider : BaseEnemy
{
    public override void Target()
    {
        Debug.Log("Im a spidah");
        base.Target();
    }
}
