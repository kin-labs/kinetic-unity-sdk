using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;


using ClusterType = System.String;
using Commitment = System.String;
using ConfirmationStatus = System.String;
using TransactionErrorType = System.String;
using TransactionStatus = System.String;

namespace Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TransactionResponse {
    /// <summary>
    /// Gets or Sets Slot
    /// </summary>
    [DataMember(Name="slot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "slot")]
    public int? Slot { get; set; }

    /// <summary>
    /// Gets or Sets Transaction
    /// </summary>
    [DataMember(Name="transaction", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transaction")]
    public TransactionData Transaction { get; set; }

    /// <summary>
    /// Gets or Sets Meta
    /// </summary>
    [DataMember(Name="meta", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "meta")]
    public ConfirmedTransactionMeta Meta { get; set; }

    /// <summary>
    /// Gets or Sets BlockTime
    /// </summary>
    [DataMember(Name="blockTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockTime")]
    public int? BlockTime { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TransactionResponse {\n");
      sb.Append("  Slot: ").Append(Slot).Append("\n");
      sb.Append("  Transaction: ").Append(Transaction).Append("\n");
      sb.Append("  Meta: ").Append(Meta).Append("\n");
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
