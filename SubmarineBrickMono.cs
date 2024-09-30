using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineBrickMono : MonoBehaviour
{

    public Transform m_whatToMove;
    [Range(-1,1)]
    public float m_rotateLeftRightValue;
    [Range(-1, 1)]
    public float m_frontalMoveValue;
    [Range(-1, 1)]
    public float m_verticalMoveValue;

    public float m_rotationSpeed = 90;
    public float m_frontMoveSpeed = 0.7f;
    public float m_backMoveSpeed = 0.3f;
    public float m_verticalMoveSpeed = 0.2f;


    public void SetFrontalMove(float backForward)
    {
        m_frontalMoveValue = Mathf.Clamp(backForward, -1, 1);
    }
    public void SetVerticalMove(float upDown)
    {
        m_verticalMoveValue = Mathf.Clamp(upDown, -1, 1);
    }
    public void SetLeftRightRotate(float rotateLeftRight)
    {
        m_rotateLeftRightValue = Mathf.Clamp(rotateLeftRight, -1, 1);
    }


    public void Update()
    {
        if (m_whatToMove == null)
            return;

        m_whatToMove.transform.Rotate(Vector3.up, m_rotateLeftRightValue * m_rotationSpeed * Time.deltaTime);
        m_whatToMove.transform.Translate(Vector3.forward * m_frontalMoveValue* m_frontMoveSpeed * Time.deltaTime);
        m_whatToMove.transform.Translate(Vector3.up * m_verticalMoveValue * m_verticalMoveSpeed * Time.deltaTime);
    }


}
