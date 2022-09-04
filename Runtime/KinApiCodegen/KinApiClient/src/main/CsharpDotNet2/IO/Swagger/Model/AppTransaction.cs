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
  public class AppTransaction {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets CreatedAt
    /// </summary>
    [DataMember(Name="createdAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or Sets UpdatedAt
    /// </summary>
    [DataMember(Name="updatedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets or Sets Amount
    /// </summary>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public string Amount { get; set; }

    /// <summary>
    /// Gets or Sets Destination
    /// </summary>
    [DataMember(Name="destination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "destination")]
    public string Destination { get; set; }

    /// <summary>
    /// Gets or Sets Errors
    /// </summary>
    [DataMember(Name="errors", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "errors")]
    public List<AppTransactionError> Errors { get; set; }

    /// <summary>
    /// Gets or Sets ExplorerUrl
    /// </summary>
    [DataMember(Name="explorerUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "explorerUrl")]
    public string ExplorerUrl { get; set; }

    /// <summary>
    /// Gets or Sets FeePayer
    /// </summary>
    [DataMember(Name="feePayer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "feePayer")]
    public string FeePayer { get; set; }

    /// <summary>
    /// Gets or Sets Mint
    /// </summary>
    [DataMember(Name="mint", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mint")]
    public string Mint { get; set; }

    /// <summary>
    /// Gets or Sets ProcessingDuration
    /// </summary>
    [DataMember(Name="processingDuration", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "processingDuration")]
    public decimal? ProcessingDuration { get; set; }

    /// <summary>
    /// Gets or Sets ReferenceId
    /// </summary>
    [DataMember(Name="referenceId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "referenceId")]
    public string ReferenceId { get; set; }

    /// <summary>
    /// Gets or Sets ReferenceType
    /// </summary>
    [DataMember(Name="referenceType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "referenceType")]
    public string ReferenceType { get; set; }

    /// <summary>
    /// Gets or Sets Signature
    /// </summary>
    [DataMember(Name="signature", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "signature")]
    public string Signature { get; set; }

    /// <summary>
    /// Gets or Sets SolanaCommitted
    /// </summary>
    [DataMember(Name="solanaCommitted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "solanaCommitted")]
    public DateTime? SolanaCommitted { get; set; }

    /// <summary>
    /// Gets or Sets SolanaCommittedDuration
    /// </summary>
    [DataMember(Name="solanaCommittedDuration", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "solanaCommittedDuration")]
    public decimal? SolanaCommittedDuration { get; set; }

    /// <summary>
    /// Gets or Sets SolanaFinalized
    /// </summary>
    [DataMember(Name="solanaFinalized", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "solanaFinalized")]
    public DateTime? SolanaFinalized { get; set; }

    /// <summary>
    /// Gets or Sets SolanaFinalizedDuration
    /// </summary>
    [DataMember(Name="solanaFinalizedDuration", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "solanaFinalizedDuration")]
    public decimal? SolanaFinalizedDuration { get; set; }

    /// <summary>
    /// Gets or Sets SolanaStart
    /// </summary>
    [DataMember(Name="solanaStart", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "solanaStart")]
    public DateTime? SolanaStart { get; set; }

    /// <summary>
    /// Gets or Sets SolanaTransaction
    /// </summary>
    [DataMember(Name="solanaTransaction", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "solanaTransaction")]
    public Object SolanaTransaction { get; set; }

    /// <summary>
    /// Gets or Sets Source
    /// </summary>
    [DataMember(Name="source", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "source")]
    public string Source { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or Sets TotalDuration
    /// </summary>
    [DataMember(Name="totalDuration", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalDuration")]
    public decimal? TotalDuration { get; set; }

    /// <summary>
    /// Gets or Sets WebhookEventStart
    /// </summary>
    [DataMember(Name="webhookEventStart", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webhookEventStart")]
    public DateTime? WebhookEventStart { get; set; }

    /// <summary>
    /// Gets or Sets WebhookEventEnd
    /// </summary>
    [DataMember(Name="webhookEventEnd", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webhookEventEnd")]
    public DateTime? WebhookEventEnd { get; set; }

    /// <summary>
    /// Gets or Sets WebhookEventDuration
    /// </summary>
    [DataMember(Name="webhookEventDuration", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webhookEventDuration")]
    public decimal? WebhookEventDuration { get; set; }

    /// <summary>
    /// Gets or Sets WebhookVerifyStart
    /// </summary>
    [DataMember(Name="webhookVerifyStart", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webhookVerifyStart")]
    public DateTime? WebhookVerifyStart { get; set; }

    /// <summary>
    /// Gets or Sets WebhookVerifyEnd
    /// </summary>
    [DataMember(Name="webhookVerifyEnd", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webhookVerifyEnd")]
    public DateTime? WebhookVerifyEnd { get; set; }

    /// <summary>
    /// Gets or Sets WebhookVerifyDuration
    /// </summary>
    [DataMember(Name="webhookVerifyDuration", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webhookVerifyDuration")]
    public decimal? WebhookVerifyDuration { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AppTransaction {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
      sb.Append("  Destination: ").Append(Destination).Append("\n");
      sb.Append("  Errors: ").Append(Errors).Append("\n");
      sb.Append("  ExplorerUrl: ").Append(ExplorerUrl).Append("\n");
      sb.Append("  FeePayer: ").Append(FeePayer).Append("\n");
      sb.Append("  Mint: ").Append(Mint).Append("\n");
      sb.Append("  ProcessingDuration: ").Append(ProcessingDuration).Append("\n");
      sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
      sb.Append("  ReferenceType: ").Append(ReferenceType).Append("\n");
      sb.Append("  Signature: ").Append(Signature).Append("\n");
      sb.Append("  SolanaCommitted: ").Append(SolanaCommitted).Append("\n");
      sb.Append("  SolanaCommittedDuration: ").Append(SolanaCommittedDuration).Append("\n");
      sb.Append("  SolanaFinalized: ").Append(SolanaFinalized).Append("\n");
      sb.Append("  SolanaFinalizedDuration: ").Append(SolanaFinalizedDuration).Append("\n");
      sb.Append("  SolanaStart: ").Append(SolanaStart).Append("\n");
      sb.Append("  SolanaTransaction: ").Append(SolanaTransaction).Append("\n");
      sb.Append("  Source: ").Append(Source).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  TotalDuration: ").Append(TotalDuration).Append("\n");
      sb.Append("  WebhookEventStart: ").Append(WebhookEventStart).Append("\n");
      sb.Append("  WebhookEventEnd: ").Append(WebhookEventEnd).Append("\n");
      sb.Append("  WebhookEventDuration: ").Append(WebhookEventDuration).Append("\n");
      sb.Append("  WebhookVerifyStart: ").Append(WebhookVerifyStart).Append("\n");
      sb.Append("  WebhookVerifyEnd: ").Append(WebhookVerifyEnd).Append("\n");
      sb.Append("  WebhookVerifyDuration: ").Append(WebhookVerifyDuration).Append("\n");
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
