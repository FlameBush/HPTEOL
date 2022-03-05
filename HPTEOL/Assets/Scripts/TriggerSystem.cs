using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    [SerializeField] GameObject cameratoEnable;
    [SerializeField] GameObject cameratoDisable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cameratoEnable.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cameratoDisable.SetActive(false);
    }
}
