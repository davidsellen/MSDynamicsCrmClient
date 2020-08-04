using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Microsoft.Dynamics.CrmClient
{

    public class SearchResult : Odata<Dictionary<string, object>>
    {
        [JsonProperty("@Microsoft.Dynamics.CRM.totalrecordcount")]
        public int TotalRecordCount { get; set; }
        [JsonProperty("@Microsoft.Dynamics.CRM.totalrecordcountlimitexceeded")]
        public bool TotalRecordCountLimitExceeded { get; set; }
    }


    public class Odata<T>
    {
        [JsonProperty("@odata.context")]
        public Uri OdataContext { get; set; }

        [JsonProperty("value")]
        public T[] Entries { get; set; }
    }

    public class EntityMetadata
    {
        [JsonProperty("@odata.context")]
        public Uri OdataContext { get; set; }

        [JsonProperty("ActivityTypeMask")]
        public long ActivityTypeMask { get; set; }

        [JsonProperty("AutoRouteToOwnerQueue")]
        public bool AutoRouteToOwnerQueue { get; set; }

        [JsonProperty("CanTriggerWorkflow")]
        public bool CanTriggerWorkflow { get; set; }

        [JsonProperty("EntityHelpUrlEnabled")]
        public bool EntityHelpUrlEnabled { get; set; }

        [JsonProperty("EntityHelpUrl")]
        public object EntityHelpUrl { get; set; }

        [JsonProperty("IsDocumentManagementEnabled")]
        public bool IsDocumentManagementEnabled { get; set; }

        [JsonProperty("IsOneNoteIntegrationEnabled")]
        public bool IsOneNoteIntegrationEnabled { get; set; }

        [JsonProperty("IsInteractionCentricEnabled")]
        public bool IsInteractionCentricEnabled { get; set; }

        [JsonProperty("IsKnowledgeManagementEnabled")]
        public bool IsKnowledgeManagementEnabled { get; set; }

        [JsonProperty("IsSLAEnabled")]
        public bool IsSlaEnabled { get; set; }

        [JsonProperty("IsBPFEntity")]
        public bool IsBpfEntity { get; set; }

        [JsonProperty("IsDocumentRecommendationsEnabled")]
        public bool IsDocumentRecommendationsEnabled { get; set; }

        [JsonProperty("IsMSTeamsIntegrationEnabled")]
        public bool IsMsTeamsIntegrationEnabled { get; set; }

        [JsonProperty("SettingOf")]
        public object SettingOf { get; set; }

        [JsonProperty("DataProviderId")]
        public object DataProviderId { get; set; }

        [JsonProperty("DataSourceId")]
        public object DataSourceId { get; set; }

        [JsonProperty("AutoCreateAccessTeams")]
        public bool AutoCreateAccessTeams { get; set; }

        [JsonProperty("IsActivity")]
        public bool IsActivity { get; set; }

        [JsonProperty("IsActivityParty")]
        public bool IsActivityParty { get; set; }

        [JsonProperty("IsAvailableOffline")]
        public bool IsAvailableOffline { get; set; }

        [JsonProperty("IsChildEntity")]
        public bool IsChildEntity { get; set; }

        [JsonProperty("IsAIRUpdated")]
        public bool IsAirUpdated { get; set; }

        [JsonProperty("IconLargeName")]
        public object IconLargeName { get; set; }

        [JsonProperty("IconMediumName")]
        public object IconMediumName { get; set; }

        [JsonProperty("IconSmallName")]
        public object IconSmallName { get; set; }

        [JsonProperty("IconVectorName")]
        public object IconVectorName { get; set; }

        [JsonProperty("IsCustomEntity")]
        public bool IsCustomEntity { get; set; }

        [JsonProperty("IsBusinessProcessEnabled")]
        public bool IsBusinessProcessEnabled { get; set; }

        [JsonProperty("SyncToExternalSearchIndex")]
        public bool SyncToExternalSearchIndex { get; set; }

        [JsonProperty("IsOptimisticConcurrencyEnabled")]
        public bool IsOptimisticConcurrencyEnabled { get; set; }

        [JsonProperty("ChangeTrackingEnabled")]
        public bool ChangeTrackingEnabled { get; set; }

        [JsonProperty("IsImportable")]
        public bool IsImportable { get; set; }

        [JsonProperty("IsIntersect")]
        public bool IsIntersect { get; set; }

        [JsonProperty("IsManaged")]
        public bool IsManaged { get; set; }

        [JsonProperty("IsEnabledForCharts")]
        public bool IsEnabledForCharts { get; set; }

        [JsonProperty("IsEnabledForTrace")]
        public bool IsEnabledForTrace { get; set; }

        [JsonProperty("IsValidForAdvancedFind")]
        public bool IsValidForAdvancedFind { get; set; }

        [JsonProperty("DaysSinceRecordLastModified")]
        public long DaysSinceRecordLastModified { get; set; }

        [JsonProperty("MobileOfflineFilters")]
        public string MobileOfflineFilters { get; set; }

        [JsonProperty("IsReadingPaneEnabled")]
        public bool IsReadingPaneEnabled { get; set; }

        [JsonProperty("IsQuickCreateEnabled")]
        public bool IsQuickCreateEnabled { get; set; }

        [JsonProperty("LogicalName")]
        public string LogicalName { get; set; }

        [JsonProperty("ObjectTypeCode")]
        public long ObjectTypeCode { get; set; }

        [JsonProperty("OwnershipType")]
        public string OwnershipType { get; set; }

        [JsonProperty("PrimaryNameAttribute")]
        public string PrimaryNameAttribute { get; set; }

        [JsonProperty("PrimaryImageAttribute")]
        public object PrimaryImageAttribute { get; set; }

        [JsonProperty("PrimaryIdAttribute")]
        public string PrimaryIdAttribute { get; set; }

        [JsonProperty("RecurrenceBaseEntityLogicalName")]
        public object RecurrenceBaseEntityLogicalName { get; set; }

        [JsonProperty("ReportViewName")]
        public string ReportViewName { get; set; }

        [JsonProperty("SchemaName")]
        public string SchemaName { get; set; }

        [JsonProperty("IntroducedVersion")]
        public string IntroducedVersion { get; set; }

        [JsonProperty("IsStateModelAware")]
        public bool IsStateModelAware { get; set; }

        [JsonProperty("EnforceStateTransitions")]
        public bool EnforceStateTransitions { get; set; }

        [JsonProperty("ExternalName")]
        public object ExternalName { get; set; }

        [JsonProperty("EntityColor")]
        public string EntityColor { get; set; }

        [JsonProperty("LogicalCollectionName")]
        public string LogicalCollectionName { get; set; }

        [JsonProperty("ExternalCollectionName")]
        public object ExternalCollectionName { get; set; }

        [JsonProperty("CollectionSchemaName")]
        public string CollectionSchemaName { get; set; }

        [JsonProperty("EntitySetName")]
        public string EntitySetName { get; set; }

        [JsonProperty("IsEnabledForExternalChannels")]
        public bool IsEnabledForExternalChannels { get; set; }

        [JsonProperty("IsPrivate")]
        public bool IsPrivate { get; set; }

        [JsonProperty("UsesBusinessDataLabelTable")]
        public bool UsesBusinessDataLabelTable { get; set; }

        [JsonProperty("IsLogicalEntity")]
        public bool IsLogicalEntity { get; set; }

        [JsonProperty("HasNotes")]
        public bool HasNotes { get; set; }

        [JsonProperty("HasActivities")]
        public bool HasActivities { get; set; }

        [JsonProperty("HasFeedback")]
        public bool HasFeedback { get; set; }

        [JsonProperty("IsSolutionAware")]
        public bool IsSolutionAware { get; set; }

        [JsonProperty("MetadataId")]
        public Guid MetadataId { get; set; }

        [JsonProperty("HasChanged")]
        public object HasChanged { get; set; }

        [JsonProperty("Description")]
        public Text Description { get; set; }

        [JsonProperty("DisplayCollectionName")]
        public Text DisplayCollectionName { get; set; }

        [JsonProperty("DisplayName")]
        public Text DisplayName { get; set; }

        [JsonProperty("IsAuditEnabled")]
        public ValueDefinition IsAuditEnabled { get; set; }

        [JsonProperty("IsValidForQueue")]
        public ValueDefinition IsValidForQueue { get; set; }

        [JsonProperty("IsConnectionsEnabled")]
        public ValueDefinition IsConnectionsEnabled { get; set; }

        [JsonProperty("IsCustomizable")]
        public ValueDefinition IsCustomizable { get; set; }

        [JsonProperty("IsRenameable")]
        public ValueDefinition IsRenameable { get; set; }

        [JsonProperty("IsMappable")]
        public ValueDefinition IsMappable { get; set; }

        [JsonProperty("IsDuplicateDetectionEnabled")]
        public ValueDefinition IsDuplicateDetectionEnabled { get; set; }

        [JsonProperty("CanCreateAttributes")]
        public ValueDefinition CanCreateAttributes { get; set; }

        [JsonProperty("CanCreateForms")]
        public ValueDefinition CanCreateForms { get; set; }

        [JsonProperty("CanCreateViews")]
        public ValueDefinition CanCreateViews { get; set; }

        [JsonProperty("CanCreateCharts")]
        public ValueDefinition CanCreateCharts { get; set; }

        [JsonProperty("CanBeRelatedEntityInRelationship")]
        public ValueDefinition CanBeRelatedEntityInRelationship { get; set; }

        [JsonProperty("CanBePrimaryEntityInRelationship")]
        public ValueDefinition CanBePrimaryEntityInRelationship { get; set; }

        [JsonProperty("CanBeInManyToMany")]
        public ValueDefinition CanBeInManyToMany { get; set; }

        [JsonProperty("CanBeInCustomEntityAssociation")]
        public ValueDefinition CanBeInCustomEntityAssociation { get; set; }

        [JsonProperty("CanEnableSyncToExternalSearchIndex")]
        public ValueDefinition CanEnableSyncToExternalSearchIndex { get; set; }

        [JsonProperty("CanModifyAdditionalSettings")]
        public ValueDefinition CanModifyAdditionalSettings { get; set; }

        [JsonProperty("CanChangeHierarchicalRelationship")]
        public ValueDefinition CanChangeHierarchicalRelationship { get; set; }

        [JsonProperty("CanChangeTrackingBeEnabled")]
        public ValueDefinition CanChangeTrackingBeEnabled { get; set; }

        [JsonProperty("IsMailMergeEnabled")]
        public ValueDefinition IsMailMergeEnabled { get; set; }

        [JsonProperty("IsVisibleInMobile")]
        public ValueDefinition IsVisibleInMobile { get; set; }

        [JsonProperty("IsVisibleInMobileClient")]
        public ValueDefinition IsVisibleInMobileClient { get; set; }

        [JsonProperty("IsReadOnlyInMobileClient")]
        public ValueDefinition IsReadOnlyInMobileClient { get; set; }

        [JsonProperty("IsOfflineInMobileClient")]
        public ValueDefinition IsOfflineInMobileClient { get; set; }

        [JsonProperty("Privileges")]
        public Privilege[] Privileges { get; set; }

        [JsonProperty("Settings")]
        public object[] Settings { get; set; }

    }
    public class EntityAttributes : Odata<PropertyDefinition>
    {

        public IEnumerable<PropertyDefinition> LookupFields
        {
            get
            {
                if (Entries != null)
                {
                    return Entries.Where(e => e.IsLookup);
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<PropertyDefinition> OptionSetFields
        {
            get
            {
                if (Entries != null)
                {
                    return Entries.Where(e => e.AttributeTypeName != null && e.AttributeTypeName.Value == "PicklistType");
                }
                else
                {
                    return null;
                }
            }
        }
        
    }

    public class Metadata : Odata<Entity>
    {

    }

    public class PickListDefinition : Odata<PickList>
    {

    }

    public class PickList
    {
        [JsonProperty("LogicalName")]
        public string LogicalName { get; set; }

        [JsonProperty("MetadataId")]
        public Guid MetadataId { get; set; }

        [JsonProperty("OptionSet")]
        public OptionSet OptionSet { get; set; }
    }

    public class OptionSet
    {
        [JsonProperty("MetadataId")]
        public Guid MetadataId { get; set; }

        [JsonProperty("HasChanged")]
        public object HasChanged { get; set; }

        [JsonProperty("IsCustomOptionSet")]
        public bool IsCustomOptionSet { get; set; }

        [JsonProperty("IsGlobal")]
        public bool IsGlobal { get; set; }

        [JsonProperty("IsManaged")]
        public bool IsManaged { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ExternalTypeName")]
        public object ExternalTypeName { get; set; }

        [JsonProperty("OptionSetType")]
        public string OptionSetType { get; set; }

        [JsonProperty("IntroducedVersion")]
        public string IntroducedVersion { get; set; }

        [JsonProperty("ParentOptionSetName")]
        public object ParentOptionSetName { get; set; }

        [JsonProperty("Description")]
        public Text Description { get; set; }

        [JsonProperty("DisplayName")]
        public Text DisplayName { get; set; }

        [JsonProperty("IsCustomizable")]
        public ValueDefinition IsCustomizable { get; set; }

        [JsonProperty("Options")]
        public Option[] Options { get; set; }
    }

    public class Option
    {
        [JsonProperty("Value")]
        public long Value { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("IsManaged")]
        public bool IsManaged { get; set; }

        [JsonProperty("ExternalValue")]
        public string ExternalValue { get; set; }

        [JsonProperty("ParentValues")]
        public object[] ParentValues { get; set; }

        [JsonProperty("MetadataId")]
        public object MetadataId { get; set; }

        [JsonProperty("HasChanged")]
        public object HasChanged { get; set; }

        [JsonProperty("Label")]
        public Text Label { get; set; }

        [JsonProperty("Description")]
        public Text Description { get; set; }
    }
    public class Entity
    {
        public string LogicalName { get; set; }
        public string LogicalCollectionName { get; set; }
        public string PrimaryIdAttribute { get; set; }
        public string PrimaryNameAttribute { get; set; }
        public Guid MetadataId { get; set; }
        public Text DisplayName { get; set; }
    }

    public class Text
    {
        public LocalizedLabel[] LocalizedLabels { get; set; }
        public LocalizedLabel UserLocalizedLabel { get; set; }
    }

    public class LocalizedLabel
    {
        public string Label { get; set; }
        public long LanguageCode { get; set; }
        public bool IsManaged { get; set; }
        public Guid MetadataId { get; set; }
        public object HasChanged { get; set; }
    }

    public class PropertyDefinition
    {
        [JsonProperty("@odata.type", NullValueHandling = NullValueHandling.Ignore)]
        public string OdataType { get; set; }

        [JsonProperty("Format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        [JsonProperty("ImeMode", NullValueHandling = NullValueHandling.Ignore)]
        public string ImeMode { get; set; }

        [JsonProperty("MaxLength", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxLength { get; set; }

        [JsonProperty("YomiOf")]
        public string YomiOf { get; set; }

        [JsonProperty("IsLocalizable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLocalizable { get; set; }

        [JsonProperty("DatabaseLength", NullValueHandling = NullValueHandling.Ignore)]
        public long? DatabaseLength { get; set; }

        [JsonProperty("FormulaDefinition", NullValueHandling = NullValueHandling.Ignore)]
        public string FormulaDefinition { get; set; }

        [JsonProperty("SourceTypeMask", NullValueHandling = NullValueHandling.Ignore)]
        public long? SourceTypeMask { get; set; }

        [JsonProperty("AttributeOf")]
        public string AttributeOf { get; set; }

        [JsonProperty("AttributeType")]
        public string AttributeType { get; set; }

        [JsonProperty("ColumnNumber")]
        public long ColumnNumber { get; set; }

        [JsonProperty("DeprecatedVersion")]
        public object DeprecatedVersion { get; set; }

        [JsonProperty("IntroducedVersion")]
        public string IntroducedVersion { get; set; }

        [JsonProperty("EntityLogicalName")]
        public string EntityLogicalName { get; set; }

        [JsonProperty("IsCustomAttribute")]
        public bool IsCustomAttribute { get; set; }

        [JsonProperty("IsPrimaryId")]
        public bool IsPrimaryId { get; set; }

        [JsonProperty("IsValidODataAttribute")]
        public bool IsValidODataAttribute { get; set; }

        [JsonProperty("IsPrimaryName")]
        public bool IsPrimaryName { get; set; }

        [JsonProperty("IsValidForCreate")]
        public bool IsValidForCreate { get; set; }

        [JsonProperty("IsValidForRead")]
        public bool IsValidForRead { get; set; }

        [JsonProperty("IsValidForUpdate")]
        public bool IsValidForUpdate { get; set; }

        [JsonProperty("CanBeSecuredForRead")]
        public bool CanBeSecuredForRead { get; set; }

        [JsonProperty("CanBeSecuredForCreate")]
        public bool CanBeSecuredForCreate { get; set; }

        [JsonProperty("CanBeSecuredForUpdate")]
        public bool CanBeSecuredForUpdate { get; set; }

        [JsonProperty("IsSecured")]
        public bool IsSecured { get; set; }

        [JsonProperty("IsRetrievable")]
        public bool IsRetrievable { get; set; }

        [JsonProperty("IsFilterable")]
        public bool IsFilterable { get; set; }

        [JsonProperty("IsSearchable")]
        public bool IsSearchable { get; set; }

        [JsonProperty("IsManaged")]
        public bool IsManaged { get; set; }

        [JsonProperty("LinkedAttributeId")]
        public object LinkedAttributeId { get; set; }

        [JsonProperty("LogicalName")]
        public string LogicalName { get; set; }

        [JsonProperty("IsValidForForm")]
        public bool IsValidForForm { get; set; }

        [JsonProperty("IsRequiredForForm")]
        public bool IsRequiredForForm { get; set; }

        [JsonProperty("IsValidForGrid")]
        public bool IsValidForGrid { get; set; }

        [JsonProperty("SchemaName")]
        public string SchemaName { get; set; }

        [JsonProperty("ExternalName")]
        public object ExternalName { get; set; }

        [JsonProperty("IsLogical")]
        public bool IsLogical { get; set; }

        [JsonProperty("IsDataSourceSecret")]
        public bool IsDataSourceSecret { get; set; }

        [JsonProperty("InheritsFrom")]
        public object InheritsFrom { get; set; }

        [JsonProperty("SourceType")]
        public long? SourceType { get; set; }

        [JsonProperty("AutoNumberFormat")]
        public object AutoNumberFormat { get; set; }

        [JsonProperty("MetadataId")]
        public Guid MetadataId { get; set; }

        [JsonProperty("HasChanged")]
        public object HasChanged { get; set; }

        [JsonProperty("FormatName", NullValueHandling = NullValueHandling.Ignore)]
        public AttributeTypeName FormatName { get; set; }

        [JsonProperty("AttributeTypeName")]
        public AttributeTypeName AttributeTypeName { get; set; }

        [JsonProperty("Description")]
        public Text Description { get; set; }

        [JsonProperty("DisplayName")]
        public Text DisplayName { get; set; }

        [JsonProperty("IsAuditEnabled")]
        public ValueDefinition IsAuditEnabled { get; set; }

        [JsonProperty("IsGlobalFilterEnabled")]
        public ValueDefinition IsGlobalFilterEnabled { get; set; }

        [JsonProperty("IsSortableEnabled")]
        public ValueDefinition IsSortableEnabled { get; set; }

        [JsonProperty("IsCustomizable")]
        public ValueDefinition IsCustomizable { get; set; }

        [JsonProperty("IsRenameable")]
        public ValueDefinition IsRenameable { get; set; }

        [JsonProperty("IsValidForAdvancedFind")]
        public ValueDefinition IsValidForAdvancedFind { get; set; }

        [JsonProperty("RequiredLevel")]
        public ValueDefinition RequiredLevel { get; set; }

        [JsonProperty("CanModifyAdditionalSettings")]
        public ValueDefinition CanModifyAdditionalSettings { get; set; }

        [JsonProperty("Targets", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Targets { get; set; }

        [JsonProperty("DefaultFormValue")]
        public long? DefaultFormValue { get; set; }

        [JsonProperty("MaxValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MaxValue { get; set; }

        [JsonProperty("MinValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MinValue { get; set; }

        [JsonProperty("ParentPicklistLogicalName")]
        public object ParentPicklistLogicalName { get; set; }

        [JsonProperty("ChildPicklistLogicalNames", NullValueHandling = NullValueHandling.Ignore)]
        public object[] ChildPicklistLogicalNames { get; set; }

        [JsonProperty("MinSupportedValue", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? MinSupportedValue { get; set; }

        [JsonProperty("MaxSupportedValue", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? MaxSupportedValue { get; set; }

        [JsonProperty("DateTimeBehavior", NullValueHandling = NullValueHandling.Ignore)]
        public AttributeTypeName DateTimeBehavior { get; set; }

        [JsonProperty("CanChangeDateTimeBehavior", NullValueHandling = NullValueHandling.Ignore)]
        public ValueDefinition CanChangeDateTimeBehavior { get; set; }

        [JsonProperty("IsEntityReferenceStored", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEntityReferenceStored { get; set; }

        public bool IsLookup
        {
            get
            {
                return AttributeTypeName != null && (AttributeTypeName.Value == "LookupType" || AttributeTypeName.Value == "OwnerType" || AttributeTypeName.Value == "PartyListType");
            }
        }
    }

    public partial class AttributeTypeName
    {
        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public class ValueDefinition
    {
        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("CanBeChanged")]
        public bool CanBeChanged { get; set; }

        [JsonProperty("ManagedPropertyLogicalName")]
        public string ManagedPropertyLogicalName { get; set; }
    }

    public class Privilege
    {
        [JsonProperty("CanBeBasic")]
        public bool CanBeBasic { get; set; }

        [JsonProperty("CanBeDeep")]
        public bool CanBeDeep { get; set; }

        [JsonProperty("CanBeGlobal")]
        public bool CanBeGlobal { get; set; }

        [JsonProperty("CanBeLocal")]
        public bool CanBeLocal { get; set; }

        [JsonProperty("CanBeEntityReference")]
        public bool CanBeEntityReference { get; set; }

        [JsonProperty("CanBeParentEntityReference")]
        public bool CanBeParentEntityReference { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PrivilegeId")]
        public Guid PrivilegeId { get; set; }

        [JsonProperty("PrivilegeType")]
        public string PrivilegeType { get; set; }
    }

    public class ServiceError
    {
        public ErrorInfo Error { get; set; }
    }

    public class ErrorInfo
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Innererror Innererror { get; set; }
    }

    public class Innererror
    {
        public string Message { get; set; }

        public string Type { get; set; }

        public string Stacktrace { get; set; }
    }

    [Serializable]
    public class EntityData : Dictionary<string, object>
    {
        public EntityData()
        {
        }

        public EntityData(IDictionary<string, object> dictionary) : base(dictionary)
        {
        }

        public void Ensure(string key, object data)
        {
            if (this.ContainsKey(key))
            {
                this[key] = data;
            }
            else
            {
                this.Add(key, data);
            }
        }
    }
}
