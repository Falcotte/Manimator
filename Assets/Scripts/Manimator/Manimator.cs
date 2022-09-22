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

        public void SetSpeed(float speed, float duration)
        {
            DOTween.Kill($"ManSpeed{gameObject.GetInstanceID()}");
            DOTween.To(() => animator.speed, x => animator.speed = x, speed, duration).SetEase(Ease.Linear).SetId($"ManSpeed{gameObject.GetInstanceID()}");
        }

        public void SetSpeed(float speed, float duration, Ease ease)
        {
            DOTween.Kill($"ManSpeed{gameObject.GetInstanceID()}");
            DOTween.To(() => animator.speed, x => animator.speed = x, speed, duration).SetEase(ease).SetId($"ManSpeed{gameObject.GetInstanceID()}");
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

        public async void GoToFrame(string stateName, int frameCount)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");

            animator.Play(stateName, 0);

            await UniTask.NextFrame();

            animator.Play(stateName, 0, (frameCount / (animator.GetCurrentAnimatorClipInfo(0)[0].clip.length * 30)) % 1f);
        }

        public async void GoToFrame(string stateName, int frameCount, float duration)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");

            normalizedTime = 0f;
            animator.Play(stateName, 0);

            await UniTask.NextFrame();

            DOTween.To(() => normalizedTime, x => normalizedTime = x, (frameCount / (animator.GetCurrentAnimatorClipInfo(0)[0].clip.length * 30)) % 1f, duration).SetEase(Ease.Linear).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
            {
                animator.Play(stateName, 0, normalizedTime);
            });
        }

        public async void GoToFrame(string stateName, int frameCount, float duration, Ease ease)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");

            normalizedTime = 0f;
            animator.Play(stateName, 0);

            await UniTask.NextFrame();

            DOTween.To(() => normalizedTime, x => normalizedTime = x, (frameCount / (animator.GetCurrentAnimatorClipInfo(0)[0].clip.length * 30)) % 1f, duration).SetEase(ease).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
            {
                animator.Play(stateName, 0, normalizedTime);
            });
        }

        public void GoToNormalizedTime(string stateName, float normalizedTime)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");

            animator.Play(stateName, 0);

            animator.Play(stateName, 0, normalizedTime);
        }

        public void GoToNormalizedTime(string stateName, float normalizedTime, float duration)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");
            float time = 0f;

            DOTween.To(() => time, x => time = x, normalizedTime, duration).SetEase(Ease.Linear).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
            {
                animator.Play(stateName, 0, time);
            });
        }

        public void GoToNormalizedTime(string stateName, float normalizedTime, float duration, Ease ease)
        {
            DOTween.Kill($"Man{gameObject.GetInstanceID()}");
            float time = 0f;

            DOTween.To(() => time, x => time = x, normalizedTime, duration).SetEase(ease).SetId($"Man{gameObject.GetInstanceID()}").OnUpdate(() =>
            {
                animator.Play(stateName, 0, time);
            });
        }
    }
}