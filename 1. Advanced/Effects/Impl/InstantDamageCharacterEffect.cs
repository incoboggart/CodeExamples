using System;

using SSTraps.CharacterTest.Experimental.Level;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects.Impl
{
    public class InstantDamageCharacterEffect : DamageEffectBase
    {
        private readonly Single _damage;

        public InstantDamageCharacterEffect(Single damage)
        {
            _damage = damage;
        }

        protected override void Update(RaidCharacter raidCharacter, Single deltaTime)
        {
            base.Update(raidCharacter, deltaTime);
            raidCharacter.Health.Value -= _damage;
            IsElapsed = true;
            OnDamaged();
        }
    }
}