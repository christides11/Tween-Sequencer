using System;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace ct.tweensequence
{
    public class TweenSequenceQueuePlayer : MonoBehaviour
    {
        [System.Serializable]
        public struct QueueItem
        {
            public DirectorWrapMode queueWrapMode;
            public bool immediatelyCompleteIfBlockingQueue;
            public TweenSequenceContainer tweenSequence;
            public Action onCompleteAction;
        }

        public int queueMax = 1;
        public List<QueueItem> currentQueue = new List<QueueItem>();
        public Sequence currentSequence;

        private void OnDisable()
        {
            currentQueue.Clear();
            currentSequence = default;
        }

        public void Update()
        {
            if (currentQueue.Count == 0) return;

            while (currentQueue.Count > queueMax && currentSequence.isAlive)
            {
                if (!currentSequence.isAlive) BuildSequence();
                CompleteCurrentSequence();
                Pop();
            }

            if (currentQueue.Count == 0) return;
            
            switch (currentQueue[0].queueWrapMode)
            {
                case DirectorWrapMode.Hold:
                case DirectorWrapMode.Loop:
                    if (currentQueue.Count == 1) return;
                    break;
            }

            if ((currentQueue.Count > 1 && currentQueue[0].immediatelyCompleteIfBlockingQueue) ||
                currentSequence.isAlive == false)
            {
                CompleteCurrentSequence();
                Pop();
            }
        }

        public virtual void Enqueue(TweenSequenceContainer sequenceContainer, DirectorWrapMode queueWrapMode,
            bool immediatelyEndIfBlockingQueue, Action onCompleteAction = null)
        {
            currentQueue.Add(new QueueItem()
            {
                queueWrapMode = queueWrapMode,
                tweenSequence = sequenceContainer,
                immediatelyCompleteIfBlockingQueue = immediatelyEndIfBlockingQueue,
                onCompleteAction = onCompleteAction
            });

            if (currentQueue.Count == 1) BuildSequence();
        }

        public virtual void Pop()
        {
            if(currentQueue.Count == 0) return;
            currentQueue.RemoveAt(0);
            if (currentQueue.Count > 0) BuildSequence();
        }

        private void BuildSequence()
        {
            currentSequence = currentQueue[0].tweenSequence
                .BuildSequence(onComplete: currentQueue[0].onCompleteAction);
        }

        private void CompleteCurrentSequence()
        {
            currentSequence.Complete();
            currentSequence = default;
        }
    }
}