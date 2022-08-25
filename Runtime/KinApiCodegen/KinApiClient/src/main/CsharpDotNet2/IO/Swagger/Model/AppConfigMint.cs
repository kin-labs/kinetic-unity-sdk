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
  public class AppConfigMint {
    /// <summary>
    /// Gets or Sets Airdrop
    /// </summary>
    [DataMember(Name="airdrop", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "airdrop")]
    public bool? Airdrop { get; set; }

    /// <summary>
    /// Gets or Sets AirdropAmount
    /// </summary>
    [DataMember(Name="airdropAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "airdropAmount")]
    public decimal? AirdropAmount { get; set; }

    /// <summary>
    /// Gets or Sets AirdropMax
    /// </summary>
    [DataMember(Name="airdropMax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "airdropMax")]
    public decimal? AirdropMax { get; set; }

    /// <summary>
    /// Gets or Sets Decimals
    /// </summary>
    [DataMember(Name="decimals", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "decimals")]
    public decimal? Decimals { get; set; }

    /// <summary>
    /// Gets or Sets FeePayer
    /// </summary>
    [DataMember(Name="feePayer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "feePayer")]
    public string FeePayer { get; set; }

    /// <summary>
    /// Gets or Sets LogoUrl
    /// </summary>
    [DataMember(Name="logoUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "logoUrl")]
    public string LogoUrl { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets ProgramId
    /// </summary>
    [DataMember(Name="programId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "programId")]
    public string ProgramId { get; set; }

    /// <summary>
    /// Gets or Sets PublicKey
    /// </summary>
    [DataMember(Name="publicKey", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "publicKey")]
    public string PublicKey { get; set; }

    /// <summary>
    /// Gets or Sets Symbol
    /// </summary>
    [DataMember(Name="symbol", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "symbol")]
    public string Symbol { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AppConfigMint {\n");
      sb.Append("  Airdrop: ").Append(Airdrop).Append("\n");
      sb.Append("  AirdropAmount: ").Append(AirdropAmount).Append("\n");
      sb.Append("  AirdropMax: ").Append(AirdropMax).Append("\n");
      sb.Append("  Decimals: ").Append(Decimals).Append("\n");
      sb.Append("  FeePayer: ").Append(FeePayer).Append("\n");
      sb.Append("  LogoUrl: ").Append(LogoUrl).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ProgramId: ").Append(ProgramId).Append("\n");
      sb.Append("  PublicKey: ").Append(PublicKey).Append("\n");
      sb.Append("  Symbol: ").Append(Symbol).Append("\n");
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
