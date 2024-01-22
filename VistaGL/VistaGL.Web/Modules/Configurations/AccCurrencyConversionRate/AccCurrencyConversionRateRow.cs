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

    [ConnectionKey("ACCDB"), DisplayName("Currency Conversion Rate"), InstanceName("Currency Conversion Rate"), TwoLevelCached]
    [ReadPermission("Configurations:AccCurrencyConversionRate:Read")]
    [InsertPermission("Configurations:AccCurrencyConversionRate:Insert")]
    [UpdatePermission("Configurations:AccCurrencyConversionRate:Update")]
    [DeletePermission("Configurations:AccCurrencyConversionRate:Delete")]
    [LookupScript("Configurations.AccCurrencyConversionRate", Permission ="?")]
    public sealed class AccCurrencyConversionRateRow : NRow, IIdRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Column("id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region First Currency
        [DisplayName("First Currency"), Column("firstCurrency"), NotNull, ForeignKey("[dbo].[acc_currency_conversion]", "id"), LeftJoin("jFirstCurrency"), TextualField("FirstCurrencyCurrency")]
        [LookupEditor(typeof(Configurations.Entities.AccCurrencyConversionRow)), LookupInclude]
        public Int32? FirstCurrency { get { return Fields.FirstCurrency[this]; } set { Fields.FirstCurrency[this] = value; } }
        public partial class RowFields { public Int32Field FirstCurrency; }
        #endregion FirstCurrency

        #region Second Currency
        [DisplayName("Second Currency"), Column("secondCurrency"), NotNull, ForeignKey("[dbo].[acc_currency_conversion]", "id"), LeftJoin("jSecondCurrency"), TextualField("SecondCurrencyCurrency")]
        [LookupEditor(typeof(Configurations.Entities.AccCurrencyConversionRow)), LookupInclude]
        public Int32? SecondCurrency { get { return Fields.SecondCurrency[this]; } set { Fields.SecondCurrency[this] = value; } }
        public partial class RowFields { public Int32Field SecondCurrency; }
        #endregion SecondCurrency

        #region First Amount
        [DisplayName("First Amount"), Column("firstAmout"),NotNull, Size(18), Scale(2), LookupInclude]
        public Decimal? FirstAmout { get { return Fields.FirstAmout[this]; } set { Fields.FirstAmout[this] = value; } }
        public partial class RowFields { public DecimalField FirstAmout; }
        #endregion FirstAmout

        #region Second Amount
        [DisplayName("Second Amount"), Column("secondAmout"), NotNull, Size(18), Scale(2), LookupInclude]
        public Decimal? SecondAmout { get { return Fields.SecondAmout[this]; } set { Fields.SecondAmout[this] = value; } }
        public partial class RowFields { public DecimalField SecondAmout; }
        #endregion SecondAmout


        #region Foreign Fields

        [DisplayName("First Currency"), Expression("jFirstCurrency.[currency]")]
        public String FirstCurrencyCurrency { get { return Fields.FirstCurrencyCurrency[this]; } set { Fields.FirstCurrencyCurrency[this] = value; } }
        public partial class RowFields { public StringField FirstCurrencyCurrency; }


        [DisplayName("First Currency Remarks"), Expression("jFirstCurrency.[remarks]")]
        public String FirstCurrencyRemarks { get { return Fields.FirstCurrencyRemarks[this]; } set { Fields.FirstCurrencyRemarks[this] = value; } }
        public partial class RowFields { public StringField FirstCurrencyRemarks; }


        [DisplayName("First Currency Symbol"), Expression("jFirstCurrency.[symbol]")]
        public String FirstCurrencySymbol { get { return Fields.FirstCurrencySymbol[this]; } set { Fields.FirstCurrencySymbol[this] = value; } }
        public partial class RowFields { public StringField FirstCurrencySymbol; }


        [DisplayName("Second Currency"), Expression("jSecondCurrency.[currency]"), LookupInclude]
        // [MinSelectLevel(SelectLevel.Always)]
        public String SecondCurrencyCurrency { get { return Fields.SecondCurrencyCurrency[this]; } set { Fields.SecondCurrencyCurrency[this] = value; } }
        public partial class RowFields { public StringField SecondCurrencyCurrency; }


        [DisplayName("Second Currency Remarks"), Expression("jSecondCurrency.[remarks]")]
        public String SecondCurrencyRemarks { get { return Fields.SecondCurrencyRemarks[this]; } set { Fields.SecondCurrencyRemarks[this] = value; } }
        public partial class RowFields { public StringField SecondCurrencyRemarks; }


        [DisplayName("Second Currency Symbol"), Expression("jSecondCurrency.[symbol]")]
        public String SecondCurrencySymbol { get { return Fields.SecondCurrencySymbol[this]; } set { Fields.SecondCurrencySymbol[this] = value; } }
        public partial class RowFields { public StringField SecondCurrencySymbol; }


        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }
        #endregion Id and Name fields

        #region Constructor
        public AccCurrencyConversionRateRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : NRowFields
        {
            public RowFields()
            : base("[dbo].[acc_currency_conversion_rate]")
            {
                LocalTextPrefix = "Configurations.AccCurrencyConversionRate";
            }
        }
        #endregion RowFields
    }
}
