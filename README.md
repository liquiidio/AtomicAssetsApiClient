<div align="center">
 <img src="https://avatars.githubusercontent.com/u/82725791?s=200&v=4" align="center"
     alt="Liquiid logo" width="280" height="300">
</div>

---

<div align="center">

[![builds](https://github.com/liquiidio/AtomicAssetsApiClient-Private/actions/workflows/dotnet-build.yml/badge.svg)](https://github.com/liquiidio/AtomicAssetsApiClient-Private/actions/workflows/dotnet-build.yml)
[![tests](https://github.com/liquiidio/AtomicAssetsApiClient-Private/actions/workflows/dotnet-test.yml/badge.svg)](https://github.com/liquiidio/AtomicAssetsApiClient-Private/actions/workflows/dotnet-test.yml)
       
</div>

# AtomicAssetsApiClient

.NET and Unity3D-compatible (Desktop, Mobile, WebGL) ApiClient for AtomicAssets


# Installation

**_Requires Unity 2019.1+ with .NET 4.x+ Runtime_**

This package can be included into your project by either:

 1. Installing the package via Unity's Package Manager (UPM) in the editor (recommended).
 2. Importing the .unitypackage which you can download.
 3. Manually add the files in this repo.
 4. Installing it via NuGet.
 
---

### 1. Installing via Unity Package Manager (UPM).
In your Unity project:
 1. Open the Package Manager Window/Tab

    ![image](https://user-images.githubusercontent.com/74650011/208429048-37e2277c-3e10-4794-97e7-3ec87f55f8c9.png)

 2. Click on + icon and then click on "Add Package From Git URL"

    ![image](https://user-images.githubusercontent.com/74650011/208429298-76fe1101-95f3-4ab0-bbd5-f0a32a1cc652.png)

 3. Enter URL:  `https://github.com/liquiidio/AttomicAssetsApiClient-Private.git#upm`
   
---
### 2. Importing the Unity Package.
Download the UnityPackage . Then in your Unity project:

 1. Open up the import a custom package window
    
    ![image](https://user-images.githubusercontent.com/74650011/208430044-caf91dd9-111e-4224-8441-95d116dbec3b.png)

 2. Navigate to where you downloaded the file and open it.
    
   ![image](https://user-images.githubusercontent.com/86061433/217043716-5b973473-4644-461b-af14-df8bf123a4b6.jpg)

    
 3. Check all the relevant files needed (if this is a first time import, just select ALL) and click on import.
   
   ![image](https://user-images.githubusercontent.com/86061433/217044240-12aeadc4-40ae-4624-9b98-4250eea73d33.jpg)


---

### 3. Install manually.
Download this project there here . Then in your Unity project:

 1. Copy the sources from `AtomicAssetsApiClient` into your `Assets` directory.

---

### 4. Install via NuGet (for Standard .NET users only - No Unity3D)

#### .NET CLI

`> dotnet add package Liquiid.io.AtomicAssets --version 1.0.24`

#### Package Manager

`PM> Install-Package Liquiid.io.AtomicAssets -Version 1.0.24`

---

 # Usage

 The entry point to the APIs is in the AtomicAssetsApiFactory. You can initialise any supported API from there.
 You can then call any endpoint from the initialised API.
 Each endpoint has its own set of parameters that you may build up and pass in to the relevant function.

---

 # Examples
 
 ## Example calling the /v1/assets endpoint
 ### Initialise the Assets API

     var assetsApi = AtomicAssetsApiFactory.Version1.AssetsApi;

 
 ### Call the /assets endpoint

     var assets = await assetsApi.Assets();

 
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

     var assetsApi = AtomicAssetsApiFactory.Version1.AssetsApi;

 
 ### Build up the AssetsParameters with the AssetsUriParameterBuilder

     var builder = new AssetsUriParameterBuilder().WithLimit(1);

 
 ### Call the /assets endpoint, passing in the builder

     var assets = await assetsApi.Assets(builder);

 
 ### Print all asset ids

     assets.Data.ToList().ForEach(a => Console.WriteLine(a.AssetId));








