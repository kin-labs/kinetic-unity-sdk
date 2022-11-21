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
  public class SignatureStatus {
    /// <summary>
    /// Gets or Sets Slot
    /// </summary>
    [DataMember(Name="slot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "slot")]
    public decimal? Slot { get; set; }

    /// <summary>
    /// Gets or Sets Confirmations
    /// </summary>
    [DataMember(Name="confirmations", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmations")]
    public decimal? Confirmations { get; set; }

    /// <summary>
    /// Gets or Sets Err
    /// </summary>
    [DataMember(Name="err", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "err")]
    public Object Err { get; set; }

    /// <summary>
    /// Gets or Sets ConfirmationStatus
    /// </summary>
    [DataMember(Name="confirmationStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confirmationStatus")]
    public string ConfirmationStatus { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SignatureStatus {\n");
      sb.Append("  Slot: ").Append(Slot).Append("\n");
      sb.Append("  Confirmations: ").Append(Confirmations).Append("\n");
      sb.Append("  Err: ").Append(Err).Append("\n");
      sb.Append("  ConfirmationStatus: ").Append(ConfirmationStatus).Append("\n");
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
