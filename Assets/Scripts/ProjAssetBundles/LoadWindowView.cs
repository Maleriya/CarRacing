using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LoadWindowView : AssetBundleViewBase
{
    [SerializeField]
    private Button _loadAsssetsButton;
    [SerializeField]
    private Button _loadAddressableButton;

    [SerializeField]
    private AssetReference _loadPrefab;

    [SerializeField]
    private RectTransform _rectTransform;

    private List<AsyncOperationHandle<GameObject>> addressablePrefabs = new List<AsyncOperationHandle<GameObject>>();

    private void Start()
    {
        _loadAsssetsButton.onClick.AddListener(LoadAsset);
        _loadAddressableButton.onClick.AddListener(CreateAddressableBrefab);
    }

    private void CreateAddressableBrefab()
    {
        var addressablePrefab = Addressables.InstantiateAsync(_loadPrefab, _rectTransform);
        addressablePrefabs.Add(addressablePrefab);
    }

    private void OnDestroy()
    {
        _loadAsssetsButton.onClick.RemoveAllListeners();

        foreach (var addressablePrefab in addressablePrefabs)
        {
            Addressables.ReleaseInstance(addressablePrefab);
        }

        addressablePrefabs.Clear();
    }

    private void LoadAsset()
    {
        _loadAsssetsButton.interactable = false;

        StartCoroutine(DownloadAndSetAssetBundle());
    }

}