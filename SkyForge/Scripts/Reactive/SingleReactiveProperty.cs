/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Reactive
{
    public class SingleReactiveProperty<T> : IReactiveProperty<T>
    {
        public T Value
        {
            get => m_value;
            set
            {
                m_value = value;
                OnChanged(null, value);
            }
        }

        private T m_value;
        private IObserver<T> m_observer;

        public SingleReactiveProperty()
        {
            m_value = default(T);
            m_observer = null;
        }

        
        public IBinding Subscribe(IObserver<T> observer)
        {
            if (m_observer != null)
            {
#if UNITY_EDITOR
                UnityEngine.Debug.LogWarning("Cannot subscribe more one in singleReactiveProperty");
#endif
                return null;
            }

            m_observer = observer;
            return new ReactiveSubscription<T>(this, m_observer);
        }

        public void Unsubscribe(IObserver<T> observer)
        {
            if (!ReferenceEquals(m_observer, observer))
                return;

            m_observer = null;
        }

        public void SetValue(object sender, T newValue)
        {
            if (newValue.Equals(m_value))
                return;

            m_value = newValue;
            OnChanged(sender, newValue);
        }

        private void OnChanged(object sender, T newValue)
        {
            if (m_observer != null)
            {
                m_observer?.NotifyObservableChanged(sender, newValue);
            }
        }
        
    }
}
