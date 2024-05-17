using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    AnimationHandler animationHandlerSM;
    [SerializeField] Character target;
    float timer = 4f;

    private void Awake()
    {
        animationHandlerSM = GetComponent<AnimationHandler>();
    }

    private void Update()
    {
        timer -= Time.deltaTime; 
        if (timer <= 0)
        {
            animationHandlerSM.Attack(target);

            timer = 4f;
        }
    }
}
