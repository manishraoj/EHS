
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace EasyHousingSolutions_Entity
{

using System;
    using System.Collections.Generic;
    
public partial class City
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public City()
    {

        this.Sellers = new HashSet<Seller>();

        this.Properties = new HashSet<Property>();

    }


    public int CityId { get; set; }

    public string CityName { get; set; }

    public int StateId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Seller> Sellers { get; set; }

    public virtual State State { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Property> Properties { get; set; }

}

}
