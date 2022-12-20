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
  public class TokenInfo {
    /// <summary>
    /// Gets or Sets Account
    /// </summary>
    [DataMember(Name="account", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "account")]
    public string Account { get; set; }

    /// <summary>
    /// Gets or Sets Balance
    /// </summary>
    [DataMember(Name="balance", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "balance")]
    public string Balance { get; set; }

    /// <summary>
    /// Gets or Sets CloseAuthority
    /// </summary>
    [DataMember(Name="closeAuthority", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "closeAuthority")]
    public string CloseAuthority { get; set; }

    /// <summary>
    /// Gets or Sets Decimals
    /// </summary>
    [DataMember(Name="decimals", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "decimals")]
    public int Decimals { get; set; }

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
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TokenInfo {\n");
      sb.Append("  Account: ").Append(Account).Append("\n");
      sb.Append("  Balance: ").Append(Balance).Append("\n");
      sb.Append("  CloseAuthority: ").Append(CloseAuthority).Append("\n");
      sb.Append("  Decimals: ").Append(Decimals).Append("\n");
      sb.Append("  Mint: ").Append(Mint).Append("\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
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
