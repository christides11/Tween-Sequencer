using PrimeTween;
using UnityEngine;

namespace ct.tweensequence
{
    [System.Serializable]
    public class TransformScale : TweenSequencePart
    {
        public Transform transform;
        [SerializeField] public TweenSettings<Vector3> settings;

        public override void SetTarget(GameObject target)
        {
            transform = target.GetComponent<Transform>();
        }

        public override void BuildSequence(ref Sequence sequence)
        {
            switch (partType)
            {
                case TweenSequencePartType.Chain:
                    sequence.Chain(Tween.Scale(transform, settings));
                    break;
                case TweenSequencePartType.Group:
                    sequence.Group(Tween.Scale(transform, settings));
                    break;
            }
        }
    }
}