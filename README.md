<div align="center">

[![builds](https://github.com/liquiidio/AtomicAssetsApiClient-Private/actions/workflows/dotnet-build.yml/badge.svg)](https://github.com/liquiidio/AtomicAssetsApiClient-Private/actions/workflows/dotnet-build.yml)
[![tests](https://github.com/liquiidio/AtomicAssetsApiClient-Private/actions/workflows/dotnet-test.yml/badge.svg)](https://github.com/liquiidio/AtomicAssetsApiClient-Private/actions/workflows/dotnet-test.yml)
       
</div>

# AtomicAssetsApiClient

.NET and Unity3D-compatible (Desktop, Mobile, WebGL) ApiClient for AtomicAssets

 ## Usage

 The entry point to the APIs is in the AtomicAssetsApiFactory. You can initialise any supported API from there.
 You can then call any endpoint from the initialised API.
 Each endpoint has its own set of parameters that you may build up and pass in to the relevant function.

 ## Example calling the /v1/assets endpoint
 ### Initialise the Assets API
```csharp      
  var assetsApi = AtomicAssetsApiFactory.Version1.AssetsApi;
  var collectionsApi = AtomicAssetsApiFactory.Version1.CollectionsApi;
```
 
 ### Call the /assets endpoint
```csharp
     var assets = assetsApi.Assets();
     var collection = collectionApi.Collection();
```
 
 ### Example to Filter and search Assets by either collection name or asset ids
```csharp
  private async void SearchAsset()
    {
        if (_selectorDropdownField.value != null)
        {
            try
            {
                switch (_selectorDropdownField.value)
                {
                    case "Asset ID":
                        var assetDto = await assetsApi.Asset(_collectionNameOrAssetId.value);
                        if (assetDto != null)
                        {
                            Rebind(assetDto);
                        }
                        else Debug.Log("asset id not found");
                        break;

                    case "Collection Name":
                        var collectionDto = await collectionsApi.Collection(_collectionNameOrAssetId.value);
                        if (collectionDto != null)
                        {
                            Rebind(collectionDto);
                        }
                        else Debug.Log("asset not found");
                        break;

                    case "":
                        break;
                }
            }
            catch (ApiException ex)
            {
                AtomicAssetsErrorPanel.ErrorText("Content Error", ex.Content);
                Show(AtomicAssetsErrorPanel.Root);
            }
        }
    }
````
 
 ##### Example output
 
 ## Results Search for Asset Id "#1099849109724"
 
<img width="853" alt="image" src="https://user-images.githubusercontent.com/31707324/213101482-0371d6cb-4981-4ea5-af0d-688092087b67.png">

 ## Results Search for Collection Name "mrpotatogame"
<img width="847" alt="image" src="https://user-images.githubusercontent.com/31707324/213101918-98ef30b5-d1ca-4b31-b4c7-2895a3681e89.png">

...

 
 ## Example calling the /v1/assets endpoint with parameters
 ### Initialise the Assets API

     var assetsApi = AtomicAssetsApiFactory.Version1.AssetsApi();

 
 ### Build up the AssetsParameters with the AssetsUriParameterBuilder

     var builder = new AssetsUriParameterBuilder().WithLimit(1);

 
 ### Call the /assets endpoint, passing in the builder

     var assets = assetsApi.Assets(builder);

 
 ### Print all asset ids

     assets.Data.ToList().ForEach(a => Console.WriteLine(a.AssetId));


 ## Example to search for assets

```csharp

```





