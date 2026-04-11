using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace ct.tweensequence
{
    public class TweenSequenceQueuer : MonoBehaviour
    {
        [Serializable]
        public class QueuePlayerGroup
        {
            public TweenSequenceQueuePlayer player;
            public bool invokeOnCompletedEvent;
            public bool immediatelyEndIfBlockingQueue = true;
        }
        
        public TweenSequenceContainer sequenceContainer = new TweenSequenceContainer();
        public QueuePlayerGroup[] queuePlayers = new QueuePlayerGroup[1];
        public float playerOffsetTime;
        
        public UnityEvent onCompleted = new UnityEvent();

        private Action _completeAction;

        public bool debug;
        
        private void Awake()
        {
            _completeAction = WhenSequenceCompleted;
        }

        public async void Enqueue()
        {
            if (sequenceContainer.parts == null || sequenceContainer.parts.Count == 0)
            {
                WhenSequenceCompleted();
                return;
            }
            
            for (int i = 0; i < queuePlayers.Length; i++)
            {
                queuePlayers[i].player.Enqueue(sequenceContainer, DirectorWrapMode.None, queuePlayers[i].immediatelyEndIfBlockingQueue,
                    onCompleteAction: queuePlayers[i].invokeOnCompletedEvent ? _completeAction : null);
                if (playerOffsetTime > 0) await Awaitable.WaitForSecondsAsync(playerOffsetTime);
            }
        }

        public void WhenSequenceCompleted()
        {
            if(debug) Debug.Log("Sequence Completed.", gameObject);
            onCompleted?.Invoke();
        }
    }
}