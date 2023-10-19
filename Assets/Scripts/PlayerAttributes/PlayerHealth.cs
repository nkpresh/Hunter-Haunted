using UnityEngine;

public class PlayerHealth : PlayerAttributeBase
{
    bool isDead()
    {
        return GetCurrent() == 0;
    }
}