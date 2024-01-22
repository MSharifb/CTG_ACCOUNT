
namespace VistaGL.Transaction.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Transaction"), TableName("[dbo].[acc_ibcs_jsondata_history]")]
    [DisplayName("IBCS Voucher Data History"), InstanceName("Acc Ibcs Jsondata History")]
    [ReadPermission("Transaction:AccIbcsJsondataHistory:Read")]
    [LookupScript("Transaction.AccIbcsJsondataHistoryRow", Permission = "?", Expiration = -1)]
    public sealed class AccIbcsJsondataHistoryRow : Row, IIdRow, INameRow
    {

        [DisplayName("Id"), Identity]
        public Int64? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Voucher No"), Size(100), QuickSearch]
        public String VoucherNo
        {
            get { return Fields.VoucherNo[this]; }
            set { Fields.VoucherNo[this] = value; }
        }

        [DisplayName("Voucher Date")]
        public DateTime? VoucherDate
        {
            get { return Fields.VoucherDate[this]; }
            set { Fields.VoucherDate[this] = value; }
        }

        [DisplayName("Zone Info"), ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName")]
        [LookupEditor(typeof(Configurations.Entities.PrmZoneInfoRow))]
        public Int32? ZoneId
        {
            get { return Fields.ZoneId[this]; }
            set { Fields.ZoneId[this] = value; }
        }

        [DisplayName("Zone Name"), Expression("jZoneInfo.[ZoneName]"), LookupInclude]
        public String ZoneInfoZoneName
        {
            get { return Fields.ZoneInfoZoneName[this]; }
            set { Fields.ZoneInfoZoneName[this] = value; }
        }


        [DisplayName("Entity"), ForeignKey("[dbo].[acc_FundControlInformation]", "Id"), LeftJoin("jFundControl"), TextualField("EntiryName")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        public Int32? FundControlId
        {
            get { return Fields.FundControlId[this]; }
            set { Fields.FundControlId[this] = value; }
        }

        [DisplayName("Entity Name"), Expression("jFundControl.[FundControlName]"), LookupInclude]
        public String EntityName
        {
            get { return Fields.EntityName[this]; }
            set { Fields.EntityName[this] = value; }
        }

        [DisplayName("Json Data"), Column("JSONData")]
        public String JsonData
        {
            get { return Fields.JsonData[this]; }
            set { Fields.JsonData[this] = value; }
        }

        [DisplayName("Create Date")]
        public DateTime? CreateDate
        {
            get { return Fields.CreateDate[this]; }
            set { Fields.CreateDate[this] = value; }
        }

        [DisplayName("Is Success"), NotNull]
        public Boolean? IsSuccess
        {
            get { return Fields.IsSuccess[this]; }
            set { Fields.IsSuccess[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.VoucherNo; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccIbcsJsondataHistoryRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int64Field Id;

            public StringField VoucherNo;

            public DateTimeField VoucherDate;

            public Int32Field ZoneId;

            public Int32Field FundControlId;

            public StringField JsonData;

            public DateTimeField CreateDate;

            public BooleanField IsSuccess;

            public StringField ZoneInfoZoneName;

            public StringField EntityName;

        }
    }
}
