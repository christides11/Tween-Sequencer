using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

namespace ct.tweensequence
{
    [System.Serializable]
    public class ImageColor : TweenSequencePart
    {
        public Image image;
        [SerializeField] public TweenSettings<Color> settings;
        public float duration;
        
        public override void SetTarget(GameObject target)
        {
            image = target.GetComponent<Image>();
        }
        public override void BuildSequence(ref Sequence sequence)
        {
            void OnValueChange(Color newVal)
            {
                image.color = newVal;
            }
            
            switch (partType)
            {
                case TweenSequencePartType.Chain:
                    sequence.Chain(Tween.Custom(settings.startValue, settings.endValue, duration, OnValueChange));
                    break;
                case TweenSequencePartType.Group:
                    sequence.Group(Tween.Custom(settings.startValue, settings.endValue, duration, OnValueChange));
                    break;
            }
        }
    }
}