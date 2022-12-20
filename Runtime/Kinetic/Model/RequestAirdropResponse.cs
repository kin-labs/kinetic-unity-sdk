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
  public class RequestAirdropResponse {
    /// <summary>
    /// Gets or Sets Signature
    /// </summary>
    [DataMember(Name="signature", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "signature")]
    public string Signature { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestAirdropResponse {\n");
      sb.Append("  Signature: ").Append(Signature).Append("\n");
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
