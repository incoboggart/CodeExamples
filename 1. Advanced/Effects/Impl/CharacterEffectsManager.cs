using System;
using System.Collections.Generic;

using SSTraps.CharacterTest.Experimental.Level;
using SSTraps.CharacterTest.Experimental.Raid.Characters.Ultimates.Impl.Dash;
using SSTraps.CharacterTest.Experimental.Raid.Characters.Ultimates.Impl.Invisibility;
using SSTraps.CharacterTest.Experimental.Raid.Characters.Ultimates.Impl.ShieldRush;
using SSTraps.Client.CharacterTest.Experimental.Raid.Characters.Effects.Impl;
using SSTraps.Client.Extensions;

using UnityEngine;

namespace SSTraps.CharacterTest.Experimental.Raid.Characters.Effects.Impl
{
    public class CharacterEffectsManager : ICharacterEffectsManager
    {
        private readonly IList<ICharacterEffect> _effects = new List<ICharacterEffect>();

        private readonly IDictionary<Type, ICharacterEffectInteractionSettings> _effectSettings =
            new Dictionary<Type, ICharacterEffectInteractionSettings>();

        private readonly RaidCharacter _raidCharacter;

        public CharacterEffectsManager(RaidCharacter raidCharacter)
        {
            _raidCharacter = raidCharacter;
        }

        public event Action<ICharacterEffect> Applyed;
        public event Action<ICharacterEffect> Discarded;

        void ICharacterEffectsManager.ApplyEffect(ICharacterEffect effect)
        {
            foreach (var e in _effects)
            {
                var settings = _effectSettings[e.GetType()];
                if (settings.Blocks(e))
                {
                    return;
                }
            }

            effect.Apply(_raidCharacter);
            var effectType = effect.GetType();
            ICharacterEffectInteractionSettings effectSettings;
            if (!_effectSettings.TryGetValue(effectType, out effectSettings))
            {
                Debug.LogErrorFormat("Effect settings are not set for {0}", effectType.Name);
                return;
            }

            var effectIndex = 0;
            while (effectIndex < _effects.Count)
            {
                var e = _effects[effectIndex];
                if (effectSettings.Discards(e))
                {
                    _effects.Remove(e);
                    e.Discard(_raidCharacter);
                    Discarded.SafeInvoke(e);
                }
                else
                {
                    effectIndex++;
                }
            }

            Applyed.SafeInvoke(effect);

            if (effect.IsElapsed)
            {
                effect.Discard(_raidCharacter);
                Discarded.SafeInvoke(effect);
            }
            else
            {
                _effects.Add(effect);
            }
        }

        void ICharacterEffectsManager.Update(RaidContext raidContext)
        {
            var effectIndex = 0;
            while (effectIndex < _effects.Count)
            {
                var e = _effects[effectIndex];
                e.Update(_raidCharacter, (Single) raidContext.DeltaTime.TotalSeconds);
                if (e.IsElapsed)
                {
                    _effects.RemoveAt(effectIndex);
                    e.Discard(_raidCharacter);
                    Discarded.SafeInvoke(e);
                }
                else
                {
                    effectIndex++;
                }
            }
        }

        void ICharacterEffectsManager.DiscardEffect(ICharacterEffect effect)
        {
            if (_effects.Remove(effect))
            {
                effect.Discard(_raidCharacter);
                Discarded.SafeInvoke(effect);
            }
        }

        public void Set<T>(ICharacterEffectInteractionSettings settings)
            where T : ICharacterEffect
        {
            _effectSettings[typeof (T)] = settings;
        }

        public static ICharacterEffectsManager Create(RaidCharacter raidCharacter)
        {
            var manager = new CharacterEffectsManager(raidCharacter);
            manager.Set<DashCharacterEffect>()
                .DiscardAndBlock<FlamethrowerCharacterEffect>()
                .DiscardAndBlock<CoalsCharacterEffect>();

            manager.Set<ShieldRushCharacterEffect>()
                .DiscardAndBlock<FlamethrowerCharacterEffect>()
                .DiscardAndBlock<CoalsCharacterEffect>()
                .Block<ElectroshockCharacterEffect>();

            manager.Set<InvisibilityCharacterEffect>();

            manager.Set<FlamethrowerCharacterEffect>().Discard<FlamethrowerCharacterEffect>();

            manager.Set<CoalsCharacterEffect>();

            manager.Set<ElectroshockCharacterEffect>();

            manager.Set<InstantDamageCharacterEffect>();

            manager.Set<InvincibilityCharacterEffect>()
                .DiscardAndBlock<FlamethrowerCharacterEffect>()
                .DiscardAndBlock<ElectroshockCharacterEffect>()
                .DiscardAndBlock<CoalsCharacterEffect>()
                .Block<InstantDamageCharacterEffect>();

            manager.Set<ThumbleCharacterEffect>()
                .DiscardAndBlock<FlamethrowerCharacterEffect>()
                .DiscardAndBlock<FlamethrowerCharacterEffect>();

            manager.Set<JumpCharacterEffect>();

            manager.Set<HitStunCharacterEffect>();
            manager.Set<TreadmillDecreaseSpeedEnterCharacterEffect>();
            manager.Set<TreadmillIncreaseSpeedEnterCharacterEffect>();
            manager.Set<SimpleAnimCurveWorldSpeedCharacterEffect>();


            manager.Set<DeathCharacterEffect>()
                .DiscardAndBlock<FlamethrowerCharacterEffect>()
                .DiscardAndBlock<ElectroshockCharacterEffect>()
                .DiscardAndBlock<CoalsCharacterEffect>()
                .DiscardAndBlock<InstantDamageCharacterEffect>();


            manager.Set<CharacterSwitchOffEffect>()
                .Discard<InvisibilityCharacterEffect>();

            return manager;
        }
    }
}