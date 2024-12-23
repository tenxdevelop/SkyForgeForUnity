/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using Unity.Netcode;
using System.Linq;
using UnityEngine;

namespace SkyForge.MVVM
{
    [RequireComponent(typeof(NetworkObject))]
    public abstract class BaseNetworkView : NetworkBehaviour, IView
    {
        [SerializeField] private string m_viewModelTypeFullName;
        [SerializeField] private string m_viewModelPropertyName;
        [SerializeField] private bool m_isParentView;

        [SerializeField] private List<BaseNetworkView> m_subViews = new List<BaseNetworkView>();
        [SerializeField] private List<Binder> m_childBinders = new List<Binder>();

        public string ViewModelTypeFullName => m_viewModelTypeFullName;
        public string ViewModelPropertyName => m_viewModelPropertyName;
        public bool IsPaerntView => m_isParentView;

        protected INetworkViewModel m_targetViewModel;

        public void Bind(IViewModel viewModel)
        {
            if (m_isParentView)
            {
                m_targetViewModel = viewModel as INetworkViewModel;
            }
            else
            {
                var property = viewModel.GetType().GetProperty(m_viewModelPropertyName);
                m_targetViewModel = property.GetValue(viewModel) as INetworkViewModel;
            }

            foreach (var subView in m_subViews)
            {
                subView.Bind(m_targetViewModel);
            }

            foreach (var binder in m_childBinders)
            {
                binder.Bind(m_targetViewModel);
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        protected abstract void OnUpdate();

        protected abstract void OnFixedUpdate();

        private void Update()
        {
            OnUpdate();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate();
        }


#if UNITY_EDITOR
        private void Start()
        {
            var parentTransform = transform.parent;

            if (parentTransform)
            {
                var parentView = parentTransform.GetComponentInParent<BaseNetworkView>();

                if (parentView != null)
                {
                    parentView.RegisterView(this);
                }
            }

        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            var parentTransform = transform.parent;

            if (parentTransform)
            {
                var parentView = parentTransform.GetComponentInParent<BaseNetworkView>();

                if (parentView != null)
                {
                    parentView.RemoveView(this);
                }
            }
        }

        public void RegisterBinder(Binder binder)
        {
            if (!m_childBinders.Contains(binder))
            {
                m_childBinders.Add(binder);
            }
        }

        public void RemoveBinder(Binder binder)
        {
            m_childBinders.Remove(binder);
        }

        public bool IsValidSetup()
        {
            foreach (var childBinder in m_childBinders)
            {
                if (childBinder is null)
                {
                    return false;
                }
            }

            foreach (var subView in m_subViews)
            {
                if (subView is null)
                {
                    return false;
                }
            }

            return true;
        }

        [ContextMenu("Force Fix")]
        public void Fix()
        {
            m_childBinders.Clear();
            var allFoundChildBinders = gameObject.GetComponentsInChildren<Binder>(true);
            foreach (var foundChildBinder in allFoundChildBinders)
            {
                if (foundChildBinder.ViewModelTypeFullName == ViewModelTypeFullName)
                {
                    RegisterBinder(foundChildBinder);
                }
            }

            m_subViews.Clear();
            var allFoundSubViews = gameObject.GetComponentsInChildren<BaseNetworkView>(true);
            foreach (var foundSubView in allFoundSubViews)
            {
                var parentView = foundSubView.GetComponentsInParent<BaseNetworkView>().FirstOrDefault(c => !ReferenceEquals(c, foundSubView));

                if (ReferenceEquals(this, parentView))
                {
                    RegisterView(foundSubView);
                }
            }
        }

        private void RegisterView(BaseNetworkView view)
        {
            if (!m_subViews.Contains(view))
            {
                m_subViews.Add(view);
            }
        }

        private void RemoveView(BaseNetworkView view)
        {
            m_subViews.Remove(view);
        }
#endif
    }
}
