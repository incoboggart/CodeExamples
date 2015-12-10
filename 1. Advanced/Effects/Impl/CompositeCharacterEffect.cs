using System;
using System.Collections;
using System.Collections.Generic;

using SSTraps.CharacterTest.Experimental.Level;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects.Impl
{
    public class CompositeCharacterEffect : ICollection<ICharacterEffect>, ICharacterEffect
    {
        private readonly ICollection<ICharacterEffect> _effects;
        private Boolean _isElapsed;

        public CompositeCharacterEffect() : this(new List<ICharacterEffect>())
        {
        }

        public CompositeCharacterEffect(Int32 capacity) : this(new List<ICharacterEffect>(capacity))
        {
        }

        public CompositeCharacterEffect(IEnumerable<ICharacterEffect> effects)
            : this(new List<ICharacterEffect>(effects))
        {
        }

        public CompositeCharacterEffect(ICollection<ICharacterEffect> effects)
        {
            _effects = effects;
        }

        #region ICharacterEffect

        Boolean ICharacterEffect.IsElapsed
        {
            get { return _isElapsed; }
        }

        void ICharacterEffect.Apply(RaidCharacter raidCharacter)
        {
            _isElapsed = true;
            foreach (var effect in _effects)
            {
                effect.Apply(raidCharacter);
                _isElapsed = _isElapsed && effect.IsElapsed;
            }
        }

        void ICharacterEffect.Update(RaidCharacter raidCharacter, Single deltaTime)
        {
            _isElapsed = true;
            foreach (var effect in _effects)
            {
                if (effect.IsElapsed)
                {
                    continue;
                }
                effect.Update(raidCharacter, deltaTime);
                _isElapsed = _isElapsed && effect.IsElapsed;
            }
        }

        void ICharacterEffect.Discard(RaidCharacter raidCharacter)
        {
            foreach (var effect in _effects)
            {
                effect.Discard(raidCharacter);
            }
        }

        #endregion

        #region ICollection<ICharacterEffect>

        public Int32 Count
        {
            get { return _effects.Count; }
        }

        public void Add(ICharacterEffect item)
        {
            _effects.Add(item);
        }

        public void Clear()
        {
            _effects.Clear();
        }

        public Boolean Contains(ICharacterEffect item)
        {
            return _effects.Contains(item);
        }

        public Boolean Remove(ICharacterEffect item)
        {
            return _effects.Remove(item);
        }

        Boolean ICollection<ICharacterEffect>.IsReadOnly
        {
            get { return false; }
        }

        void ICollection<ICharacterEffect>.CopyTo(ICharacterEffect[] array, Int32 arrayIndex)
        {
            _effects.CopyTo(array, arrayIndex);
        }

        IEnumerator<ICharacterEffect> IEnumerable<ICharacterEffect>.GetEnumerator()
        {
            return _effects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _effects.GetEnumerator();
        }

        #endregion
    }
}