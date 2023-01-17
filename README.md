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

     var assetsApi = AtomicAssetsApiFactory.Version1.AssetsApi();

 
 ### Call the /assets endpoint

     var assets = assetsApi.Assets();

 
 ### Print all asset ids

     assets.Data.ToList().ForEach(a => Console.Write(a.AssetId));

 
 ##### Example output

1099567200114

1099567200113  

1099567200112  

1099567200111 

1099567200110  

1099567200109  

1099567200108 

1099567200107 

1099567200106  

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
 private async void SearchAsset()
    {
        if (_selectorDropdownField.value != null)
        {
            try
            {
                switch (_selectorDropdownField.value)
                {
                    case "Asset ID":
                        var assetDto = await _assetsApi.Asset(_collectionNameOrAssetId.value);
                        if (assetDto != null)
                        {
                            Rebind(assetDto);
                        }
                        else Debug.Log("asset id not found");
                        break;

                    case "Collection Name":
                        var collectionDto = await _collectionsApi.Collection(_collectionNameOrAssetId.value);
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
```





