using AtomicAssetsApiClient.Core.Exceptions;
using AtomicAssetsApiClient.Unity3D;
using AtomicAssetsApiClient.Unity3D.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GetCollectionUIScript : MonoBehaviour
{
    VisualElement root;
    TextField CollectionName;
    Button getCollection;

    Label author;
    Label Name;
    Label contract;

    CollectionsApi collectionsApi;

    // Start is called before the first frame update
    void Start()
    {
        collectionsApi = AtomicAssetsApiFactory.Version1.CollectionsApi;
        root = GetComponent<UIDocument>().rootVisualElement;
        CollectionName = root.Q<TextField>("collectionName");

        author = root.Q<Label>("author");
        Name = root.Q<Label>("name");
        contract = root.Q<Label>("contract");

        getCollection = root.Q<Button>("getCollection");
        getCollection.clicked += GetCollection_clicked;
    }

    private async void GetCollection_clicked()
    {
        try
        {
            var collection = await collectionsApi.Collection(CollectionName.value);

            if (collection != null)
            {
                Debug.Log("asset found");
                Name.text = $"Name: {collection.Data.Name}";
                author.text = $"Author: {collection.Data.Author}";
                contract.text = $"Contract: {collection.Data.Contract}";
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
}
