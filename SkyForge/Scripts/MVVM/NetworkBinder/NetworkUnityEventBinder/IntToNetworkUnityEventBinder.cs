/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.NetworkBinders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_NETWORK_REACTIVE_BINDER + 
                      "Int to network unity event binder")]
    public class IntToNetworkUnityEventBinder : NetworkUnityEventBinder<int>
    {
        
    }
}