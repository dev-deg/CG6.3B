using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetData
{
    public enum CURRENCY
    {
        Gold, Diamonds
    }
    private string _id;
    private string _name;
    private string _thumbnailUrl;
    private string _price;
    private CURRENCY _currency;
    private int _discount;

    public string ID
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string ThumbnailUrl
    {
        get => _thumbnailUrl;
        set => _thumbnailUrl = value;
    }

    public string Price
    {
        get => _price;
        set => _price = value;
    }

    public CURRENCY Currency
    {
        get => _currency;
        set => _currency = value;
    }

    public int Discount
    {
        get => _discount;
        set => _discount = value;
    }
}
