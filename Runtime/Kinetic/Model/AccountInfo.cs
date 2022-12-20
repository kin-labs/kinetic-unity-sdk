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
  public class AccountInfo {
    /// <summary>
    /// Gets or Sets Account
    /// </summary>
    [DataMember(Name="account", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "account")]
    public string Account { get; set; }

    /// <summary>
    /// Gets or Sets IsMint
    /// </summary>
    [DataMember(Name="isMint", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isMint")]
    public bool IsMint { get; set; }

    /// <summary>
    /// Gets or Sets IsOwner
    /// </summary>
    [DataMember(Name="isOwner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isOwner")]
    public bool IsOwner { get; set; }

    /// <summary>
    /// Gets or Sets IsTokenAccount
    /// </summary>
    [DataMember(Name="isTokenAccount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isTokenAccount")]
    public bool IsTokenAccount { get; set; }

    /// <summary>
    /// Gets or Sets Owner
    /// </summary>
    [DataMember(Name="owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Gets or Sets Program
    /// </summary>
    [DataMember(Name="program", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "program")]
    public string Program { get; set; }

    /// <summary>
    /// Gets or Sets Tokens
    /// </summary>
    [DataMember(Name="tokens", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tokens")]
    public List<TokenInfo> Tokens { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AccountInfo {\n");
      sb.Append("  Account: ").Append(Account).Append("\n");
      sb.Append("  IsMint: ").Append(IsMint).Append("\n");
      sb.Append("  IsOwner: ").Append(IsOwner).Append("\n");
      sb.Append("  IsTokenAccount: ").Append(IsTokenAccount).Append("\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
      sb.Append("  Program: ").Append(Program).Append("\n");
      sb.Append("  Tokens: ").Append(Tokens).Append("\n");
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
