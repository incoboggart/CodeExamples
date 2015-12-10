using System;

using SSTraps.CharacterTest.Experimental.Level;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects
{
    public interface ICharacterEffect
    {
        Boolean IsElapsed { get; }
        void Apply(RaidCharacter raidCharacter);
        void Update(RaidCharacter raidCharacter, Single deltaTime);
        void Discard(RaidCharacter raidCharacter);
    }
}