using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public void AttackEnded()
    {
        GetComponentInParent<AnimationHandler>().state = AnimationHandler.PlayerStates.Idle;
    }

    public void PickupEnded()
    {
        GetComponentInParent<AnimationHandler>().state = AnimationHandler.PlayerStates.Idle;
    }
}
