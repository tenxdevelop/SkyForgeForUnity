/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Extension
{
    public abstract class SceneEnterParams
    {
        public T As<T>() where T : SceneEnterParams
        {
            return (T)this;
        }
    }
}
