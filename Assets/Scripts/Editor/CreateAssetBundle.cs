using Assets.Scripts.Audio;
using UnityEditor;

public class CreateAssetBundle
{
    [MenuItem("Assets/Build Asset Bundle")]
    public static void BuildAllAssets()
    {
        BuildPipeline.BuildAssetBundles(
            "Assets/AssetBundles",
            BuildAssetBundleOptions.None,
            BuildTarget.WebGL);

        var instruct = new SoundInstruction("blablabla", 0.67f);
        instruct.IsMain = true;
        Sound.Play?.Invoke(instruct);
    }
}