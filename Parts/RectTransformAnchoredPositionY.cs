using PrimeTween;
using UnityEngine;

namespace ct.tweensequence
{
    [System.Serializable]
    public class RectTransformAnchoredPositionY : TweenSequencePart
    {
        public RectTransform transform;
        [SerializeField] public TweenSettings<float> settings;

        public override void SetTarget(GameObject target)
        {
            transform = target.GetComponent<RectTransform>();
        }

        public override void BuildSequence(ref Sequence sequence)
        {
            switch (partType)
            {
                case TweenSequencePartType.Chain:
                    sequence.Chain(Tween.UIAnchoredPositionY(transform, settings));
                    break;
                case TweenSequencePartType.Group:
                    sequence.Group(Tween.UIAnchoredPositionY(transform, settings));
                    break;
            }
        }
    }
}