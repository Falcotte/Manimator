using System.Collections.Generic;
using UnityEngine;
using AngryKoala.Manimator;

public class ThrillerDemo : MonoBehaviour
{
    [SerializeField] private Manimator manimator;
    [SerializeField] private UIManager uIManager;

    [SerializeField] private List<string> stateNames = new List<string>();

    [SerializeField] private float skipSpeed;
    [SerializeField] private float skipDuration;

    private float skipTimer;
    private float currentSkipAmount;

    private bool isPlaying;
    private bool isSkipping;

    private int stateIndex;

    private void Start()
    {
        manimator.SetSpeed(0f);
        manimator.GoToNormalizedTime(stateNames[0], 0f);
    }

    private void Update()
    {
        if(isSkipping)
        {
            currentSkipAmount += (skipSpeed / manimator.GetCurrentAnimationLengthInSeconds()) * Time.deltaTime;
            if(currentSkipAmount >= 1)
            {
                stateIndex = (stateIndex + 1) % stateNames.Count;
                currentSkipAmount = 0f;
            }

            manimator.GoToNormalizedTime(stateNames[stateIndex], currentSkipAmount);

            skipTimer += Time.deltaTime;
            if(skipTimer >= skipDuration)
            {
                skipTimer = 0f;
                isSkipping = false;
            }
        }
    }

    public void SetAnimationStatus()
    {
        if(isPlaying)
        {
            PauseAnimation();
        }
        else
        {
            ResumeAnimation();
        }
    }

    private void ResumeAnimation()
    {
        manimator.SetSpeed(1f, 1f, DG.Tweening.Ease.OutSine);
        isPlaying = true;

        uIManager.AdjustPlayPauseButtonImage(isPlaying);
    }

    private void PauseAnimation()
    {
        manimator.SetSpeed(0f, 1f, DG.Tweening.Ease.OutSine);
        isPlaying = false;

        uIManager.AdjustPlayPauseButtonImage(isPlaying);
    }

    public void SkipForward()
    {
        currentSkipAmount = manimator.GetCurrentAnimationNormalizedTime();

        isPlaying = false;
        uIManager.AdjustPlayPauseButtonImage(isPlaying);

        manimator.SetSpeed(0f);

        isSkipping = true;
        skipTimer = 0f;
    }
}