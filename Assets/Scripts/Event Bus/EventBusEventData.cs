using UnityEngine;

namespace EventBusEventData
{
    public readonly struct LevelCompletedEvent { }

    public readonly struct LevelFailedEvent { }

    public readonly struct RestartLevelEvent { }

    public readonly struct PauseChangeEvent 
    {
        public readonly bool IsPaused;

        public PauseChangeEvent(bool isPaused) { IsPaused = isPaused;}
    }

    public readonly struct CollectCollectableEvent { }
}
