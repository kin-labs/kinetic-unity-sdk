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
  public class AirdropStats {
    /// <summary>
    /// Gets or Sets Counts
    /// </summary>
    [DataMember(Name="counts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "counts")]
    public AirdropStatsCounts Counts { get; set; }

    /// <summary>
    /// Gets or Sets Dates
    /// </summary>
    [DataMember(Name="dates", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dates")]
    public List<AirdropStatsDate> Dates { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AirdropStats {\n");
      sb.Append("  Counts: ").Append(Counts).Append("\n");
      sb.Append("  Dates: ").Append(Dates).Append("\n");
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
