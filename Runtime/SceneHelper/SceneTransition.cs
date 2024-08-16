using Strangeman.Utils;
using Strangeman.Utils.Service;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Strangeman.SceneHelper.Core
{
    public enum LoadTransitionType { FromScene, IntoScene }

    public abstract class SceneTransition : MonoBehaviour, IInitializeWith<SceneEventController>
    {
        private Action AllowLoad;
        private Action TransitionEnded;

        protected Action<LoadTransitionType> LoadTransition;

        protected Func<bool> FromSceneCondition;
        protected Func<bool> IntoSceneCondition;

        public void InitializeWith(SceneEventController eventController)
        {
            ServiceLocator.Global.GetMonoService(out SceneLoader sceneLoader);
            transform.SetParent(sceneLoader.transform);

            SceneManager.sceneLoaded += EndTransition;

            AllowLoad += eventController.OnAllowLoad;
            TransitionEnded += FinishedTransitionCycle;
            TransitionEnded += eventController.OnTransitionEnded;

            eventController.OnTransitionStart();
            LoadTransition += OnBeginTransition;
        }

        private void OnBeginTransition(LoadTransitionType transitionType)
        {
            if (transitionType is LoadTransitionType.FromScene)
                StartCoroutine(TransitionActivity(FromSceneCondition, AllowLoad));
        }

        private IEnumerator TransitionActivity(Func<bool> activityCondition, Action callback)
        {
            yield return new WaitUntil(activityCondition);
            callback?.Invoke();
        }

        private void EndTransition(Scene sceneLoaded, LoadSceneMode sceneLoadMode)
        {
            StartCoroutine(TransitionActivity(IntoSceneCondition, TransitionEnded));
        }

        private void FinishedTransitionCycle()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= EndTransition;
            AllowLoad = null;
            TransitionEnded = null;
            LoadTransition = null;
            FromSceneCondition = null;
            IntoSceneCondition = null;
        }
    }
}