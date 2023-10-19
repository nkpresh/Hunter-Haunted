using Enums;

namespace Models
{
    public class AttackData
    {
        public AttackType attackType;
        public float attackEffect;

        public AttackData(AttackType attackType, float attackEffect)
        {
            this.attackType = attackType;
            this.attackEffect = attackEffect;
        }
    }
}