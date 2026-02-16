using PrimeTween;
using UnityEngine;

namespace ct.tweensequence
{
    [System.Serializable]
    public class RectTransformSizeDelta : TweenSequencePart
    {
        public RectTransform rectTransform;
        [SerializeField] public TweenSettings<Vector2> settings;

        public override void SetTarget(GameObject target)
        {
            rectTransform = target.GetComponent<RectTransform>();
        }

        public override void BuildSequence(ref Sequence sequence)
        {
            switch (partType)
            {
                case TweenSequencePartType.Chain:
                    sequence.Chain(Tween.UISizeDelta(rectTransform, settings));
                    break;
                case TweenSequencePartType.Group:
                    sequence.Group(Tween.UISizeDelta(rectTransform, settings));
                    break;
            }
        }
    }
}