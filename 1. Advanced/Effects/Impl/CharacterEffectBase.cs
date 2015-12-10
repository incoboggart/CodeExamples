using System;

using SSTraps.CharacterTest.Experimental.Level;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects.Impl
{
    public abstract class CharacterEffectBase : ICharacterEffect
    {
        protected Boolean IsElapsed { get; set; }

        Boolean ICharacterEffect.IsElapsed
        {
            get { return IsElapsed; }
        }

        void ICharacterEffect.Apply(RaidCharacter raidCharacter)
        {
            Apply(raidCharacter);
        }

        void ICharacterEffect.Discard(RaidCharacter raidCharacter)
        {
            Discard(raidCharacter);
        }

        void ICharacterEffect.Update(RaidCharacter raidCharacter, Single deltaTime)
        {
            Update(raidCharacter, deltaTime);
        }

        protected virtual void Apply(RaidCharacter raidCharacter)
        {
        }

        protected virtual void Discard(RaidCharacter raidCharacter)
        {
        }

        protected virtual void Update(RaidCharacter raidCharacter, Single deltaTime)
        {
        }
    }

    public abstract class KinematicCharacterEffectBase : CharacterEffectBase
    {
        public abstract void Reset();
    }
}