using UnityEngine;

[CreateAssetMenu(fileName = "New TimeEffect", menuName = "Collectable Effect/Time")]
public class TimeCollectableEffect : CollectableEffect
{
    public float alterValue;

    public override void OnCollected()
    {
        GameObject.FindGameObjectWithTag("Time Manager").GetComponent<TimerManager>().AlterTime(alterValue);
    }
}
