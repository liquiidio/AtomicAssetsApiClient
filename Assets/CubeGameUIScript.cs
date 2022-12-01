using AtomicAssetsApiClient;
using AtomicAssetsApiClient.Assets;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeGameUIScript : MonoBehaviour
{
    VisualElement root;
    TextField assetId;
    Button getAsset;

    Label collection;
    Label contract;
    Label owner;

    AssetsApi assetsApi;

    // Start is called before the first frame update
    void Start()
    {
        assetsApi = AtomicAssetsApiFactory.Version1.AssetsApi;
        root = GetComponent<UIDocument>().rootVisualElement;
        assetId = root.Q<TextField>("assetId");

        collection = root.Q<Label>("collection");
        contract = root.Q<Label>("contract");
        owner = root.Q<Label>("owner");

        getAsset = root.Q<Button>("getAsset");
        getAsset.clicked += GetAsset_clicked;
    }

    private async void GetAsset_clicked()
    {
        var asset = await assetsApi.Asset(assetId.value);

        if (asset != null)
        {
            Debug.Log("asset found");
            collection.text = $"Collection: {asset.Data.Collection.Name}";
            contract.text = $"Contract: {asset.Data.Contract}";
            owner.text = $"Owner: {asset.Data.Owner}";
        }
        else
            Debug.Log("asset not found.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
