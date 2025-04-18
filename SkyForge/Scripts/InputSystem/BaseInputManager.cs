/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System;

namespace SkyForge.Input
{
    public abstract class BaseInputManager : IDisposable
    {
        protected IInputMap m_inputMap;
        private Dictionary<Type, IInput> m_inputs;
        public BaseInputManager(IInputMap inputMap)
        {
            m_inputMap = inputMap;
            m_inputMap.Enable();
            m_inputs = new Dictionary<Type, IInput>();
        }

        public abstract void Dispose();

        public abstract void Init();

        public void RegisterInput<TInputInterface, TInput>() where TInput : class, IInput
        {
            var typeInputCached = typeof(TInputInterface);
            var typeInput = typeof(TInput);
            if (m_inputs.ContainsKey(typeInput))
                return;

            var input = Activator.CreateInstance(typeInput, new object[] { m_inputMap }) as TInput;
            m_inputs.Add(typeInputCached, input);
        }

        protected TInput GetInput<TInput>() where TInput : IInput
        {
            var typeInput = typeof(TInput);
            if (m_inputs.TryGetValue(typeInput, out var input))
            {
                return (TInput)input;
            }
            
            return default(TInput);
        }
    }
}
