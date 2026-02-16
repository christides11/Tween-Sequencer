using PrimeTween;
using UnityEngine;

namespace ct.tweensequence
{
    [System.Serializable]
    public class TweenSequencePart
    {
        public TweenSequencePartType partType;

        public virtual void SetTarget(GameObject target)
        {

        }

        public virtual void BuildSequence(ref Sequence sequence)
        {

        }
    }
}