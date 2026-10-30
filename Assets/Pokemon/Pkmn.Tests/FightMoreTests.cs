using Pkmn;
using NUnit.Framework;
using System;

namespace Pkmn.Tests
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer des features et les TU sur le reste du projet

        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        // - L'utilisation d'objets : Potion, SuperPotion, Vitess+, Attack+ etc.
        // - Gérer les PP (limite du nombre d'utilisation) d'une attaque,
        // si on selectionne une attack qui a 0 PP on inflige 0

        // Choisis ce que tu veux ajouter comme feature et fait en au max.
        // Les nouveaux TU doivent être dans ce fichier.
        // Modifiant des features il est possible que certaines valeurs
        // des TU précédentes ne matchent plus, tu as le droit de réadapter les valeurs
        // de ces anciens TU pour ta nouvelle situation.
        [Test]
        public void HealAboveMaxHealth()
        {
            var dracaufeu = new Character(1500, 50, 30, 20, TYPE.FIRE);
            var fireballbutithealsyouorsmth = new FireBall();
            var punch = new Punch();
            var oldHealth = dracaufeu.CurrentHealth;

            dracaufeu.ReceiveAttack(punch);

            Assert.That(dracaufeu.CurrentHealth,
                Is.EqualTo(oldHealth - (punch.Power - dracaufeu.Defense)));

            dracaufeu.ReceiveHeal(fireballbutithealsyouorsmth);

            Assert.That(dracaufeu.CurrentHealth, Is.EqualTo(dracaufeu.MaxHealth));
        }

        [Test]
        public void CharacterReceiveElementalAttack()
        {
            var dracaufeu = new Character(1500, 50, 30, 20, TYPE.FIRE);
            var fireball = new FireBall();
            var waterbloublou = new WaterBlouBlou();
            var magicalgrass = new MagicalGrass();
            var oldHealth = dracaufeu.CurrentHealth;

            dracaufeu.ReceiveAttack(fireball);
            Assert.That(dracaufeu.CurrentHealth,
                Is.EqualTo(oldHealth - (fireball.Power - dracaufeu.Defense)));

            oldHealth = dracaufeu.CurrentHealth;

            dracaufeu.ReceiveAttack(waterbloublou);
            Assert.That(dracaufeu.CurrentHealth,
                Is.EqualTo(oldHealth - ((int)(waterbloublou.Power * 1.2) - dracaufeu.Defense)));

            oldHealth = dracaufeu.CurrentHealth;

            dracaufeu.ReceiveAttack(magicalgrass);
            Assert.That(dracaufeu.CurrentHealth,
                Is.EqualTo(oldHealth - ((int)(magicalgrass.Power * 0.8) - dracaufeu.Defense)));
        }

        [Test]

        public void adjustHealthToMaxHealthOnUnequip()
        {
            var dracaufeu = new Character(1500, 50, 30, 20, TYPE.FIRE);
            var coolHat = new Equipment(2, 0, 0, -104);
            var fireballbutithealsyouorsmth = new FireBall();

            dracaufeu.Equip(coolHat);
            dracaufeu.ReceiveHeal(fireballbutithealsyouorsmth);

            Assert.That(dracaufeu.CurrentHealth, Is.EqualTo(dracaufeu.MaxHealth));

            dracaufeu.Unequip();
            Assert.That(dracaufeu.CurrentHealth, Is.EqualTo(dracaufeu.MaxHealth));
        }
    }
}
