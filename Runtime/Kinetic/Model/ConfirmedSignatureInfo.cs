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
  public class ConfirmedSignatureInfo {
    /// <summary>
    /// Gets or Sets Signature
    /// </summary>
    [DataMember(Name="signature", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "signature")]
    public string Signature { get; set; }

    /// <summary>
    /// Gets or Sets Slot
    /// </summary>
    [DataMember(Name="slot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "slot")]
    public decimal? Slot { get; set; }

    /// <summary>
    /// Gets or Sets Err
    /// </summary>
    [DataMember(Name="err", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "err")]
    public string Err { get; set; }

    /// <summary>
    /// Gets or Sets Memo
    /// </summary>
    [DataMember(Name="memo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "memo")]
    public string Memo { get; set; }

    /// <summary>
    /// Gets or Sets BlockTime
    /// </summary>
    [DataMember(Name="blockTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockTime")]
    public decimal? BlockTime { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ConfirmedSignatureInfo {\n");
      sb.Append("  Signature: ").Append(Signature).Append("\n");
      sb.Append("  Slot: ").Append(Slot).Append("\n");
      sb.Append("  Err: ").Append(Err).Append("\n");
      sb.Append("  Memo: ").Append(Memo).Append("\n");
      sb.Append("  BlockTime: ").Append(BlockTime).Append("\n");
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
