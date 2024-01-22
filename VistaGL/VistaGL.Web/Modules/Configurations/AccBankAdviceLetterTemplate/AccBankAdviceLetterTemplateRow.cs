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

    [ConnectionKey("ACCDB"), DisplayName("Bank Advice Letter Template"), InstanceName("Bank Advice Letter Template"), TwoLevelCached]
    [ReadPermission("Configurations:AccBankAdviceLetterTemplate:Read")]
    [InsertPermission("Configurations:AccBankAdviceLetterTemplate:Insert")]
    [UpdatePermission("Configurations:AccBankAdviceLetterTemplate:Update")]
    [DeletePermission("Configurations:AccBankAdviceLetterTemplate:Delete")]
    [LookupScript("Configurations.AccBankAdviceLetterTemplate", Permission = "?")]
    public sealed class AccBankAdviceLetterTemplateRow : NRow, IIdRow, INameRow, IAuditLog
    {
            #region Id
            [DisplayName("Id"), Identity]
            public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
            public partial class RowFields { public Int32Field Id; }
            #endregion Id

            #region Subject
            [DisplayName("Subject"), Size(500), QuickSearch]
            public String Subject { get { return Fields.Subject[this]; } set { Fields.Subject[this] = value; } }
            public partial class RowFields { public StringField Subject; }
            #endregion Subject

            #region Body1
            [DisplayName("Body1"), Size(2000)]
            public String Body1 { get { return Fields.Body1[this]; } set { Fields.Body1[this] = value; } }
            public partial class RowFields { public StringField Body1; }
            #endregion Body1

            #region Body2
            [DisplayName("Body2"), Size(2000)]
            public String Body2 { get { return Fields.Body2[this]; } set { Fields.Body2[this] = value; } }
            public partial class RowFields { public StringField Body2; }
            #endregion Body2


    #region Foreign Fields

    #endregion Foreign Fields

    #region Id and Name fields
    IIdField IIdRow.IdField
    {
    get { return Fields.Id; }
    }

            StringField INameRow.NameField
            {
            get { return Fields.Subject; }
            }
            #endregion Id and Name fields

    #region Constructor
    public AccBankAdviceLetterTemplateRow()
    : base(Fields)
    {
    }
    #endregion Constructor

    #region RowFields
    public static readonly RowFields Fields = new RowFields().Init();

    public const string TableName = "[dbo].[acc_BankAdviceLetterTemplate]";

    public partial class RowFields : NRowFields
    {
    public RowFields()
    : base("[dbo].[acc_BankAdviceLetterTemplate]")
    {
    LocalTextPrefix = "Configurations.AccBankAdviceLetterTemplate";
    }
    }
    #endregion RowFields
    }
    }
