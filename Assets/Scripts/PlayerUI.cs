using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    Character character;
    [SerializeField] UIBar hpBar;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Update()
    {
        hpBar.Show(character.lifePool);
    }
}
