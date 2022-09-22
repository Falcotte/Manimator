using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace AngryKoala.Manimator
{
    public class Manimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private float normalizedTime;

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

        public async void Play(string stateName)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");

            normalizedTime = 0f;
            animator.Play(stateName, 0, 0f);

            await UniTask.NextFrame();

            DOTween.To(() => normalizedTime, x => normalizedTime = x, 1f, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length).SetEase(Ease.Linear).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
            {
                animator.Play(stateName, 0, normalizedTime);
            });
        }

        public async void Play(string stateName, float duration = -1f)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");

            normalizedTime = 0f;
            animator.Play(stateName, 0, 0f);

            await UniTask.NextFrame();

            if(duration < 0)
            {
                DOTween.To(() => normalizedTime, x => normalizedTime = x, 1f, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length).SetEase(Ease.Linear).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
                {
                    animator.Play(stateName, 0, normalizedTime);
                });
            }
            else
            {
                DOTween.To(() => normalizedTime, x => normalizedTime = x, 1f, duration).SetEase(Ease.Linear).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
                {
                    animator.Play(stateName, 0, normalizedTime);
                });
            }
        }

        public async void Play(string stateName, float duration = -1f, Ease ease = Ease.Linear)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");

            normalizedTime = 0f;
            animator.Play(stateName, 0, 0f);

            await UniTask.NextFrame();

            if(duration < 0)
            {
                DOTween.To(() => normalizedTime, x => normalizedTime = x, 1f, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length).SetEase(ease).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
                {
                    animator.Play(stateName, 0, normalizedTime);
                });
            }
            else
            {
                DOTween.To(() => normalizedTime, x => normalizedTime = x, 1f, duration).SetEase(ease).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
                {
                    animator.Play(stateName, 0, normalizedTime);
                });
            }
        }
    }
}