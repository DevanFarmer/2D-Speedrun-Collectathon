using UnityEngine;

[CreateAssetMenu(fileName = "New Reverse Controls", menuName = "Collectable Effect/Reverse Controls")]
public class ReverseControlsEffect : CollectableEffect
{
    public override void OnCollected()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTurnComponent>().ReverseControls();
    }
}
