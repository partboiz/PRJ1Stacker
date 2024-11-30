using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private MapManager mapManager;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mapManager.LoadNextMap();
        }
    }
}
