using System;
using System.Collections.Generic;
using System.Linq;
using AtomicAssetsApiClient;
using AtomicAssetsApiClient.Assets;
using AtomicAssetsApiClient.Collections;
using AtomicAssetsApiClient.Exceptions;
using UnityEngine;
using UnityEngine.UIElements;

public class AtomicAssetPanel : MonoBehaviour
{
    /*
     * Child-Controls
     */
    public VisualElement Root;

    private Label _collectionNameLabel;
    private Label _ownerLabel;
    private Label _sellerLabel;
    private Label _tradeOfferIdLabel;
    private Label _nftNameLabel;
    private Label _headerLabel;
    private Label _idLabel;
    private Label _priceLabel;
    private Label _mintNumberLabel;
    private Label _backedTokenLabel;
    private Label _schemaNameLabel;
    private Label _templateIdLabel;
    private Label _propertiesTransferableLabel;
    private Label _propertiesBurnableLabel;

    private Button _searchButton;

    private DropdownField _selectorDropdownField;
    private static TextField _collectionNameOrAssetId;


    /*
     * Fields/Properties
     */
    private AssetsApi _assetsApi;
    private CollectionsApi _collectionsApi;

    private List<string> _searchTypes;

    public AtomicAssetsErrorPanel AtomicAssetsErrorPanel;

    public Focusable focusedElement { get; }

    void Start()
    {
        Root = GetComponent<UIDocument>().rootVisualElement;

        _assetsApi = AtomicAssetsApiFactory.Version1.AssetsApi;
        _collectionsApi = AtomicAssetsApiFactory.Version1.CollectionsApi;

        _collectionNameOrAssetId = Root.Q<TextField>("collection-name-or-id-textfield");

        _headerLabel = Root.Q<Label>("header-label");
        _nftNameLabel = Root.Q<Label>("nft-name-label");
        _idLabel = Root.Q<Label>("id-label");
        _tradeOfferIdLabel = Root.Q<Label>("trade-offer-id-label");
        _priceLabel = Root.Q<Label>("price-label");
        _ownerLabel = Root.Q<Label>("owner-label");
        _sellerLabel = Root.Q<Label>("seller-label");
        _mintNumberLabel = Root.Q<Label>("mint-number-label");
        _backedTokenLabel = Root.Q<Label>("backed-token-label");
        _schemaNameLabel = Root.Q<Label>("schema-label");
        _templateIdLabel = Root.Q<Label>("template-id-label");
        _collectionNameLabel = Root.Q<Label>("collection-name-label");
        _propertiesTransferableLabel = Root.Q<Label>("properties-transferable-label");
        _propertiesBurnableLabel = Root.Q<Label>("properties-burnable-label");

        _selectorDropdownField = Root.Q<DropdownField>("selector-dropdown");

        _searchButton = Root.Q<Button>("search-button");

        BindButtons();
    }

    #region Button Binding

    private void BindButtons()
    {
        _searchButton.clicked += SearchAsset;

        _searchTypes = new List<string>()
        {
            { "Asset ID" },
            { "Collection Name" }
        };

        _selectorDropdownField.choices = _searchTypes;

        _selectorDropdownField.value = _selectorDropdownField.choices.First();

        _selectorDropdownField.RegisterCallback<ChangeEvent<string>>(evt =>
        {
            _selectorDropdownField.value = _selectorDropdownField.value;
        });
    }
    #endregion

    #region Rebind
    /// <summary>
    /// Rebind Method for binding AssetDto api
    /// </summary>
    /// <param name="asset"></param>
    private void Rebind(AssetDto asset)
    {
        _collectionNameLabel.text = asset.Data.Collection.Name;
        _ownerLabel.text = asset.Data.Owner;
        _nftNameLabel.text = asset.Data.Name;
        _idLabel.text = asset.Data.AssetId;
        _mintNumberLabel.text = $"{asset.Data.TemplateMint} Of {asset.Data.Template.IssuedSupply}";
        _backedTokenLabel.text = asset.Data.BackedTokens.Length.ToString();
        _schemaNameLabel.text = asset.Data.Schema.SchemaName;
        _templateIdLabel.text = asset.Data.Template.TemplateId;
    }

    /// <summary>
    /// Rebind Method for binding CollectionDto api
    /// </summary>
    /// <param name="asset"></param>
    private void Rebind(CollectionDto asset)
    {
        _collectionNameLabel.text = asset.Data.CollectionName;
        //_ownerLabel.text = asset.Data.Name;
        _nftNameLabel.text = asset.Data.Name;
        _idLabel.text = asset.Data.Name;
        _mintNumberLabel.text = asset.Data.MarketFee.ToString();
    }

    #endregion

    #region Others

    /// <summary>
    /// SearchAsset Method to evaluate input search for certain api
    /// </summary>
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

    /// <summary>
    /// Extension-method to show an UI Element (set it to visible)
    /// </summary>
    /// <param name="element"></param>
    public void Show(VisualElement element)
    {
        if (element == null)
            return;

        element.style.visibility = Visibility.Visible;
        element.style.display = DisplayStyle.Flex;
    }

    /// <summary>
    /// Extension-method to hide an UI Element (set it to invisible)
    /// </summary>
    /// <param name="element"></param>
    public void Hide(VisualElement element)
    {
        if (element == null)
            return;

        element.style.visibility = Visibility.Hidden;
        element.style.display = DisplayStyle.None;
    }

    /// <summary>Called when ctrl + v is pressed in browser (webgl)</summary>
    /// <param name="pastedText">The pasted text.</param>
    public static void OnBrowserClipboardPaste(string pastedText)
    {
        if (_collectionNameOrAssetId.focusController.focusedElement == _collectionNameOrAssetId)
            _collectionNameOrAssetId.value = pastedText;
    }

    #endregion
}
