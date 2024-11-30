/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Proxy
{
    public interface IProxy
    {

    }

    public interface IProxy<TEntityState> : IProxy
    {
        TEntityState OriginState { get; }
    }
}
