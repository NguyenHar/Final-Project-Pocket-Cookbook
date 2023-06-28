using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pocket_Cookbook_Backend.Models
{
    public class KrogerLocation
    {
        [Key]
        public int primary_key_id { get; set; }
        public ICollection<LocationDatum>? data { get; set; }
    }

    public class LocationDatum
    {
        [Key]
        public int primary_key_id { get; set; }
        public Address? address { get; set; }
        public string? chain { get; set; }
        public string? phone { get; set; }
        public Geolocation? geolocation { get; set; }
        //public Hours hours { get; set; }
        public string? locationId { get; set; }
        public string? storeNumber { get; set; }
        public string? divisionNumber { get; set; }
        public string? name { get; set; }
        public virtual KrogerLocation? KrogerLocation { get; set; }
        [ForeignKey("KrogerLocation")]
        public int KrogerFK { get; set; }
    }

    public class Address
    {
        [Key]
        public int primary_key_id { get; set; }
        public string? addressLine1 { get; set; }
        public string? addressLine2 { get; set; }
        public string? city { get; set; }
        public string? county { get; set; }
        public string? state { get; set; }
        public string? zipCode { get; set; }
    }

    public class Geolocation
    {
        [Key]
        public int primary_key_id { get; set; }
        public string? latLng { get; set; }
        public float? latitude { get; set; }
        public float? longitude { get; set; }
    }

    //    public class Hours
    //    {
    //        [Key]
    //        public int primary_key_id { get; set; }
    //        public bool Open24 { get; set; }
    //        public string gmtOffset { get; set; }
    //        public string timezone { get; set; }
    //        public Friday friday { get; set; }
    //        public Monday monday { get; set; }
    //        public Saturday saturday { get; set; }
    //        public Sunday sunday { get; set; }
    //        public Thursday thursday { get; set; }
    //        public Tuesday tuesday { get; set; }
    //        public Wednesday wednesday { get; set; }
    //    }

    //    public class Friday
    //    {
    //        [Key]
    //        public int primary_key_id { get; set; }
    //        public string open { get; set; }
    //        public int close { get; set; }
    //        public bool open24 { get; set; }
    //    }

    //    public class Monday
    //    {
    //        [Key]
    //        public int primary_key_id { get; set; }
    //        public string open { get; set; }
    //        public int close { get; set; }
    //        public bool open24 { get; set; }
    //    }

    //    public class Saturday
    //    {
    //        [Key]
    //        public int primary_key_id { get; set; }
    //        public string open { get; set; }
    //        public int close { get; set; }
    //        public bool open24 { get; set; }
    //    }

    //    public class Sunday
    //    {
    //        [Key]
    //        public int primary_key_id { get; set; }
    //        public string open { get; set; }
    //        public int close { get; set; }
    //        public bool open24 { get; set; }
    //    }

    //    public class Thursday
    //    {
    //        [Key]
    //        public int primary_key_id { get; set; }
    //        public string open { get; set; }
    //        public int close { get; set; }
    //        public bool open24 { get; set; }
    //    }

    //    public class Tuesday
    //    {
    //        [Key]
    //        public int primary_key_id { get; set; }
    //        public string open { get; set; }
    //        public int close { get; set; }
    //        public bool open24 { get; set; }
    //    }

    //    public class Wednesday
    //    {
    //        [Key]
    //        public int primary_key_id { get; set; }
    //        public string open { get; set; }
    //        public int close { get; set; }
    //        public bool open24 { get; set; }
    //    }
}
