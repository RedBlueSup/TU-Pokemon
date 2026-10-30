
namespace Pkmn
{
    /// <summary>
    /// Défintion simple d'un équipement apportant des boost de stats
    /// </summary>
    public class Equipment
    {

        int _bonusHealth;
        int _bonusAttack;
        int _bonusDefense;
        int _bonusSpeed;

        public Equipment(int bonusHealth, int bonusAttack, int bonusDefense, int bonusSpeed)
        {
            _bonusHealth = bonusHealth;
            _bonusAttack = bonusAttack;
            _bonusDefense = bonusDefense;
            _bonusSpeed = bonusSpeed;
        }

        public int BonusHealth { get { return _bonusHealth; }}
        
        public int BonusAttack { get { return _bonusAttack; } }
        public int BonusDefense { get { return _bonusDefense; } }
        public int BonusSpeed { get { return _bonusSpeed; } }

    }
}
