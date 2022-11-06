using UnityEngine;
using UnityEngine.Rendering;

namespace Kogane.Internal
{
    internal static class DisableSplashScreen
    {
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
        private static void RuntimeInitializeOnLoadMethod()
        {
            Application.focusChanged += OnFocusChanged;

            static void OnFocusChanged( bool isFocus )
            {
                Application.focusChanged -= OnFocusChanged;
                SplashScreen.Stop( SplashScreen.StopBehavior.StopImmediate );
            }
        }
    }
}