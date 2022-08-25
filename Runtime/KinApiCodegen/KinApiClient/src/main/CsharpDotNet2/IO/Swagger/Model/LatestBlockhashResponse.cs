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
  public class LatestBlockhashResponse {
    /// <summary>
    /// Gets or Sets Blockhash
    /// </summary>
    [DataMember(Name="blockhash", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockhash")]
    public string Blockhash { get; set; }

    /// <summary>
    /// Gets or Sets LastValidBlockHeight
    /// </summary>
    [DataMember(Name="lastValidBlockHeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastValidBlockHeight")]
    public decimal? LastValidBlockHeight { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LatestBlockhashResponse {\n");
      sb.Append("  Blockhash: ").Append(Blockhash).Append("\n");
      sb.Append("  LastValidBlockHeight: ").Append(LastValidBlockHeight).Append("\n");
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
