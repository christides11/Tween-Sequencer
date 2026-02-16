using System;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

namespace ct.tweensequence
{
    [System.Serializable]
    public class TweenSequenceContainer
    {
        [SerializeReference, SubclassSelector] public List<TweenSequencePart> parts = new();
        public Sequence.SequenceCycleMode cycleMode = Sequence.SequenceCycleMode.Restart;
        public Ease ease = Ease.Linear;

        public Sequence BuildSequence(int cycles = 1, bool useUnscaledTime = false, UpdateType updateType = default,
            Action onComplete = null)
        {
            Sequence sequence = Sequence.Create(cycles, cycleMode, ease, useUnscaledTime, updateType);

            foreach (var t in parts)
            {
                t.BuildSequence(ref sequence);
            }

            if (onComplete != null) sequence.ChainCallback(onComplete);
            return sequence;
        }
    }
}