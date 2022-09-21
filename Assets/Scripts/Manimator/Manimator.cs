using UnityEngine;

public class Manimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Resume()
    {
        animator.speed = 1f;
    }

    public void Pause()
    {
        animator.speed = 0f;
    }

    public void SetSpeed(float speed)
    {
        animator.speed = speed;
    }
}
