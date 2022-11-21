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
  public class AppConfigEnvironment {
    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Explorer
    /// </summary>
    [DataMember(Name="explorer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "explorer")]
    public string Explorer { get; set; }

    /// <summary>
    /// Gets or Sets Cluster
    /// </summary>
    [DataMember(Name="cluster", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cluster")]
    public AppConfigCluster Cluster { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AppConfigEnvironment {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Explorer: ").Append(Explorer).Append("\n");
      sb.Append("  Cluster: ").Append(Cluster).Append("\n");
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
