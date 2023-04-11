using UnityEngine;

public class CellEnemyAttack : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();

    public void PlayAnimationIdle()
    {
        animator.Play("Idle");
    }

    public void PlayAnimationPulsation()
    {
        animator.Play("Pulsation");
    }
}
