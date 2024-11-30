using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;  // Mảng chứa các prefab map
    public Transform playerTransform;  // Transform của player
    private GameObject currentMap;
    private int currentMapIndex = 0;

    void Start()
    {
        LoadMap(0);  // Load map đầu tiên khi bắt đầu game
    }

    public void LoadNextMap()
    {
        currentMapIndex++;
        if (currentMapIndex >= mapPrefabs.Length)
        {
            currentMapIndex = 0;  // Quay lại map đầu tiên nếu đã hết map
        }
        LoadMap(currentMapIndex);
    }

    void LoadMap(int index)
    {
        Vector3 playerPosition = Vector3.zero;
        if (currentMap != null)
        {
            playerPosition = playerTransform.position - currentMap.transform.position;
            Destroy(currentMap);
        }

        currentMap = Instantiate(mapPrefabs[index], Vector3.zero, Quaternion.identity);
        playerTransform.position = currentMap.transform.position + playerPosition;
    }
}
