using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundJudg : MonoBehaviour
{
    [Tooltip("�ڒn����")]bool isGround; public bool IsGroung => isGround;
    [Header("�ڒn���Ă���Ƃ݂Ȃ�����"), SerializeField] LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = IsGroundJudg();
    }

    bool IsGroundJudg()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
        if (raycastHit.collider == null)
        {
            return false;
        }
        return true;
    }
}
