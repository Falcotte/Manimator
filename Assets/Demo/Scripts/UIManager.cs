using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image skipBackImage;
    [SerializeField] private Image playPauseImage;
    [SerializeField] private Image skipForwardImage;

    [SerializeField] private Sprite playIcon;
    [SerializeField] private Sprite pauseIcon;

    private bool isPlaying;

    public void SkipBackButton()
    {
        DOTween.Kill(skipBackImage.transform);
        skipBackImage.transform.localScale = Vector3.one;

        skipBackImage.transform.DOPunchScale(Vector3.one * .2f, .3f, 1, 1);
    }

    public void PlayPauseButton()
    {
        isPlaying = !isPlaying;
        AdjustPlayPauseButtonImage(isPlaying);

        DOTween.Kill(playPauseImage.transform);
        playPauseImage.transform.localScale = Vector3.one;

        playPauseImage.transform.DOPunchScale(Vector3.one * .2f, .3f, 1, 1);
    }

    public void AdjustPlayPauseButtonImage(bool isPlaying)
    {
        playPauseImage.sprite = isPlaying ? pauseIcon : playIcon;
        this.isPlaying = isPlaying;
    }

    public void SkipForwardButton()
    {
        DOTween.Kill(skipForwardImage.transform);
        skipForwardImage.transform.localScale = Vector3.one;

        skipForwardImage.transform.DOPunchScale(Vector3.one * .2f, .3f, 1, 1);
    }
}
