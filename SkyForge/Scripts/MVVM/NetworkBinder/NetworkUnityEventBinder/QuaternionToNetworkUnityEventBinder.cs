/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.NetworkBinders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_NETWORK_REACTIVE_BINDER + 
                      "Quaternion to network unity event binder")]
    public class QuaternionToNetworkUnityEventBinder : NetworkConstantBinder<Quaternion>
    {
        
    }
}