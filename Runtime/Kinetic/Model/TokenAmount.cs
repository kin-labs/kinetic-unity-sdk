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
  public class TokenAmount {
    /// <summary>
    /// Gets or Sets Amount
    /// </summary>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public string Amount { get; set; }

    /// <summary>
    /// Gets or Sets Decimals
    /// </summary>
    [DataMember(Name="decimals", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "decimals")]
    public int Decimals { get; set; }

    /// <summary>
    /// Gets or Sets UiAmount
    /// </summary>
    [DataMember(Name="uiAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "uiAmount")]
    public int? UiAmount { get; set; }

    /// <summary>
    /// Gets or Sets UiAmountString
    /// </summary>
    [DataMember(Name="uiAmountString", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "uiAmountString")]
    public string UiAmountString { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TokenAmount {\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
      sb.Append("  Decimals: ").Append(Decimals).Append("\n");
      sb.Append("  UiAmount: ").Append(UiAmount).Append("\n");
      sb.Append("  UiAmountString: ").Append(UiAmountString).Append("\n");
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
