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
  public class CompiledInstruction {
    /// <summary>
    /// Gets or Sets ProgramIdIndex
    /// </summary>
    [DataMember(Name="programIdIndex", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "programIdIndex")]
    public int ProgramIdIndex { get; set; }

    /// <summary>
    /// Gets or Sets Accounts
    /// </summary>
    [DataMember(Name="accounts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accounts")]
    public List<int> Accounts { get; set; }

    /// <summary>
    /// Gets or Sets Data
    /// </summary>
    [DataMember(Name="data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "data")]
    public string Data { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CompiledInstruction {\n");
      sb.Append("  ProgramIdIndex: ").Append(ProgramIdIndex).Append("\n");
      sb.Append("  Accounts: ").Append(Accounts).Append("\n");
      sb.Append("  Data: ").Append(Data).Append("\n");
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
