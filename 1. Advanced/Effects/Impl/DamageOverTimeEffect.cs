using System;

using SSTraps.CharacterTest.Experimental.Level;
using SSTraps.Client.Extensions;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects.Impl
{
    public class DamageOverTimeEffect : CharacterEffectBase
    {
        private readonly Single _damagePerSecond;
        private readonly Single _effectTime;

        private Single _elapsedTime;

        public DamageOverTimeEffect(Single effectTime, Single damagePerSecond)
        {
            _effectTime = effectTime;
            _damagePerSecond = damagePerSecond;
        }

        protected override void Apply(RaidCharacter raidCharacter)
        {
            base.Apply(raidCharacter);
            _elapsedTime = 0;
            IsElapsed = false;
        }

        protected override void Update(RaidCharacter raidCharacter, Single deltaTime)
        {
            base.Update(raidCharacter, deltaTime);
            _elapsedTime += deltaTime;
            if (_elapsedTime <= _effectTime)
            {
                var damage = deltaTime*_damagePerSecond;
                raidCharacter.Health.Value -= damage;
            }
            else
            {
                IsElapsed = true;
            }
        }
    }

    public abstract class DamageEffectBase : CharacterEffectBase
    {
        public event Action<DamageEffectBase> Damaged;

        protected virtual void OnDamaged()
        {
            Damaged.SafeInvoke(this);
        }
    }
}