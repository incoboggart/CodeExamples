using System;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects
{
    public interface ICharacterEffectInteractionSettings
    {
        Boolean Blocks(ICharacterEffect effect);
        Boolean Discards(ICharacterEffect effect);
    }
}