using System;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    [Serializable]
    public struct Trigger
    {
        public GameObject Object;
        public Collider2D TriggerCol;
        public bool Destroy;
    }

    public Trigger[] Trigs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var trig in Trigs)
        {
            if (collision == trig.TriggerCol)
            {
                trig.Object.SetActive(true);
                if (trig.Destroy)
                {
                    Destroy(trig.TriggerCol.gameObject);
                }
            }
        }
    }
}
