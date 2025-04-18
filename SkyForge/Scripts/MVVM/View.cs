/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using System.Linq;
using UnityEngine;

namespace SkyForge.MVVM
{
#if UNITY_EDITOR
    [ExecuteInEditMode]
#endif
    public class View : MonoBehaviour, IView
    {
        [SerializeField, HideInInspector] private string m_viewModelTypeFullName;
        [SerializeField, HideInInspector] private string m_viewModelPropertyName;
        [SerializeField, HideInInspector] private bool m_isParentView;

        [SerializeField, HideInInspector] private List<View> m_subViews = new List<View>();
        [SerializeField, HideInInspector] private List<Binder> m_childBinders = new List<Binder>();

        public string ViewModelTypeFullName => m_viewModelTypeFullName;
        public string ViewModelPropertyName => m_viewModelPropertyName;
        public bool IsPaerntView => m_isParentView;

        private IViewModel m_targetViewModel;
        public void Bind(IViewModel viewModel)
        {

            if (m_isParentView)
            {
                m_targetViewModel = viewModel;
            }
            else
            {
                var property = viewModel.GetType().GetProperty(m_viewModelPropertyName);
                m_targetViewModel = property.GetValue(viewModel) as IViewModel;
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

        private void Update()
        {
#if UNITY_EDITOR
            m_targetViewModel?.Update(Time.deltaTime);
#else
            m_targetViewModel.Update(Time.deltaTime);
#endif
        }

        private void FixedUpdate()
        {
            m_targetViewModel?.PhysicsUpdate(Time.fixedDeltaTime);
        }

#if UNITY_EDITOR
        private void Start()
        {
            var parentTransform = transform.parent;

            if (parentTransform)
            {
                var parentView = parentTransform.GetComponentInParent<View>();

                if (parentView != null)
                {
                    parentView.RegisterView(this);
                }
            }
            
        }

        private void OnDestroy()
        {
            var parentTransform = transform.parent;

            if (parentTransform)
            {
                var parentView = parentTransform.GetComponentInParent<View>();

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
            var allFoundSubViews = gameObject.GetComponentsInChildren<View>(true);
            foreach (var foundSubView in allFoundSubViews)
            {
                var parentView = foundSubView.GetComponentsInParent<View>().FirstOrDefault(c => !ReferenceEquals(c, foundSubView));

                if (ReferenceEquals(this, parentView))
                {
                    RegisterView(foundSubView);
                }
            }
        }

        private void RegisterView(View view)
        {
            if (!m_subViews.Contains(view))
            {
                m_subViews.Add(view);
            }
        }

        private void RemoveView(View view)
        {
            m_subViews.Remove(view);
        }
#endif
    }
}

