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
    public float m_radiusTopDown = 0;
    public float m_radiusTopSubmarine = 0;
    [Range(0,1)]
    public float m_percentBoyancy = 0.5f;

    public Color m_color= Color.magenta;

    private void Reset()
    {
        m_whatToMove = transform;
    }


    public void Update()
    {

        Debug.DrawLine(m_topWaterAnchor.position, m_bottomWaterAnchor.position, m_color);
        Debug.DrawLine(m_topWaterAnchor.position, m_submarineRadiusPointUp.position, m_color);

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

        m_radiusTopDown= Vector3.Distance(
            m_topWaterAnchor.position,
            m_bottomWaterAnchor.position);

        m_radiusTopSubmarine = Vector3.Distance(
            m_topWaterAnchor.position,
            m_submarineCenterPoint.position);

        m_percentBoyancy = m_radiusTopSubmarine / m_radiusTopDown;


        downY = m_bottomWaterAnchor.position.y + m_currentRadiusDown;
        upY = m_topWaterAnchor.position.y - m_currentRadiusTop;
        submarineY = m_submarineCenterPoint.position.y;

        if (submarineY > upY)
        {
            m_whatToMove.position = new Vector3(m_whatToMove.position.x, upY, m_whatToMove.position.z);
        }

        if (submarineY < downY)
        {
            m_whatToMove.position = new Vector3(m_whatToMove.position.x, downY, m_whatToMove.position.z);
        }

    }
    public float upY;
    public float downY;
    public float submarineY;
}
