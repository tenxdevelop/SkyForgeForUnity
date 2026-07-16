/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.MVVM
{
    public class ConstantProperty<T> : IConstantProperty<T>
    {
        public T Value { get; }

        public ConstantProperty(T value)
        {
            Value = value;
        }
    }
}