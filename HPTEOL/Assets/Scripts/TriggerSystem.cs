using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    [SerializeField] string roomName;
    //[SerializeField] GameObject cameratoEnable;
    //[SerializeField] GameObject cameratoDisable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CineMachinehandler.instance.ChangeCamera(roomName);
        }
        //cameratoEnable.SetActive(true);
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    //cameratoDisable.SetActive(false);
    //}
}
