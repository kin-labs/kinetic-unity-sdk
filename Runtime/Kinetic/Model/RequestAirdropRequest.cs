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
  public class RequestAirdropRequest {
    /// <summary>
    /// Gets or Sets Account
    /// </summary>
    [DataMember(Name="account", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "account")]
    public string Account { get; set; }

    /// <summary>
    /// Gets or Sets Amount
    /// </summary>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public string Amount { get; set; }

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
    /// Gets or Sets Mint
    /// </summary>
    [DataMember(Name="mint", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mint")]
    public string Mint { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestAirdropRequest {\n");
      sb.Append("  Account: ").Append(Account).Append("\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
      sb.Append("  Commitment: ").Append(Commitment).Append("\n");
      sb.Append("  Environment: ").Append(Environment).Append("\n");
      sb.Append("  Index: ").Append(Index).Append("\n");
      sb.Append("  Mint: ").Append(Mint).Append("\n");
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
