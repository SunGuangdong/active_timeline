using ActiveTimeline.Condition;
using ActiveTimeline.Enumerate;
using ActiveTimeline.Value.Primitive;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace ActiveTimeline.Value.Process
{
    [PublicAPI]
    [AddComponentMenu("ActiveTimeline/Value/Process/Random Int", (int)ValueType.RandomInt)]
    public class RandomInt : IntValue
    {
        [SerializeField] private int min;
        [SerializeField] private int max;
        private int Min => min;
        private int Max => max;

        private void Awake()
        {
            Refresh();
        }

        public void Refresh()
        {
            Value = Random.Range(Min, Max);
        }

        public void Refresh(ConditionBase condition)
        {
            if (condition == null)
            {
                return;
            }
            condition.OnFulfilledAsObservable().Subscribe(_ => Refresh());
        }
    }
}
