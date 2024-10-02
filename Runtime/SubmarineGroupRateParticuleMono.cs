using UnityEngine;

public class SubmarineGroupRateParticuleMono : MonoBehaviour
{
    public SubmarinePercentToRateParticuleMono[] m_toAffect;
    public float m_currentPercentPower;

    public void SetPercentPower(float percentPower)
    {
        m_currentPercentPower = percentPower;
        foreach (var item in m_toAffect)
        {
            item.SetPercentPower(percentPower);
        }
    }

    [ContextMenu("Push current")]
    public void PushCurrentValue()
    {
        SetPercentPower(m_currentPercentPower);
    }
}
