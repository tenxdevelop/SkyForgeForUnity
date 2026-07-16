/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.NetworkBinders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_NETWORK_CONSTANT_BINDER + 
                      "Quaternion network constant binder")]
    public class QuaternionNetworkConstantBinder : NetworkConstantBinder<Quaternion>
    {
        
    }
}