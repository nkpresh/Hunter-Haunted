using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerAttributeBase
{
    private float currentValue;
    private float maxValue;

    public float GetCurrent([Optional] bool normalize)
    {
        float currentValue = this.currentValue;
        if (normalize)
            currentValue = currentValue / maxValue;
        return currentValue;
    }

    public void Reduce(float amount)
    {
        currentValue -= amount;
        if (currentValue <= 0)
            currentValue = 0;
    }

    public void Increase(float amount)
    {
        currentValue += amount;
        if (currentValue >= maxValue)
            currentValue = maxValue;
    }
}
