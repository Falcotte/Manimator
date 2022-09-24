using UnityEngine;
using AngryKoala.Manimator;

public class BreakdanceDemo : MonoBehaviour
{
    [SerializeField] private Manimator manimator;

    private bool isPlaying;

    private void Start()
    {
        manimator.SetSpeed(0f);
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
    }

    private void PauseAnimation()
    {
        manimator.SetSpeed(0f, 1f, DG.Tweening.Ease.OutSine);
        isPlaying = false;
    }

    public void SkipForward()
    {
        int currentFrame = manimator.GetCurrentAnimationFrame();
        currentFrame = (currentFrame + 50);
        manimator.GoToFrame(manimator.GetCurrentAnimationClipName(), currentFrame, 1.5f, DG.Tweening.Ease.OutSine);
    }

    public void SkipBack()
    {
        int currentFrame = manimator.GetCurrentAnimationFrame();
        currentFrame = (currentFrame - 50);
        manimator.GoToFrame(manimator.GetCurrentAnimationClipName(), currentFrame, 1.5f, DG.Tweening.Ease.OutSine);
    }
}
