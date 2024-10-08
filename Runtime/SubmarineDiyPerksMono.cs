using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineDiyPerksMono : MonoBehaviour
{

    public Transform m_whatToMove;
    [Range(-1, 1)]
    public float m_rotateLeftRightValue;
    [Range(-1, 1)]
    public float m_frontalMoveValue;
    [Range(-1, 1)]
    public float m_verticalMoveValue;

    [Range(-1, 1)]
    public float m_lateralMoveValue;



    public float m_rotationSpeed = 90;
    public float m_frontMoveSpeed = 0.7f;
    public float m_backMoveSpeed = 0.3f;
    public float m_lateralMoveSpeed = 0.5f;
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

    public void SetLateralMove(float lateralMove)
    {
        m_lateralMoveValue = Mathf.Clamp(lateralMove, -1, 1);
    }


    public void Update()
    {
        if (m_whatToMove == null)
            return;

        m_whatToMove.transform.Rotate(Vector3.up, m_rotateLeftRightValue * m_rotationSpeed * Time.deltaTime);
        m_whatToMove.transform.Translate(Vector3.forward * m_frontalMoveValue * m_frontMoveSpeed * Time.deltaTime);
        m_whatToMove.transform.Translate(Vector3.up * m_verticalMoveValue * m_verticalMoveSpeed * Time.deltaTime);
        m_whatToMove.transform.Translate(Vector3.right * m_lateralMoveValue * m_lateralMoveSpeed * Time.deltaTime);
    }

    public void GetLateralMove(out float percentLateral)
    {
        percentLateral = m_lateralMoveValue;
    }

    public void GetVerticalMove(out float percentVertical)
    {
        percentVertical = m_verticalMoveValue;
    }

    public void GetForwardMove(out float percentForward)
    {
        percentForward = m_frontalMoveValue;
    }

    public void GetLeftRightRotate(out float percentRotateLeftRight)
    {
        percentRotateLeftRight = m_rotateLeftRightValue;
    }
}
