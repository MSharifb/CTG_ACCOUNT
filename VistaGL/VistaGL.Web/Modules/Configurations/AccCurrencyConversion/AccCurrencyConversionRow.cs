using VistaGL.Modules.Common;

namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), DisplayName("Currency Information"), InstanceName("Currency Information"), TwoLevelCached]
    [ReadPermission("Configurations:AccCurrencyConversion:Read")]
    [InsertPermission("Configurations:AccCurrencyConversion:Insert")]
    [UpdatePermission("Configurations:AccCurrencyConversion:Update")]
    [DeletePermission("Configurations:AccCurrencyConversion:Delete")]
    [LookupScript("Configurations.AccCurrencyConversion",  Permission = "?")]
    public sealed class AccCurrencyConversionRow : NRow, IIdRow, INameRow, IAuditLog
    {
            #region Id
            [DisplayName("Id"), Column("id"), Identity]
            public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
            public partial class RowFields { public Int32Field Id; }
            #endregion Id

            #region Currency
            [DisplayName("Currency"), Column("currency"), Size(100), NotNull, QuickSearch]
            public String Currency { get { return Fields.Currency[this]; } set { Fields.Currency[this] = value; } }
            public partial class RowFields { public StringField Currency; }
            #endregion Currency

            #region Remarks
            [DisplayName("Remarks"), Column("remarks"), Size(500)]
            public String Remarks { get { return Fields.Remarks[this]; } set { Fields.Remarks[this] = value; } }
            public partial class RowFields { public StringField Remarks; }
            #endregion Remarks

            #region Symbol
            [DisplayName("Symbol"), Column("symbol"), Size(10),NotNull]
            public String Symbol { get { return Fields.Symbol[this]; } set { Fields.Symbol[this] = value; } }
            public partial class RowFields { public StringField Symbol; }
            #endregion Symbol


    #region Foreign Fields

    #endregion Foreign Fields

    #region Id and Name fields
    IIdField IIdRow.IdField
    {
    get { return Fields.Id; }
    }

            StringField INameRow.NameField
            {
            get { return Fields.Currency; }
            }
            #endregion Id and Name fields

    #region Constructor
    public AccCurrencyConversionRow()
    : base(Fields)
    {
    }
    #endregion Constructor

    #region RowFields
    public static readonly RowFields Fields = new RowFields().Init();

    public partial class RowFields : NRowFields
    {
    public RowFields()
    : base("[dbo].[acc_currency_conversion]")
    {
    LocalTextPrefix = "Configurations.AccCurrencyConversion";
    }
    }
    #endregion RowFields
    }
    }
