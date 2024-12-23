/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEditor;

namespace SkyForge.MVVM.Editors
{
    [CustomEditor(typeof(BaseNetworkView), true)]
    public class BaseNetworkViewEditor : BaseViewEditor<BaseNetworkView, INetworkViewModel>
    {
        
    }
}
