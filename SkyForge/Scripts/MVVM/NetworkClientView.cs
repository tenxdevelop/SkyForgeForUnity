/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM
{
    public class NetworkClientView : BaseNetworkView
    {
        protected override void OnFixedUpdate()
        {
            if (!IsOwner)
                return;

            m_targetViewModel.PhysicsUpdate(Time.fixedDeltaTime);
        }

        protected override void OnUpdate()
        {
            if (!IsOwner)
                return;

#if UNITY_EDITOR
            m_targetViewModel?.Update(Time.deltaTime);
#else
            m_targetViewModel.Update(Time.deltaTime);
#endif
        }
    }
}
