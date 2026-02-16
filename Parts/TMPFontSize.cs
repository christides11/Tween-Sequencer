using PrimeTween;
using TMPro;
using UnityEngine;

namespace ct.tweensequence
{
    [System.Serializable]
    public class TMPFontSize : TweenSequencePart
    {
        public TextMeshProUGUI textMesh;
        [SerializeField] public TweenSettings<float> settings;

        public override void SetTarget(GameObject target)
        {
            textMesh = target.GetComponent<TextMeshProUGUI>();
        }

        public override void BuildSequence(ref Sequence sequence)
        {
            switch (partType)
            {
                case TweenSequencePartType.Chain:
                    sequence.Chain(Tween.TextFontSize(textMesh, settings));
                    break;
                case TweenSequencePartType.Group:
                    sequence.Group(Tween.TextFontSize(textMesh, settings));
                    break;
            }
        }
    }
}