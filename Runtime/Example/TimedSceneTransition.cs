using Strangeman.SceneHelper.Core;
using System;
using System.Collections;
using UnityEngine;

namespace Strangeman.SceneHelper.Example
{
    public class TimedSceneTransition : SceneTransition
    {
        [SerializeField] private float _startActivityDuration = 2f;
        [SerializeField] private float _endActivityDuration = 2f;

        private void OnEnable()
        {
            LoadTransition += TimedTransition;
        }

        private void TimedTransition(LoadTransitionType transitionType)
        {
            switch (transitionType)
            {
                case LoadTransitionType.FromScene:
                    StartCoroutine(TimedTransitionActivity(_startActivityDuration, FromSceneCondition));
                    break;
                case LoadTransitionType.IntoScene:
                    StartCoroutine(TimedTransitionActivity(_endActivityDuration, IntoSceneCondition));
                    break;
            }
        }

        private IEnumerator TimedTransitionActivity(float time, Func<bool> conditionCallback)
        {
            yield return new WaitForSeconds(time);
            conditionCallback = () => true;
        }
    }
}