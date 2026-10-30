         
using System;

namespace Pkmn
{
    /// <summary>
    /// Définition des types dans le jeu
    /// </summary>
    public enum TYPE { NORMAL, WATER, FIRE, GRASS }

    public class TypeResolver
    {

        /// <summary>
        /// Récupère le facteur multiplicateur pour la résolution des résistances/faiblesses
        /// WATER faible contre GRASS, resiste contre FIRE
        /// FIRE faible contre WATER, resiste contre GRASS
        /// GRASS faible contre FIRE, resiste contre WATER
        /// </summary>
        /// <param name="attacker">Type de l'attaque (le skill)</param>
        /// <param name="receiver">Type de la cible</param>
        /// <returns>
        /// Normal returns 1 if attacker or receiver
        /// 0.8 if resist
        /// 1.0 if same type
        /// 1.2 if vulnerable
        /// </returns>
        public static float GetFactor(TYPE attacker, TYPE receiver)
        {
            float result = 1f;

            switch (receiver)
            {
                case TYPE.WATER:
                    switch (attacker)
                    {
                        case TYPE.GRASS:
                            result = 1.2f;
                            break;
                        case TYPE.FIRE:
                            result = 0.8f;
                            break;
                    }
                    break;

                case TYPE.FIRE:
                    switch (attacker)
                    {
                        case TYPE.WATER:
                            result = 1.2f;
                            break;
                        case TYPE.GRASS:
                            result = 0.8f;
                            break;
                    }
                    break;

                case TYPE.GRASS:
                    switch (attacker)
                    {
                        case TYPE.FIRE:
                            result = 1.2f;
                            break;
                        case TYPE.WATER:
                            result = 0.8f;
                            break;
                    }
                    break;
            }
            return result;

        }

    }
}
