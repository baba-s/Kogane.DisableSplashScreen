# Kogane Disable Splash Screen

Unity Personal ライセンスでもゲーム起動時に表示されるスプラッシュスクリーンを無効化できるスクリプト

## 使い方

「[DisableSplashScreen.cs](Runtime/DisableSplashScreen.cs)」を Unity プロジェクトの Assets フォルダ以下に追加するだけです

## 説明

Unity Personal ライセンスでも「[SplashScreen.Stop](https://docs.unity3d.com/ja/current/ScriptReference/Rendering.SplashScreen.Stop.html)」を呼び出せば  
スプラッシュスクリーンを停止することができるため、  
ゲーム起動時にこの関数を呼び出すことで  
スプラッシュスクリーンを無効化しています  

## 動作確認済みの環境

* Unity 2022.1.11f1
* Windows Mono2x ビルド
* Windows IL2CPP ビルド
* iOS IL2CPP ビルド
* Android Mono2x ビルド
* Android IL2CPP ビルド
* WebGL IL2CPP ビルド

## 注意

* Package Manager で本パッケージを導入した場合は一部のプラットフォームで正常に動作しません
