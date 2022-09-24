using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using AngryKoala.Manimator;

public class VictoryDemo : MonoBehaviour
{
    [SerializeField] private Manimator manimator;

    [SerializeField] private Slider slider;
    [SerializeField] private Transform slideText;

    private float percentage;
    private float currentPercentage;

    private bool slideTextHidden;
    private bool hasWon;

    private void Start()
    {
        manimator.SetSpeed(0f);
    }

    private void Update()
    {
        if(!hasWon)
        {
            currentPercentage = Mathf.MoveTowards(currentPercentage, percentage, Time.deltaTime * 5f);
            manimator.GoToNormalizedTime("Victory Idle", currentPercentage);
            if(currentPercentage >= 1f)
            {
                hasWon = true;

                manimator.GoToNormalizedTime("Victory Idle", .98f);
                manimator.SetSpeed(1f);

                slider.enabled = false;
                slider.transform.DOScale(0f, .3f).OnComplete(() =>
                {
                    slider.gameObject.SetActive(false);
                });
            }
        }
    }

    public void SetVictoryAnimationPercentage(float percentage)
    {
        if(!slideTextHidden)
        {
            slideTextHidden = true;

            slideText.DOScale(0f, .3f).OnComplete(() =>
            {
                slideText.gameObject.SetActive(false);
            });
        }

        this.percentage = percentage;
    }
}
