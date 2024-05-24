using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCheck : MonoBehaviour
{
    public GameManager gameManager;

    private void Update()
    {
        if(transform.childCount == 0)
        {
            gameManager.areAllEnemiesDead = true;
        }
        else
        {
            return;
        }
    }
}