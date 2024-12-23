/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


namespace SkyForge.MVVM
{
    public interface INetworkViewModel : IViewModel
    {
        void OnNetworkSpawn();

        void OnNetworkDespawn();
    }
}
