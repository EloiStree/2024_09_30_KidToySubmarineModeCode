using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineBrickToMotorEventsMono : MonoBehaviour
{

    public SubmarineBrickMono m_sourceToObserve;


    [Header("Blade")]
    public Transform m_frontalBladeToRotate;
    public Vector3 m_directionFrontalBlade= Vector3.forward;
    public float m_frontalBladeRotationSpeed = 720f;
    public Transform m_horizontalBladeToRotate;
    public Vector3 m_directionHorizontalBlade = Vector3.forward;
    public float m_horizontalBladeRotationSpeed = 720f;

    [Header("Syringe")]
    public Transform m_syringeToMove;
    public Transform m_from, m_to;
    public bool m_inverseSyringe = false;

    public Transform m_buoyancyTopAnchor;
    public Transform m_buoyancyDownAnchor;

    [Range(0,1)]
    public float m_buoyancyPercent;


    void Update()
    {
        if (m_sourceToObserve == null)
            return;

        if (m_frontalBladeToRotate != null) {

            float percent = m_sourceToObserve.GetFrontalMovePercent();
            m_frontalBladeToRotate.Rotate(m_directionFrontalBlade, m_frontalBladeRotationSpeed * percent * Time.deltaTime, Space.Self);
        }       
        if (m_horizontalBladeToRotate != null) {

            float percent = m_sourceToObserve.GetHorizontalMovePercent();
            m_horizontalBladeToRotate.Rotate(m_directionHorizontalBlade, m_horizontalBladeRotationSpeed * percent * Time.deltaTime, Space.Self);
        }

        float distanceFull= Vector3.Distance(m_buoyancyTopAnchor.position, m_buoyancyDownAnchor.position);
        float syringeDistance = Vector3.Distance(m_syringeToMove.position, m_buoyancyDownAnchor.position);
        m_buoyancyPercent = syringeDistance / distanceFull;

        if (m_syringeToMove!=null &&  m_from!=null && m_to!=null)
        {
            m_syringeToMove.position = Vector3.Lerp(m_from.position, m_to.position, m_buoyancyPercent*(m_inverseSyringe?-1:1));
        }
    }
}
