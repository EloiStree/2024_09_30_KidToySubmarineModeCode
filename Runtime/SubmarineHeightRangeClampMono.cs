using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineHeightRangeClampMono : MonoBehaviour
{


    public Transform m_whatToMove;

    public Transform m_topWaterAnchor;
    public Transform m_bottomWaterAnchor;
    public Transform m_submarineCenterPoint;
    public Transform m_submarineRadiusPointUp;
    public Transform m_submarineRadiusPointDown;

    public float m_currentRadiusTop = 0.5f;
    public float m_currentRadiusDown = 0.5f;

    private void Reset()
    {
        m_whatToMove = transform;
    }

    void LateUpdate()
    {

        if (m_whatToMove == null)
            return;

        if (m_topWaterAnchor == null || m_bottomWaterAnchor == null)
            return;

        if (m_submarineCenterPoint == null || m_submarineRadiusPointUp == null)
            return;

        m_currentRadiusTop = Vector3.Distance(
            m_submarineCenterPoint.position,
            m_submarineRadiusPointUp.position);

        m_currentRadiusDown = Vector3.Distance(
            m_submarineCenterPoint.position,
            m_submarineRadiusPointDown.position);


        if(m_whatToMove.position.y > m_topWaterAnchor.position.y- m_currentRadiusTop)
        {
            m_whatToMove.position = new Vector3(m_whatToMove.position.x, m_topWaterAnchor.position.y - m_currentRadiusTop, m_whatToMove.position.z);
        }
        if (m_whatToMove.position.y < m_bottomWaterAnchor.position.y+ m_currentRadiusDown)
        {
            m_whatToMove.position = new Vector3(m_whatToMove.position.x, m_bottomWaterAnchor.position.y + m_currentRadiusDown, m_whatToMove.position.z);
        }
    }
}
