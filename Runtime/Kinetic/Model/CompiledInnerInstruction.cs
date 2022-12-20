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
  public class CompiledInnerInstruction {
    /// <summary>
    /// Gets or Sets Index
    /// </summary>
    [DataMember(Name="index", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "index")]
    public int Index { get; set; }

    /// <summary>
    /// Gets or Sets Instructions
    /// </summary>
    [DataMember(Name="instructions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "instructions")]
    public List<CompiledInstruction> Instructions { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CompiledInnerInstruction {\n");
      sb.Append("  Index: ").Append(Index).Append("\n");
      sb.Append("  Instructions: ").Append(Instructions).Append("\n");
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
