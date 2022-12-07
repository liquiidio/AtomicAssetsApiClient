using AtomicAssetsApiClient.Core.Exceptions;
using AtomicAssetsApiClient.Unity3D;
using AtomicAssetsApiClient.Unity3D.Assets;
using UnityEngine;
using UnityEngine.UIElements;

public class GetAssetUIScript : MonoBehaviour
{
    VisualElement root;
    VisualElement imageBox;
    TextField assetId;
    Button getAsset;

    Label collection;
    Label contract;
    Label owner;

    AssetsApi assetsApi;
    private Texture2D tex;

    // Start is called before the first frame update
    void Start()
    {
        assetsApi = AtomicAssetsApiFactory.Version1.AssetsApi;
        root = GetComponent<UIDocument>().rootVisualElement;
        assetId = root.Q<TextField>("assetId");

        collection = root.Q<Label>("collection");
        imageBox = root.Q<VisualElement>("image-box");
        contract = root.Q<Label>("contract");
        owner = root.Q<Label>("owner");

        getAsset = root.Q<Button>("getAsset");
        getAsset.clicked += GetAsset_clicked;
    }

    private async void GetAsset_clicked()
    {
        try
        {
            var asset = await assetsApi.Asset(assetId.value);

            if (asset != null)
            {
                Debug.Log("asset found");
                collection.text = $"Collection: {asset.Data.Collection.Name}";
                contract.text = $"Contract: {asset.Data.Contract}";
                owner.text = $"Owner: {asset.Data.Owner}";

                EncodedImage(asset.Data.Collection.Image);
            }
        }
        catch (ApiException ex)
        {
            Debug.LogError($"Content: {ex.Content}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EncodedImage(string loadFromSomewhere)
    {
        
        var b64_string = loadFromSomewhere;

        var b64_bytes = System.Convert.FromBase64String(b64_string);

        tex = new Texture2D(1, 1);
        tex.LoadImage(b64_bytes);

        imageBox.style.backgroundImage = tex;
    }
}
