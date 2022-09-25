using UnityEngine;
using AngryKoala.Manimator;

public class BellyDanceDemo : MonoBehaviour
{
    [SerializeField] private Manimator manimator;

    [SerializeField] private float animatorSpeedChangeRate;
    [SerializeField] private float maxAnimatorSpeed;

    private float currentNormalizedTime;
    private float currentAnimattorSpeed;

    private float speedChangeMultiplier;
    private bool isSpeedChanging;

    private void Start()
    {
        manimator.SetSpeed(0f);
        currentAnimattorSpeed = 1f;
    }

    private void Update()
    {
        if(!isSpeedChanging)
        {
            currentAnimattorSpeed = Mathf.MoveTowards(currentAnimattorSpeed, 1f, animatorSpeedChangeRate * Time.deltaTime);
        }
        else
        {
            currentAnimattorSpeed += animatorSpeedChangeRate * speedChangeMultiplier * Time.deltaTime;
        }

        currentAnimattorSpeed = Mathf.Clamp(currentAnimattorSpeed, -maxAnimatorSpeed, maxAnimatorSpeed);

        currentNormalizedTime += currentAnimattorSpeed * Time.deltaTime / manimator.GetCurrentAnimationLengthInSeconds();
        currentNormalizedTime %= 1f;

        manimator.GoToNormalizedTime(manimator.GetCurrentAnimationClipName(), currentNormalizedTime);
    }

    public void FastForward()
    {
        speedChangeMultiplier = 1f;
        isSpeedChanging = true;
    }

    public void Rewind()
    {
        speedChangeMultiplier = -1f;
        isSpeedChanging = true;
    }

    public void ReturnToDefaultSpeed()
    {
        speedChangeMultiplier = 0f;
        isSpeedChanging = false;
    }
}
