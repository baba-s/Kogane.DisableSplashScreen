using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

namespace Kogane.Internal
{
    internal static class DisableSplashScreen
    {
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
        private static void RuntimeInitializeOnLoadMethod()
        {
            if ( Application.isEditor ) return;

            if ( Application.platform == RuntimePlatform.WebGLPlayer )
            {
                Application.focusChanged += OnFocusChanged;

                static void OnFocusChanged( bool isFocus )
                {
                    Application.focusChanged -= OnFocusChanged;
                    SplashScreen.Stop( SplashScreen.StopBehavior.StopImmediate );
                }
            }
            else
            {
                var _ = Task.Run( () => SplashScreen.Stop( SplashScreen.StopBehavior.StopImmediate ) );
            }
        }
    }
}