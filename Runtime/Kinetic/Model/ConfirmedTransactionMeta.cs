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
  public class ConfirmedTransactionMeta {
    /// <summary>
    /// Gets or Sets Fee
    /// </summary>
    [DataMember(Name="fee", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fee")]
    public decimal? Fee { get; set; }

    /// <summary>
    /// Gets or Sets InnerInstructions
    /// </summary>
    [DataMember(Name="innerInstructions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "innerInstructions")]
    public List<string> InnerInstructions { get; set; }

    /// <summary>
    /// Gets or Sets PreBalances
    /// </summary>
    [DataMember(Name="preBalances", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "preBalances")]
    public List<int> PreBalances { get; set; }

    /// <summary>
    /// Gets or Sets PostBalances
    /// </summary>
    [DataMember(Name="postBalances", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postBalances")]
    public List<int> PostBalances { get; set; }

    /// <summary>
    /// Gets or Sets LogMessages
    /// </summary>
    [DataMember(Name="logMessages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "logMessages")]
    public List<string> LogMessages { get; set; }

    /// <summary>
    /// Gets or Sets PreTokenBalances
    /// </summary>
    [DataMember(Name="preTokenBalances", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "preTokenBalances")]
    public List<string> PreTokenBalances { get; set; }

    /// <summary>
    /// Gets or Sets PostTokenBalances
    /// </summary>
    [DataMember(Name="postTokenBalances", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postTokenBalances")]
    public List<string> PostTokenBalances { get; set; }

    /// <summary>
    /// Gets or Sets Err
    /// </summary>
    [DataMember(Name="err", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "err")]
    public Object Err { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ConfirmedTransactionMeta {\n");
      sb.Append("  Fee: ").Append(Fee).Append("\n");
      sb.Append("  InnerInstructions: ").Append(InnerInstructions).Append("\n");
      sb.Append("  PreBalances: ").Append(PreBalances).Append("\n");
      sb.Append("  PostBalances: ").Append(PostBalances).Append("\n");
      sb.Append("  LogMessages: ").Append(LogMessages).Append("\n");
      sb.Append("  PreTokenBalances: ").Append(PreTokenBalances).Append("\n");
      sb.Append("  PostTokenBalances: ").Append(PostTokenBalances).Append("\n");
      sb.Append("  Err: ").Append(Err).Append("\n");
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
