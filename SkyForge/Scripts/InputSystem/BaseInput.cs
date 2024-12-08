/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Input
{
    public class BaseInput
    {
        protected IInputMap m_inputMap;

        public BaseInput(IInputMap inputMap)
        {
            m_inputMap = inputMap;
        }
    }
}
