
using Pocket_Cookbook_Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class KrogerProduct
{
    [Key]
    public int primary_key_id { get; set; }
    public virtual ICollection<Datum> data { get; set; }
    public Meta meta { get; set; }
}

public class Meta
{
    [Key]
    public int primary_key_id { get; set; }
    public Pagination pagination { get; set; }
    public virtual KrogerProduct? Product { get; set; }
    [ForeignKey("Product")]
    public int productFK { get; set; }
}

public class Pagination
{
    [Key]
    public int primary_key_id { get; set; }
    public int start { get; set; }
    public int limit { get; set; }
    public int total { get; set; }
    public virtual Meta? Meta { get; set; }
    [ForeignKey("Meta")]
    public int metaFK { get; set; }
}

public class Datum
{
    [Key]
    public int primary_key_id { get; set; }
    public string productId { get; set; }
    public string upc { get; set; }
    //public Aislelocation[] aisleLocations { get; set; }
    public string brand { get; set; }
    //public virtual ICollection<Categories> categories { get; set; }
    public string countryOrigin { get; set; }
    public string description { get; set; }
    public virtual ICollection<Image> images { get; set; }
    public virtual ICollection<Item> items { get; set; }
    //public Iteminformation itemInformation { get; set; }
    //public Temperature temperature { get; set; }
    public virtual KrogerProduct? Product { get; set; }
    [ForeignKey("Product")]
    public int productFK { get; set; }
}

//public class Iteminformation
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public string depth { get; set; }
//    public string height { get; set; }
//    public string width { get; set; }
//}

//public class Temperature
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public string indicator { get; set; }
//    public bool heatSensitive { get; set; }
//}

//public class Aislelocation
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public string bayNumber { get; set; }
//    public string description { get; set; }
//    public string number { get; set; }
//    public string numberOfFacings { get; set; }
//    public string side { get; set; }
//    public string shelfNumber { get; set; }
//    public string shelfPositionInBay { get; set; }
//}

public class Image
{
    [Key]
    public int primary_key_id { get; set; }
    public string perspective { get; set; }
    public Size[] sizes { get; set; }
    public bool featured { get; set; }
    public virtual Datum? Data { get; set; }
    [ForeignKey("Data")]
    public int dataFK { get; set; }
}

public class Size
{
    [Key]
    public int primary_key_id { get; set; }
    public string size { get; set; }
    public string url { get; set; }
    public virtual Image? Img { get; set; }
    [ForeignKey("Img")]
    public int imgFK { get; set; }
}

public class Item
{
    [Key]
    public int primary_key_id { get; set; }
    public string itemId { get; set; }
    public Inventory inventory { get; set; }
    public bool favorite { get; set; }
    public Fulfillment fulfillment { get; set; }
    public Price price { get; set; }
    public string size { get; set; }
    public string soldBy { get; set; }
    public virtual Datum? Data { get; set; }
    [ForeignKey("Data")]
    public int dataFK { get; set; }
}

public class Inventory
{
    [Key]
    public int primary_key_id { get; set; }
    public string stockLevel { get; set; }
}

public class Fulfillment
{
    [Key]
    public int primary_key_id { get; set; }
    public bool curbside { get; set; }
    public bool delivery { get; set; }
    public bool inStore { get; set; }
    public bool shipToHome { get; set; }
}

public class Price
{
    [Key]
    public int primary_key_id { get; set; }
    public float regular { get; set; }
    public float promo { get; set; }
}

//public class Categories
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    string category { get; set; }
//    public virtual Datum? Data { get; set; }
//    [ForeignKey("Data")]
//    public int dataFK { get; set; }
//}

//public class KrogerProduct
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public virtual ICollection<Datum> data { get; set; }
//    public Meta meta { get; set; }
//}

//public class Meta
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public Pagination pagination { get; set; }
//    public virtual KrogerProduct? Product { get; set; }
//    [ForeignKey("Product")]
//    public int productFK { get; set; }
//}

//public class Pagination
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public int start { get; set; }
//    public int limit { get; set; }
//    public int total { get; set; }
//public virtual Meta? Meta { get; set; }
//[ForeignKey("Meta")]
//public int metaFK { get; set; }
//}

//public class Datum
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public string productId { get; set; }
//    public string upc { get; set; }
//    //public object[] aisleLocations { get; set; }
//    public string brand { get; set; }
//    public virtual ICollection<Categories> categories { get; set; }
//    public string countryOrigin { get; set; }
//    public string description { get; set; }
//public virtual ICollection<Image> images { get; set; }
//public virtual ICollection<Item> items { get; set; }
//    //public Iteminformation itemInformation { get; set; }
//    public Temperature temperature { get; set; }
//public virtual KrogerProduct? Product { get; set; }
//[ForeignKey("Product")]
//public int productFK { get; set; }
//}

////public class Iteminformation
////{
////}

//public class Temperature
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public string indicator { get; set; }
//    public bool heatSensitive { get; set; }
//public virtual Datum? Data { get; set; }
//[ForeignKey("Data")]
//public int dataFK { get; set; }
//}

//public class Image
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public string perspective { get; set; }
//    public bool featured { get; set; }
//    public virtual ICollection<Size> sizes { get; set; }
//    public virtual Datum? Data { get; set; }
//    [ForeignKey("Data")]
//    public int dataFK { get; set; }
//}

//public class Size
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public string size { get; set; }
//    public string url { get; set; }
//    public virtual Image? Image { get; set; }
//    [ForeignKey("Image")]
//    public int imageFK { get; set; }
//}

//public class Item
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public string itemId { get; set; }
//    public bool favorite { get; set; }
//    public Fulfillment fulfillment { get; set; }
//    public string size { get; set; }
//    public virtual Datum? Data { get; set; }
//    [ForeignKey("Data")]
//    public int dataFK { get; set; }
//}

//public class Fulfillment
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    public bool curbside { get; set; }
//    public bool delivery { get; set; }
//    public bool inStore { get; set; }
//    public bool shipToHome { get; set; }
//    public virtual Item? Item { get; set; }
//    [ForeignKey("Item")]
//    public int itemFK { get; set; }
//}

//public class Categories
//{
//    [Key]
//    public int primary_key_id { get; set; }
//    string category { get; set; }
//    public virtual Datum? Data { get; set; }
//    [ForeignKey("Data")]
//    public int dataFK { get; set; }


//}


