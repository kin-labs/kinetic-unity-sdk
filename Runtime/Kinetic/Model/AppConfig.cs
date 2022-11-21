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
  public class AppConfig {
    /// <summary>
    /// Gets or Sets App
    /// </summary>
    [DataMember(Name="app", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "app")]
    public AppConfigApp App { get; set; }

    /// <summary>
    /// Gets or Sets Api
    /// </summary>
    [DataMember(Name="api", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "api")]
    public AppConfigApi Api { get; set; }

    /// <summary>
    /// Gets or Sets Environment
    /// </summary>
    [DataMember(Name="environment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "environment")]
    public AppConfigEnvironment Environment { get; set; }

    /// <summary>
    /// Gets or Sets Mint
    /// </summary>
    [DataMember(Name="mint", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mint")]
    public AppConfigMint Mint { get; set; }

    /// <summary>
    /// Gets or Sets Mints
    /// </summary>
    [DataMember(Name="mints", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mints")]
    public List<AppConfigMint> Mints { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AppConfig {\n");
      sb.Append("  App: ").Append(App).Append("\n");
      sb.Append("  Api: ").Append(Api).Append("\n");
      sb.Append("  Environment: ").Append(Environment).Append("\n");
      sb.Append("  Mint: ").Append(Mint).Append("\n");
      sb.Append("  Mints: ").Append(Mints).Append("\n");
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
