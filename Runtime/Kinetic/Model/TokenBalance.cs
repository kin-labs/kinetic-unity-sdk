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
  public class TokenBalance {
    /// <summary>
    /// Gets or Sets AccountIndex
    /// </summary>
    [DataMember(Name="accountIndex", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountIndex")]
    public int AccountIndex { get; set; }

    /// <summary>
    /// Gets or Sets Mint
    /// </summary>
    [DataMember(Name="mint", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mint")]
    public string Mint { get; set; }

    /// <summary>
    /// Gets or Sets Owner
    /// </summary>
    [DataMember(Name="owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Gets or Sets UiTokenAmount
    /// </summary>
    [DataMember(Name="uiTokenAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "uiTokenAmount")]
    public TokenAmount UiTokenAmount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TokenBalance {\n");
      sb.Append("  AccountIndex: ").Append(AccountIndex).Append("\n");
      sb.Append("  Mint: ").Append(Mint).Append("\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
      sb.Append("  UiTokenAmount: ").Append(UiTokenAmount).Append("\n");
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
