﻿
namespace VistaGL.Administration
{
    using VistaGL.Administration.Entities;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Web;

    [LookupScript("Administration.Language", Permission = "?")]
    public sealed class LanguageLookup : RowLookupScript<LanguageRow>
    {
        public LanguageLookup()
        {
            IdField = LanguageRow.Fields.LanguageId.PropertyName;
            Permission = "*";
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);

            query.Select(LanguageRow.Fields.LanguageId);
        }
    }
}