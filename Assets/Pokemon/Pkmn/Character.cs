using System;

namespace Pkmn
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;

            CurrentHealth = baseHealth;

        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return _baseHealth;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                return _baseAttack;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                return _baseDefense;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                return _baseSpeed;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive => CurrentHealth > 0;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            float TypeFactor = TypeResolver.GetFactor(s.Type, _baseType);
            CurrentHealth -= (int)(s.Power * TypeFactor) - Defense;
            CurrentHealth = Math.Max(CurrentHealth, 0);
        }

        public void ReceiveHeal(Skill s)
        {
            CurrentHealth += s.Power;
            CurrentHealth = Math.Min(CurrentHealth, MaxHealth);
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment != null)
            {
                _baseHealth += newEquipment.BonusHealth;
                _baseAttack += newEquipment.BonusAttack;
                _baseDefense += newEquipment.BonusDefense;
                _baseSpeed += newEquipment.BonusSpeed;

                CurrentEquipment = newEquipment;
            }
            else throw new ArgumentNullException();
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            if (CurrentEquipment != null)
            {
                _baseHealth -= CurrentEquipment.BonusHealth;
                _baseAttack -= CurrentEquipment.BonusAttack;
                _baseDefense -= CurrentEquipment.BonusDefense;
                _baseSpeed -= CurrentEquipment.BonusSpeed;

                CurrentHealth = Math.Min(CurrentHealth, MaxHealth);

                CurrentEquipment = null;
            }
            else throw new ArgumentNullException();
        }

    }
}
