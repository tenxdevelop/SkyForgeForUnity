/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

#if UNITY_EDITOR

using UnityEditor;

namespace SkyForge.MVVM.Editors
{
    [CustomEditor(typeof(View), true)]
    public class ViewEditor : BaseViewEditor<View, IViewModel>
    {
        
    }
}

#endif