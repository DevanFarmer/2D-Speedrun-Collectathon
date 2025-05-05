using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Speed Modifier Effect", menuName = "Collectable Effect/Speed Modifier")]
public class SpeedModifierEffect : CollectableEffect
{
    public float speedModifier;

    [Header("Temperary Effect")]
    public bool removeAfterTime;
    public float removeTime;

    PlayerMovementComponent movementComp;

    public override void OnCollected()
    {
        movementComp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementComponent>();

        movementComp.AlterSpeedModifier(speedModifier);

        if (removeAfterTime) CoroutineRunner.Instance.StartCoroutine(RemoveModifierAfterTime());
    }

    IEnumerator RemoveModifierAfterTime()
    {
        yield return new WaitForSeconds(removeTime);

        movementComp.AlterSpeedModifier(-speedModifier);
    }
}
