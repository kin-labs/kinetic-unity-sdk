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
  public class CreateAccountRequest {
    /// <summary>
    /// Gets or Sets Commitment
    /// </summary>
    [DataMember(Name="commitment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "commitment")]
    public string Commitment { get; set; }

    /// <summary>
    /// Gets or Sets Environment
    /// </summary>
    [DataMember(Name="environment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "environment")]
    public string Environment { get; set; }

    /// <summary>
    /// Gets or Sets Index
    /// </summary>
    [DataMember(Name="index", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "index")]
    public int Index { get; set; }

    /// <summary>
    /// Gets or Sets LastValidBlockHeight
    /// </summary>
    [DataMember(Name="lastValidBlockHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastValidBlockHeight")]
    public int LastValidBlockHeight { get; set; }

    /// <summary>
    /// Gets or Sets Mint
    /// </summary>
    [DataMember(Name="mint", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mint")]
    public string Mint { get; set; }

    /// <summary>
    /// Gets or Sets ReferenceId
    /// </summary>
    [DataMember(Name="referenceId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "referenceId")]
    public string ReferenceId { get; set; }

    /// <summary>
    /// Gets or Sets ReferenceType
    /// </summary>
    [DataMember(Name="referenceType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "referenceType")]
    public string ReferenceType { get; set; }

    /// <summary>
    /// Gets or Sets Tx
    /// </summary>
    [DataMember(Name="tx", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tx")]
    public string Tx { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CreateAccountRequest {\n");
      sb.Append("  Commitment: ").Append(Commitment).Append("\n");
      sb.Append("  Environment: ").Append(Environment).Append("\n");
      sb.Append("  Index: ").Append(Index).Append("\n");
      sb.Append("  LastValidBlockHeight: ").Append(LastValidBlockHeight).Append("\n");
      sb.Append("  Mint: ").Append(Mint).Append("\n");
      sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
      sb.Append("  ReferenceType: ").Append(ReferenceType).Append("\n");
      sb.Append("  Tx: ").Append(Tx).Append("\n");
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
