using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product
{
    public int Id {get; private set;}
    public string Name {get; private set;}
    public string Description {get; private set;}
    public decimal UnitPrice {get; private set;}
    public bool IsFeatured {get; private set;}

    public Product(int Id, string Name, string Desc, decimal UnitPrice, int IsFeatured)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Desc;
        this.UnitPrice = UnitPrice;
        this.IsFeatured = IsFeatured != 0;
    }
    public override string ToString()
    {
        return $"Id {Id}\nName:{Name}\nDescription:{Description}\nUnitPrice:{UnitPrice}\nIsFeatured:{IsFeatured}\n";
    }
}
