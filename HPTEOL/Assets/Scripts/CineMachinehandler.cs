using UnityEngine;

public class CineMachinehandler : MonoBehaviour
{
    public static CineMachinehandler instance;
    [SerializeField] Animator cmAnimator;
    private void Awake()
    {
        instance = this;
    }

    public void ChangeCamera(string RoomName)
    {
        cmAnimator.Play(RoomName);
    }
}
