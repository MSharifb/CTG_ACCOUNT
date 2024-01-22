using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Voucher Api Config."), InstanceName("Voucher Api Config."), TwoLevelCached]
    [ReadPermission("Configurations:AccVoucherApiConfig:Read")]
    [InsertPermission("Configurations:AccVoucherApiConfig:Insert")]
    [UpdatePermission("Configurations:AccVoucherApiConfig:Update")]
    [DeletePermission("Configurations:AccVoucherApiConfig:Delete")]
    [LookupScript("Configurations.AccVoucherApiConfig")]
    public sealed class AccVoucherApiConfigRow : Row, IIdRow, INameRow, IAuditLog
    {
            #region Id
            [DisplayName("Id"), Identity]
            public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
            public partial class RowFields { public Int32Field Id; }
            #endregion Id

            #region Config Name
            [DisplayName("Config Name"), Size(200), QuickSearch]
            public String ConfigName { get { return Fields.ConfigName[this]; } set { Fields.ConfigName[this] = value; } }
            public partial class RowFields { public StringField ConfigName; }
            #endregion ConfigName

            #region Module Id
            [DisplayName("Module Id"), Size(100)]
            public String ModuleId { get { return Fields.ModuleId[this]; } set { Fields.ModuleId[this] = value; } }
            public partial class RowFields { public StringField ModuleId; }
            #endregion ModuleId

            #region Form Name
            [DisplayName("Form Name"), Size(100)]
            public String FormName { get { return Fields.FormName[this]; } set { Fields.FormName[this] = value; } }
            public partial class RowFields { public StringField FormName; }
            #endregion FormName

            #region Vouchr Type
            [DisplayName("Vouchr Type"), ForeignKey("[dbo].[acc_voucher_type]", "id"), LeftJoin("jVouchrType"), TextualField("VouchrTypeName")]
            [LookupEditor(typeof(Configurations.Entities.AccVoucherTypeRow))]
            public Int32? VouchrTypeId { get { return Fields.VouchrTypeId[this]; } set { Fields.VouchrTypeId[this] = value; } }
            public partial class RowFields { public Int32Field VouchrTypeId; }
            #endregion VouchrTypeId

            #region Transaction
            [DisplayName("Transaction"), ForeignKey("[dbo].[acc_transaction_type]", "id"), LeftJoin("jTransaction"), TextualField("TransactionRemarks")]
            [LookupEditor(typeof(Configurations.Entities.AccTransactionTypeRow))]
            public Int32? TransactionId { get { return Fields.TransactionId[this]; } set { Fields.TransactionId[this] = value; } }
            public partial class RowFields { public Int32Field TransactionId; }
            #endregion TransactionId

            #region Transaction Mode
            [DisplayName("Transaction Mode"), Size(50)]
            public String TransactionMode { get { return Fields.TransactionMode[this]; } set { Fields.TransactionMode[this] = value; } }
            public partial class RowFields { public StringField TransactionMode; }
            #endregion TransactionMode

            #region Narration
            [DisplayName("Narration"), Size(500)]
            public String Narration { get { return Fields.Narration[this]; } set { Fields.Narration[this] = value; } }
            public partial class RowFields { public StringField Narration; }
            #endregion Narration

            #region Fund Control
            [DisplayName("Fund Control"), ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControl"), TextualField("FundControlCode")]
            [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
            public Int32? FundControlId { get { return Fields.FundControlId[this]; } set { Fields.FundControlId[this] = value; } }
            public partial class RowFields { public Int32Field FundControlId; }
            #endregion FundControlId

            #region Zone Info
            [Column("ZoneInfoId"), ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
            public Int32? ZoneInfoId { get { return Fields.ZoneInfoId[this]; } set { Fields.ZoneInfoId[this] = value; } }
            public partial class RowFields { public Int32Field ZoneInfoId; }
            #endregion ZoneInfoId


        #region VoucherApiConfigDetails
        [DisplayName("Voucher Api Config. Details"), MasterDetailRelation(foreignKey: "ConfigId"), NotMapped]
        public List<AccVoucherApiConfigDetailsRow> VoucherApiConfigDetails
        {
            get { return Fields.VoucherApiConfigDetails[this]; }
            set { Fields.VoucherApiConfigDetails[this] = value; }
        }
        public partial class RowFields { public RowListField<AccVoucherApiConfigDetailsRow> VoucherApiConfigDetails; }
        #endregion

    #region Foreign Fields

                [DisplayName("Vouchr Type"), Expression("jVouchrType.[name]")]
                public String VouchrTypeName { get { return Fields.VouchrTypeName[this]; } set { Fields.VouchrTypeName[this] = value; } }
                public partial class RowFields { public StringField VouchrTypeName; }


                [DisplayName("Vouchr Type Sort Order"), Expression("jVouchrType.[sortOrder]")]
                public Int32? VouchrTypeSortOrder { get { return Fields.VouchrTypeSortOrder[this]; } set { Fields.VouchrTypeSortOrder[this] = value; } }
                public partial class RowFields { public Int32Field VouchrTypeSortOrder; }


                [DisplayName("Transaction Remarks"), Expression("jTransaction.[remarks]")]
                public String TransactionRemarks { get { return Fields.TransactionRemarks[this]; } set { Fields.TransactionRemarks[this] = value; } }
                public partial class RowFields { public StringField TransactionRemarks; }


                [DisplayName("Transaction Sort Order"), Expression("jTransaction.[sortOrder]")]
                public Int32? TransactionSortOrder { get { return Fields.TransactionSortOrder[this]; } set { Fields.TransactionSortOrder[this] = value; } }
                public partial class RowFields { public Int32Field TransactionSortOrder; }


                [DisplayName("Transaction Type"), Expression("jTransaction.[transactionType]")]
                public String TransactionTransactionType { get { return Fields.TransactionTransactionType[this]; } set { Fields.TransactionTransactionType[this] = value; } }
                public partial class RowFields { public StringField TransactionTransactionType; }


                [DisplayName("Transaction Fund Control Id"), Expression("jTransaction.[fundControlId]")]
                public Int32? TransactionFundControlId { get { return Fields.TransactionFundControlId[this]; } set { Fields.TransactionFundControlId[this] = value; } }
                public partial class RowFields { public Int32Field TransactionFundControlId; }


                [DisplayName("Transaction Voucher Type Id"), Expression("jTransaction.[voucherTypeId]")]
                public Int32? TransactionVoucherTypeId { get { return Fields.TransactionVoucherTypeId[this]; } set { Fields.TransactionVoucherTypeId[this] = value; } }
                public partial class RowFields { public Int32Field TransactionVoucherTypeId; }


                [DisplayName("Transaction Transaction Mode"), Expression("jTransaction.[transactionMode]")]
                public String TransactionTransactionMode { get { return Fields.TransactionTransactionMode[this]; } set { Fields.TransactionTransactionMode[this] = value; } }
                public partial class RowFields { public StringField TransactionTransactionMode; }


                [DisplayName("Fund Control Code"), Expression("jFundControl.[code]")]
                public String FundControlCode { get { return Fields.FundControlCode[this]; } set { Fields.FundControlCode[this] = value; } }
                public partial class RowFields { public StringField FundControlCode; }


                [DisplayName("Fund Control"), Expression("jFundControl.[fundControlName]")]
                public String FundControlFundControlName { get { return Fields.FundControlFundControlName[this]; } set { Fields.FundControlFundControlName[this] = value; } }
                public partial class RowFields { public StringField FundControlFundControlName; }


                [DisplayName("Fund Control Booking Date"), Expression("jFundControl.[bookingDate]")]
                public DateTime? FundControlBookingDate { get { return Fields.FundControlBookingDate[this]; } set { Fields.FundControlBookingDate[this] = value; } }
                public partial class RowFields { public DateTimeField FundControlBookingDate; }


                [DisplayName("Fund Control Currency Id"), Expression("jFundControl.[currencyId]")]
                public Int32? FundControlCurrencyId { get { return Fields.FundControlCurrencyId[this]; } set { Fields.FundControlCurrencyId[this] = value; } }
                public partial class RowFields { public Int32Field FundControlCurrencyId; }


                [DisplayName("Fund Control Address"), Expression("jFundControl.[address]")]
                public String FundControlAddress { get { return Fields.FundControlAddress[this]; } set { Fields.FundControlAddress[this] = value; } }
                public partial class RowFields { public StringField FundControlAddress; }


                [DisplayName("Fund Control Phone"), Expression("jFundControl.[phone]")]
                public String FundControlPhone { get { return Fields.FundControlPhone[this]; } set { Fields.FundControlPhone[this] = value; } }
                public partial class RowFields { public StringField FundControlPhone; }


                [DisplayName("Fund Control Mobile"), Expression("jFundControl.[mobile]")]
                public String FundControlMobile { get { return Fields.FundControlMobile[this]; } set { Fields.FundControlMobile[this] = value; } }
                public partial class RowFields { public StringField FundControlMobile; }


                [DisplayName("Fund Control Fax"), Expression("jFundControl.[fax]")]
                public String FundControlFax { get { return Fields.FundControlFax[this]; } set { Fields.FundControlFax[this] = value; } }
                public partial class RowFields { public StringField FundControlFax; }


                [DisplayName("Fund Control Email"), Expression("jFundControl.[email]")]
                public String FundControlEmail { get { return Fields.FundControlEmail[this]; } set { Fields.FundControlEmail[this] = value; } }
                public partial class RowFields { public StringField FundControlEmail; }


                [DisplayName("Fund Control Web Url"), Expression("jFundControl.[webUrl]")]
                public String FundControlWebUrl { get { return Fields.FundControlWebUrl[this]; } set { Fields.FundControlWebUrl[this] = value; } }
                public partial class RowFields { public StringField FundControlWebUrl; }


                [DisplayName("Fund Control Remarks"), Expression("jFundControl.[remarks]")]
                public String FundControlRemarks { get { return Fields.FundControlRemarks[this]; } set { Fields.FundControlRemarks[this] = value; } }
                public partial class RowFields { public StringField FundControlRemarks; }


                [DisplayName("Fund Control Zone Info Id"), Expression("jFundControl.[ZoneInfoId]")]
                public Int32? FundControlZoneInfoId { get { return Fields.FundControlZoneInfoId[this]; } set { Fields.FundControlZoneInfoId[this] = value; } }
                public partial class RowFields { public Int32Field FundControlZoneInfoId; }


    #endregion Foreign Fields

    #region Id and Name fields
    IIdField IIdRow.IdField
    {
    get { return Fields.Id; }
    }

            StringField INameRow.NameField
            {
            get { return Fields.ConfigName; }
            }
            #endregion Id and Name fields

    #region Constructor
    public AccVoucherApiConfigRow()
    : base(Fields)
    {
    }
    #endregion Constructor

    #region RowFields
    public static readonly RowFields Fields = new RowFields().Init();

    public partial class RowFields : RowFieldsBase
    {
    public RowFields()
    : base("[dbo].[acc_VoucherAPIConfig]")
    {
    LocalTextPrefix = "Configurations.AccVoucherApiConfig";
    }
    }
    #endregion RowFields
    }
    }
