using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public void AttackEnded()
    {
        print("attack over");
        GetComponentInParent<AnimationHandler>().state = AnimationHandler.PlayerStates.Idle;

    }




}
