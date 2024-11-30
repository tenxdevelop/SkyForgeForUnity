/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Reactive.Extention
{
    public static class SingleReactivePropertyExtention
    {
        public static void UpdateValue(this SingleReactiveProperty<int> reactiveProperty, object sender, int value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this SingleReactiveProperty<int> reactiveProperty, int value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this SingleReactiveProperty<float> reactiveProperty, object sender, float value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this SingleReactiveProperty<float> reactiveProperty, float value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this SingleReactiveProperty<double> reactiveProperty, object sender, double value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this SingleReactiveProperty<double> reactiveProperty, double value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this SingleReactiveProperty<string> reactiveProperty, object sender, string value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this SingleReactiveProperty<string> reactiveProperty, string value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void Opposed(this SingleReactiveProperty<bool> reactiveProperty, object sender)
        {
            reactiveProperty.SetValue(sender, !reactiveProperty.Value);
        }

        public static void Opposed(this SingleReactiveProperty<bool> reactiveProperty)
        {
            reactiveProperty.SetValue(null, !reactiveProperty.Value);
        }

    }
}
