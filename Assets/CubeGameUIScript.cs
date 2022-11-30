using UnityEngine;
using UnityEngine.UIElements;

public class CubeGameUIScript : MonoBehaviour
{
    VisualElement root;
    TextField assetId;
    Button getAssets;
    Label asset;

    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        assetId = root.Q<TextField>("assetId");
        asset = root.Q<Label>("asset");

        getAssets = root.Q<Button>("getAssets");
        getAssets.clicked += GetAsset_clicked;
    }

    private void GetAsset_clicked()
    {
        var logString = assetId.value;
        asset.text = logString;
        Debug.Log("Button clicked with value: " + logString);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
