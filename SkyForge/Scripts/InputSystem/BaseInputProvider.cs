/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System;

namespace SkyForge.Input
{
    public abstract class BaseInputProvider : IDisposable
    {
        protected readonly IInputMapper InputMapper;
        
        private readonly Dictionary<Type, object> m_inputs;
        
        public BaseInputProvider(IInputMapper inputMapper)
        {
            InputMapper = inputMapper;
            InputMapper.Enable();
            m_inputs = new Dictionary<Type, object>();
        }

        public virtual void Dispose()
        {
            InputMapper.Disable();
            InputMapper.Dispose();

            foreach (var inputs in m_inputs.Values)
            {
                if (inputs is IList<IInput> currentInputs)
                {
                    foreach (var input in currentInputs)
                        input.Dispose();
                }
            }
        }
        
        public void RegisterInput<TInputInterface, TInput>() where TInput : class, IInput where TInputInterface : IInput
        {
            var typeInterfaceInput = typeof(TInputInterface);
            var typeInput = typeof(TInput);

            if (m_inputs.ContainsKey(typeInterfaceInput))
            {
                var currentInputs = m_inputs[typeInterfaceInput] as IList<TInputInterface>;
                
                if (currentInputs?.Any(input => input is TInput) ?? true)
                    return;
                
                var newInput = (TInputInterface)Activator.CreateInstance(typeInput, new object[] { InputMapper });
                currentInputs.Add(newInput);
                
                return;
            }
            
            var input = (TInputInterface)Activator.CreateInstance(typeInput, new object[] { InputMapper });
            var inputs = new List<TInputInterface>();
            
            inputs.Add(input);
            
            m_inputs.Add(typeInterfaceInput, inputs);
        }

        protected IList<TInputInterface> GetInputs<TInputInterface>() where TInputInterface : IInput
        {
            var typeInput = typeof(TInputInterface);
            
            if (m_inputs.TryGetValue(typeInput, out var inputs))
            {
                return (IList<TInputInterface>)inputs;
            }
            
            return null;
        }
    }
}
