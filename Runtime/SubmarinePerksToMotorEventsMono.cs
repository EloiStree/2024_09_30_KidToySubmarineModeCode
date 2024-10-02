
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarinePerksToMotorEventsMono : MonoBehaviour
{

    public SubmarineDiyPerksMono m_sourceToObserve;

    [Header("Particule Motor Percent")]

    public UnityEvent<float> m_motorTowardBack;
    public UnityEvent<float> m_motorTowardForward;
    public UnityEvent<float> m_motorLeftFront;
    public UnityEvent<float> m_motorRightFront;
    public UnityEvent<float> m_motorLeftBack;
    public UnityEvent<float> m_motorRightBack;


    public SyringeMove m_syringeBack;
    public SyringeMove m_syringeFront;

    [System.Serializable]
    public class SyringeMove { 
    
    [Header("Syringe")]
    public Transform m_syringeToMove;
    public Transform m_from, m_to;
    public bool m_inverseSyringe = false;

    }
    public Transform m_buoyancyTopAnchor;
    public Transform m_buoyancyDownAnchor;



    void Update()
    {
        if (m_sourceToObserve == null)
            return;


        m_sourceToObserve.GetLateralMove(out float percentLateral);
        m_sourceToObserve.GetVerticalMove(out float percentVertical);
        m_sourceToObserve.GetForwardMove(out float percentForward);
        m_sourceToObserve.GetLeftRightRotate(out float percentRotateLeftRight); 
        
        float backPercent = percentForward < 0 ? Mathf.Abs(percentForward) : 0;
        float frontPercent = percentForward > 0 ? percentForward : 0;

        float frontLeftPercent = 0;
        float frontRightPercent = 0;
        float backLeftPercent = 0;
        float backRightPercent = 0;

        if (percentRotateLeftRight < 0)
        {
            frontRightPercent   += Mathf.Abs(percentRotateLeftRight)/2f;
            backLeftPercent     += Mathf.Abs(percentRotateLeftRight) / 2f;
        }
        else
        {
            frontLeftPercent += Mathf.Abs(percentRotateLeftRight) / 2f;
            backRightPercent += Mathf.Abs(percentRotateLeftRight) / 2f;
        }

        if(percentLateral < 0)
        {
            frontRightPercent += Mathf.Abs(percentLateral) / 2f;
            backRightPercent += Mathf.Abs(percentLateral) / 2f;
        }
        else
        {
            frontLeftPercent += Mathf.Abs(percentLateral) / 2f;
            backLeftPercent += Mathf.Abs(percentLateral) / 2f;
        }

        
        m_motorLeftFront.Invoke(frontLeftPercent);
        m_motorRightFront.Invoke(frontRightPercent);
        m_motorLeftBack.Invoke(backLeftPercent);
        m_motorRightBack.Invoke(backRightPercent);

        m_motorTowardBack.Invoke(backPercent);
        m_motorTowardForward.Invoke(frontPercent);




        
       

        float distanceFull =Mathf.Abs (m_buoyancyTopAnchor.position.y-m_buoyancyDownAnchor.position.y);
        float syringeDistanceBack = Mathf.Abs(m_syringeBack.m_syringeToMove.position.y - m_buoyancyDownAnchor.position.y); ;
        float syringeDistanceFront = Mathf.Abs(m_syringeFront.m_syringeToMove.position.y - m_buoyancyDownAnchor.position.y); ;

        float syringePercentBack = syringeDistanceBack / distanceFull;
        float syringePercentFront = syringeDistanceFront / distanceFull;
        m_syringePercentBack = syringePercentBack;
        m_syringePercentFront = syringePercentFront;


        m_syringeFront.m_syringeToMove.position = Vector3.Lerp(m_syringeFront.m_from.position, m_syringeFront.m_to.position,   (m_syringeFront.m_inverseSyringe ? 1- syringePercentFront : syringePercentFront));
        m_syringeBack.m_syringeToMove.position = Vector3.Lerp(m_syringeBack.m_from.position, m_syringeBack.m_to.position, (m_syringeBack.m_inverseSyringe ? 1- syringePercentBack : syringePercentBack));

        
    }
    public float m_syringePercentBack;
    public float m_syringePercentFront;
}
