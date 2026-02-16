using PrimeTween;
using UnityEngine;

namespace ct.tweensequence
{
    [System.Serializable]
    public class GameObjectEnableState : TweenSequencePart
    {
        public GameObject gameObject;
        [SerializeField] public TweenSettings<float> settings;
        [SerializeField] public float duration;
        
        public override void SetTarget(GameObject target)
        {
            gameObject = target;
        }

        public override void BuildSequence(ref Sequence sequence)
        {
            void OnValueChange(float newVal)
            {
                gameObject.SetActive(newVal > 0);
            }
            
            switch (partType)
            {
                case TweenSequencePartType.Chain:
                    sequence.Chain(Tween.Custom(settings.startValue, settings.endValue, duration,
                        OnValueChange));
                    break;
                case TweenSequencePartType.Group:
                    sequence.Group(Tween.Custom(settings.startValue, settings.endValue, duration,
                        OnValueChange));
                    break;
            }
        }
    }
}