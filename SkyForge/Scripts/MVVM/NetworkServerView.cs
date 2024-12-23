/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM
{
    public class NetworkServerView : BaseNetworkView
    {
        protected override void OnFixedUpdate()
        {
            if (!IsServer)
                return;

            m_targetViewModel.PhysicsUpdate(Time.fixedDeltaTime);
        }

        protected override void OnUpdate()
        {
            if(!IsServer)
                return;

#if UNITY_EDITOR
            m_targetViewModel?.Update(Time.deltaTime);
#else
            m_targetViewModel.Update(Time.deltaTime);
#endif
        }


        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            if (!IsServer)
                return;

            m_targetViewModel.OnNetworkSpawn();
        }


        public override void OnNetworkDespawn()
        {
            base.OnNetworkDespawn();

            if (!IsServer)
                return;

            m_targetViewModel.OnNetworkDespawn();
        }
    }
}
