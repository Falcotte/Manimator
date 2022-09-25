using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BellyDanceButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEvent OnButtonPressed;
    [SerializeField] private UnityEvent OnButtonReleased;

    [SerializeField] private Transform icon;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonPressed?.Invoke();

        DOTween.Kill(icon);
        icon.localScale = Vector3.one;

        icon.DOScale(Vector3.one * 1.3f, .3f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonReleased?.Invoke();

        DOTween.Kill(icon);

        icon.DOScale(Vector3.one, .3f);
    }
}
