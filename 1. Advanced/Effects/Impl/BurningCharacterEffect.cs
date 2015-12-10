using System;

using SSTraps.CharacterTest.Experimental.Level;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects.Impl
{
    public sealed class BurningCharacterEffect : DamageEffectBase
    {
        private readonly Single _damagePerTick;
        private readonly Single _effectTime;
        private readonly Single _tickTime;

        private Single _elapsedTime;
        private Int32 _ticks;

        public BurningCharacterEffect(Single effectTime, Single tickTime, Single damagePerTick)
        {
            _effectTime = effectTime;
            _tickTime = tickTime;
            _damagePerTick = damagePerTick;
        }

        protected override void Apply(RaidCharacter raidCharacter)
        {
            base.Apply(raidCharacter);
            IsElapsed = false;
            _elapsedTime = 0;
            _ticks = 0;
        }

        protected override void Update(RaidCharacter raidCharacter, Single deltaTime)
        {
            base.Update(raidCharacter, deltaTime);
            _elapsedTime += deltaTime;
            if (_elapsedTime < _effectTime)
            {
                var ticks = (Int32) (_elapsedTime/_tickTime);
                if (ticks > _ticks)
                {
                    _ticks = ticks;
                    raidCharacter.Health.Value -= _damagePerTick;
                    OnDamaged();
                }
            }
            else
            {
                IsElapsed = true;
            }
        }
    }
}