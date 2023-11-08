using UnityEngine;

public class MapCharacterAppearance : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();

    public void StartAnimationIdle()
    {
        animator.Play("Idle");
    }

    public void StartAnimationMove()
    {
        animator.Play("Move");
    }
}
