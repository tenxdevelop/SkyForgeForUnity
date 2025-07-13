/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


namespace SkyForge.MVVM
{
    public interface INetworkViewModel : IViewModel
    {

        ulong GetClientId();
        
        void OnNetworkSpawn();

        void OnNetworkDespawn();
    }
}
