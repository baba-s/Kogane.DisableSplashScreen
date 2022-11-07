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
            // Unity エディタでは何もしない
            if ( Application.isEditor ) return;

            // プラットフォームが WebGL の場合は
            // Application.focusChanged のタイミングで
            // SplashScreen.Stop を呼び出すとスプラッシュスクリーンを停止できる
            if ( Application.platform == RuntimePlatform.WebGLPlayer )
            {
                Application.focusChanged += OnFocusChanged;

                static void OnFocusChanged( bool isFocus )
                {
                    Application.focusChanged -= OnFocusChanged;
                    Stop();
                }
            }
            // プラットフォームが WebGL 以外の場合は
            // 別スレッドで SplashScreen.isFinished が true になるまで
            // SplashScreen.Stop を呼び出すとスプラッシュスクリーンを停止できる
            else
            {
                _ = Task.Run
                (
                    async () =>
                    {
                        while ( !SplashScreen.isFinished )
                        {
                            Stop();
                            await Task.Delay( 1 );
                        }
                    }
                );
            }

            static void Stop()
            {
                SplashScreen.Stop( SplashScreen.StopBehavior.StopImmediate );
            }
        }
    }
}