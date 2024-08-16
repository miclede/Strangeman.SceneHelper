using Strangeman.SceneHelper.Core;
using System;
using System.Collections;
using UnityEngine;

namespace Strangeman.SceneHelper.Example
{
    // The commented out portion is a approach that does not invole using another class like: TransitionStrategy (Strategy pattern-like approach)
    public class TimedSceneTransition : SceneTransition
    {
        [SerializeField] private float _startActivityDuration = 2f;
        [SerializeField] private float _endActivityDuration = 2f;

        TransitionStrategy _fromStrategy = new();
        TransitionStrategy _intoStrategy = new();

        //bool _fromCondition;
        //bool _intoCondition;

        private void OnEnable()
        {
            LoadTransition += TimedTransition;
            FromSceneCondition = _fromStrategy.TransitionCondition;
            IntoSceneCondition = _intoStrategy.TransitionCondition;

            //FromSceneCondition = () => _fromCondition;
            //IntoSceneCondition = () => _intoCondition;
        }

        private void TimedTransition(LoadTransitionType transitionType)
        {
            switch (transitionType)
            {
                case LoadTransitionType.FromScene:
                    StartCoroutine(TimedTransitionActivity(_startActivityDuration, _fromStrategy));
                    break;
                case LoadTransitionType.IntoScene:
                    StartCoroutine(TimedTransitionActivity(_endActivityDuration, _intoStrategy));
                    break;
            }

            //switch (transitionType)
            //{
            //    case LoadTransitionType.FromScene:
            //        StartCoroutine(TimedTransitionActivity(_startActivityDuration, () => _fromCondition = true));
            //        break;
            //    case LoadTransitionType.IntoScene:
            //        StartCoroutine(TimedTransitionActivity(_endActivityDuration, () => _intoCondition = true));
            //        break;
            //}
        }

        private IEnumerator TimedTransitionActivity(float time, TransitionStrategy strategy)
        {
            yield return new WaitForSeconds(time);

            strategy.UpdateCondition(true);
        }

        //private IEnumerator TimedTransitionActivity(float time, Action callback)
        //{
        //    yield return new WaitForSeconds(time);
        //    callback?.Invoke();
        //}
    }

    public class TransitionStrategy
    {
        bool _condition;
        public Func<bool> TransitionCondition;

        public TransitionStrategy()
        {
            TransitionCondition = () => _condition;
        }

        public void UpdateCondition(bool update) => _condition = update;
    }
}