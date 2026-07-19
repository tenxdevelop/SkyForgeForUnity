/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.MVVM.Binders
{
    [AddComponentMenu(MVVMConstant.COMPONENT_MENU_PATH_REACTIVE_BINDER +
                      "Quaternion to unity event binder")]
    public class QuaternionToUnityEventBinder : UnityEventBinder<Quaternion>
    {
        
    }
}