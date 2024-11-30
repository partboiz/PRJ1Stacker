using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputDetect;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask brickLayerMask;

    [SerializeField] float moveSpeed = 5f;
    Vector3 targetPos;
    Vector3 direction;

    private void OnEnable()
    {
        InputDetect.Swipe += Move;
    }


    private void OnDisable()
    {
        InputDetect.Swipe -= Move;
    }
    private void Start()
    {
        targetPos = transform.position;
    }
    private void Move(SwipeDirection swipe)
    {
        switch (swipe)
        {
            case SwipeDirection.Left:
                direction = Vector3.left;
                break;
            case SwipeDirection.Right:
                direction = Vector3.right;
                break;
            case SwipeDirection.Up:
                direction = Vector3.forward;
                break;
            case SwipeDirection.Down:
                direction = Vector3.back;
                break;
        }


        RaycastHit hit;

        for (int i = 1; i <= 50; i++)
        {


            if (Physics.Raycast(transform.position + direction * i + Vector3.up * 3.5f, Vector3.down, out hit, brickLayerMask))
            {
                Debug.DrawRay(transform.position + direction * i + Vector3.up * 3.5f, Vector3.down, Color.red, 1f);
                targetPos = hit.collider.transform.position;
                targetPos.y = transform.position.y;
            }

            else
            {
                return;
            }
        }

    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPos) < 0.02f)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}