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
  public class GetTransactionResponse {
    /// <summary>
    /// Gets or Sets Signature
    /// </summary>
    [DataMember(Name="signature", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "signature")]
    public string Signature { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public SignatureStatus Status { get; set; }

    /// <summary>
    /// Gets or Sets Transaction
    /// </summary>
    [DataMember(Name="transaction", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transaction")]
    public TransactionResponse Transaction { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetTransactionResponse {\n");
      sb.Append("  Signature: ").Append(Signature).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  Transaction: ").Append(Transaction).Append("\n");
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
