/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.MVVM.NetworkBinders
{
    public abstract class NetworkMethodBinder : NetworkBinder
    {
        protected string MethodName => PropertyName;
    }
}