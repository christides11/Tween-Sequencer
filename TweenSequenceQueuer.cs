using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace ct.tweensequence
{
    public class TweenSequenceQueuer : MonoBehaviour
    {
        public TweenSequenceContainer sequenceContainer = new TweenSequenceContainer();
        public TweenSequenceQueuePlayer queuePlayer;
        public bool immediatelyEndIfBlockingQueue = true;
        public bool invokeOnCompletedEvent;
        
        public UnityEvent onCompleted = new UnityEvent();

        private Action _completeAction;

        public bool debug;
        
        private void Awake()
        {
            _completeAction = WhenSequenceCompleted;
        }

        public void Enqueue()
        {
            queuePlayer.Enqueue(sequenceContainer, DirectorWrapMode.None, immediatelyEndIfBlockingQueue,
                onCompleteAction: invokeOnCompletedEvent ? _completeAction : null);
        }

        public void WhenSequenceCompleted()
        {
            if(debug) Debug.Log("Sequence Completed.", gameObject);
            onCompleted.Invoke();
        }
    }
}