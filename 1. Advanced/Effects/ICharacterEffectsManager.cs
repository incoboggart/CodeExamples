using System;

using SSTraps.CharacterTest.Experimental.Level;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects
{
    public interface ICharacterEffectsManager
    {
        void ApplyEffect(ICharacterEffect effect);
        void DiscardEffect(ICharacterEffect effect);
        void Update(RaidContext raidContext);

        event Action<ICharacterEffect> Applyed;
        event Action<ICharacterEffect> Discarded;
    }
}