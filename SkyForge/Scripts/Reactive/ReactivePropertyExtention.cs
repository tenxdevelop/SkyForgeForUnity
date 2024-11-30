/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace SkyForge.Reactive.Extention
{
    public static class ReactivePropertyExtention
    {

        //ReactiveProperty
        public static void UpdateValue(this ReactiveProperty<int> reactiveProperty, object sender, int value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<int> reactiveProperty, int value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<float> reactiveProperty, object sender, float value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<float> reactiveProperty, float value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<double> reactiveProperty, object sender, double value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<double> reactiveProperty, double value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<string> reactiveProperty, object sender, string value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<string> reactiveProperty, string value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<Vector3> reactiveProperty, object sender, Vector3 value)
        {
            reactiveProperty.SetValue(sender, reactiveProperty.Value + value);
        }

        public static void UpdateValue(this ReactiveProperty<Vector3> reactiveProperty, Vector3 value)
        {
            reactiveProperty.SetValue(null, reactiveProperty.Value + value);
        }

        public static void Opposed(this ReactiveProperty<bool> reactiveProperty, object sender)
        {
            reactiveProperty.SetValue(sender, !reactiveProperty.Value);
        }

        public static void Opposed(this ReactiveProperty<bool> reactiveProperty)
        {
            reactiveProperty.SetValue(null, !reactiveProperty.Value);
        }
    }
}
