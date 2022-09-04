using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class BalanceResponse {
    /// <summary>
    /// Gets or Sets Balance
    /// </summary>
    [DataMember(Name="balance", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "balance")]
    public string Balance { get; set; }

    /// <summary>
    /// Gets or Sets Mints
    /// </summary>
    [DataMember(Name="mints", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mints")]
    public Object Mints { get; set; }

    /// <summary>
    /// Gets or Sets Tokens
    /// </summary>
    [DataMember(Name="tokens", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tokens")]
    public List<BalanceToken> Tokens { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BalanceResponse {\n");
      sb.Append("  Balance: ").Append(Balance).Append("\n");
      sb.Append("  Mints: ").Append(Mints).Append("\n");
      sb.Append("  Tokens: ").Append(Tokens).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
