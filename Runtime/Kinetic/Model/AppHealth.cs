using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AppHealth {
    /// <summary>
    /// Gets or Sets IsSolanaOk
    /// </summary>
    [DataMember(Name="isSolanaOk", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isSolanaOk")]
    public bool IsSolanaOk { get; set; }

    /// <summary>
    /// Gets or Sets IsKineticOk
    /// </summary>
    [DataMember(Name="isKineticOk", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isKineticOk")]
    public bool IsKineticOk { get; set; }

    /// <summary>
    /// Gets or Sets Time
    /// </summary>
    [DataMember(Name="time", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "time")]
    public DateTime Time { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AppHealth {\n");
      sb.Append("  IsSolanaOk: ").Append(IsSolanaOk).Append("\n");
      sb.Append("  IsKineticOk: ").Append(IsKineticOk).Append("\n");
      sb.Append("  Time: ").Append(Time).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
    }

}
}
