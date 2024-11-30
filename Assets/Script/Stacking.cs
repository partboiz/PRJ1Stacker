using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    [SerializeField] Transform playerVisual;

    [SerializeField] private GameObject brickPrefabs;
    [SerializeField] private Transform brickListParent;
    public List<GameObject> bricks = new List<GameObject>();
   

    public void AddBrick(GameObject brick)
    {
        bricks.Add(brick); ///them 1 gach moi vao trong list
                           ///TODO: xu ly hinh anh
        playerVisual.transform.position += Vector3.up * 0.25f;

        brick.transform.localPosition = Vector3.up * 0.25f * (bricks.Count - 1);
    }

    public void RemoveBrick()
    {
        if (bricks.Count > 0)
        {
            playerVisual.transform.position -= Vector3.up * 0.25f;
            GameObject removedBrick = bricks[bricks.Count - 1];
            bricks.RemoveAt(bricks.Count - 1);
            Destroy(removedBrick); // Hủy Brick đã loại bỏ (có thể thay đổi tùy yêu cầu)
            Debug.Log("Brick removed. Stack size: " + bricks.Count);
        }
        else
        {
            Debug.Log("Stack is empty.");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stackable"))
        {
            ///xoa gach bi an o duoi chan nguoi choi
            Destroy(other.gameObject);
            /// bao gio an thi sinh ra gach moi
            GameObject newBrick = Instantiate(brickPrefabs, brickListParent);
            AddBrick(newBrick);
        }
        
    }
}
