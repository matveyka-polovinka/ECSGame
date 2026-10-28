using Assets.Scripts.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class WebGLAudioLoader : MonoBehaviour
{
    private AudioClip _targetClip;
    private bool _isLoadProcessCompleted = false;
    private static Dictionary<string, AudioClip> _clipCash = new Dictionary<string, AudioClip>();

    public bool IsProcessLoad() => _isLoadProcessCompleted;
    public AudioClip GetAudioClip() => _targetClip;
    public void ClearCash() => _clipCash.Clear();
    public bool IsClipCashed(string name) => _clipCash.ContainsKey(name);

    public void LoadAudio(string name)
    {
        _isLoadProcessCompleted = false;

        StartCoroutine(LoadAudioFromAssetBundle(name));
    }

    private IEnumerator LoadAudioFromAssetBundle(string name)
    {
        if (_clipCash.TryGetValue(name, out var cashedClip))
        {
            _targetClip = cashedClip;
            _isLoadProcessCompleted = true;
            yield break;
        }

        string fullUrl = $"{GetDirectoryPath()}{name}";

        using (UnityWebRequest webRequest =
            UnityWebRequestAssetBundle.GetAssetBundle(
                fullUrl.Replace("index.html/", "AssetBundle/")))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Ошибка загрузки ассета: {webRequest.result}");
                yield break;
            }

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(webRequest);

            if (bundle == null)
            {
                Debug.LogError("Не удалось получить бандл с сервера.");
                yield break;
            }

            try
            {
                AudioClip loadedAudioClip = bundle.LoadAsset<AudioClip>(name);
                loadedAudioClip.LoadAudioData();

                if (loadedAudioClip != null)
                {
                    _targetClip = loadedAudioClip;
                    _clipCash[name] = loadedAudioClip;
                }
                else
                {
                    Debug.LogError($"Айдиофайл {name} не найден в ассет-бандле");
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Ошибка при загрузке аудио: \n{e.Message}");
                _isLoadProcessCompleted = true;
            }

            if (_targetClip.loadState != AudioDataLoadState.Loaded) yield return null;

            bundle.Unload(false);
            _isLoadProcessCompleted = true;
        }
    }
    public string GetDirectoryPath()
    {
        string url = Application.absoluteURL;
        Uri uri = new Uri(url);

        string path = uri.GetLeftPart(UriPartial.Path);
        if (!path.EndsWith("/")) path += "/";

        return path;
    }
}