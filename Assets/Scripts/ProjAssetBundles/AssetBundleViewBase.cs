using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
public class AssetBundleViewBase : MonoBehaviour
{
    private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1bGIzaKolzjXye2DZXDToj9rJLZm7tPbe";
    private const string UrlAssetBundleAudio = "https://drive.google.com/uc?export=download&id=1jpo4FGcGve_pcnNI5YAZosAI3pANe7f7";

    [SerializeField]
    private DataSpriteBundle[] _dataSpriteBundles;

    [SerializeField]
    private DataAudioBundle[] _dataAudioBundles;

    private AssetBundle _spritesAssetBundle;
    private AssetBundle _audioAssetBundle;

    protected IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpritesAssetBundle();
        yield return GetAudioAssetBundle();

        if (_audioAssetBundle == null)
        {
            Debug.LogError($"AssetBundle {_audioAssetBundle} failed to load");
            yield break;
        }

        if (_spritesAssetBundle == null)
        {
            Debug.LogError($"AssetBundle {_spritesAssetBundle} failed to load");
            yield break;
        }

        SetDownloadAssets();
        yield return null;
    }

    private IEnumerator GetSpritesAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

        yield return request.SendWebRequest();


        while (!request.isDone)
        {
            LogPercent("спрайтов", request.downloadProgress);
            yield return null;
        }

        LogPercent("спрайтов", request.downloadProgress);
        StateRequest(request, ref _spritesAssetBundle);
    }

    private IEnumerator GetAudioAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);

        yield return request.SendWebRequest();

        while (!request.isDone)
        {
            LogPercent("аудио", request.downloadProgress);
            yield return null;
        }

        LogPercent("аудио", request.downloadProgress);
        StateRequest(request, ref _audioAssetBundle);

        yield return null;
    }

    private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (request.error == null)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            Debug.Log("Complete");
        }
        else
        {
            Debug.Log(request.error);
        }
    }

    private void LogPercent(string whatDownload, float percent)
    {
        Debug.Log($"Процент скачивания {whatDownload} {percent * 100}");
    }
    private void SetDownloadAssets()
    {
        foreach (var data in _dataSpriteBundles)
            data.Image.sprite = _spritesAssetBundle.LoadAsset<Sprite>(data.NameAssetBundle);

        foreach (var data in _dataAudioBundles)
        {
            data.AudioSource.clip = _audioAssetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
            data.AudioSource.Play();
        }
    }

}