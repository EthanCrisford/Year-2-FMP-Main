using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public void AttackEnded()
    {
        //print("attack over");
        GetComponentInParent<AnimationHandler>().state = AnimationHandler.PlayerStates.Idle;
    }

    public void PickupEnded()
    {
        //print("pickup over");
        GetComponentInParent<AnimationHandler>().state = AnimationHandler.PlayerStates.Idle;
    }
}
