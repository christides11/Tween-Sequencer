using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

namespace ct.tweensequence
{
    [System.Serializable]
    public class LayoutElementPreferredHeight : TweenSequencePart
    {
        public LayoutElement layoutElement;
        [SerializeField] public TweenSettings<float> settings;
        [SerializeField] public float duration;

        public override void SetTarget(GameObject target)
        {
            layoutElement = target.GetComponent<LayoutElement>();
        }

        public override void BuildSequence(ref Sequence sequence)
        {
            switch (partType)
            {
                case TweenSequencePartType.Chain:
                    sequence.Chain(Tween.Custom(settings.startValue, settings.endValue, duration,
                        newVal => layoutElement.preferredHeight = newVal));
                    break;
                case TweenSequencePartType.Group:
                    sequence.Group(Tween.Custom(settings.startValue, settings.endValue, duration,
                        newVal => layoutElement.preferredHeight = newVal));
                    break;
            }
        }
    }
}