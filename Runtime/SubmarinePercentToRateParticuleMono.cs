using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarinePercentToRateParticuleMono : MonoBehaviour
{

    [Range(0, 1)]
    public float m_percentPower;
    public float m_maxRate = 30;
    public bool m_inverseGivenValue;

    public ParticleSystem m_particule;
    public AnimationCurve m_rateParticule;

    private void Reset()
    {
        m_rateParticule = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

        m_particule = GetComponent<ParticleSystem>();

    }

    public void SetPercentPower(float percentPower)
    {
        if (m_inverseGivenValue)
        {
            m_percentPower = -percentPower;
        }
        else
        {
            m_percentPower = percentPower;

        }
    }

    void Update()
    {

        var emission = m_particule.emission;
        emission.rateOverTime = m_rateParticule.Evaluate(m_percentPower) * m_maxRate;


    }
}
