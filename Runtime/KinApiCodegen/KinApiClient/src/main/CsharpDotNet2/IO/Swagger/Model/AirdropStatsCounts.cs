using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AirdropStatsCounts {
    /// <summary>
    /// Gets or Sets AverageValue
    /// </summary>
    [DataMember(Name="averageValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "averageValue")]
    public decimal? AverageValue { get; set; }

    /// <summary>
    /// Gets or Sets Total
    /// </summary>
    [DataMember(Name="total", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total")]
    public decimal? Total { get; set; }

    /// <summary>
    /// Gets or Sets TotalValue
    /// </summary>
    [DataMember(Name="totalValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalValue")]
    public decimal? TotalValue { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AirdropStatsCounts {\n");
      sb.Append("  AverageValue: ").Append(AverageValue).Append("\n");
      sb.Append("  Total: ").Append(Total).Append("\n");
      sb.Append("  TotalValue: ").Append(TotalValue).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
