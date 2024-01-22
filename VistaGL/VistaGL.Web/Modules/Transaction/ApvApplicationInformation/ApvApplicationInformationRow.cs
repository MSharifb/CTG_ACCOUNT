
using System;
using System.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using VistaGL.Modules.Common;

namespace VistaGL.Transaction.Entities
{
    [ConnectionKey("ACCDB"), DisplayName("APV_ApplicationInformation"), InstanceName("APV_ApplicationInformation"), TwoLevelCached]
    //[ReadPermission("Transaction:APV_ApplicationInformation:Read")]
    //[InsertPermission("Transaction:APV_ApplicationInformation:Insert")]
    //[UpdatePermission("Transaction:APV_ApplicationInformation:Update")]
    //[DeletePermission("Transaction:APV_ApplicationInformation:Delete")]
    //[LookupScript("Transaction.ApvApplicationInformationRow")]
    public sealed class ApvApplicationInformationRow : Row, IIdRow, INameRow, IAuditLog
    {
        #region Id
        [DisplayName("Id"), Identity]
        public Int32? Id { get { return Fields.Id[this]; } set { Fields.Id[this] = value; } }
        public partial class RowFields { public Int32Field Id; }
        #endregion Id

        #region Module Id
        [DisplayName("Module Id")]
        public Int32? ModuleId { get { return Fields.ModuleId[this]; } set { Fields.ModuleId[this] = value; } }
        public partial class RowFields { public Int32Field ModuleId; }
        #endregion ModuleId

        #region Approval Process Id
        [DisplayName("Approval Process Id"), NotNull]
        public Int32? ApprovalProcessId { get { return Fields.ApprovalProcessId[this]; } set { Fields.ApprovalProcessId[this] = value; } }
        public partial class RowFields { public Int32Field ApprovalProcessId; }
        #endregion ApprovalProcessId

        #region Application Id
        [DisplayName("Application Id"), NotNull]
        public Int32? ApplicationId { get { return Fields.ApplicationId[this]; } set { Fields.ApplicationId[this] = value; } }
        public partial class RowFields { public Int32Field ApplicationId; }
        #endregion ApplicationId

        #region Is Online Application
        [DisplayName("Is Online Application")]
        public Boolean? IsOnlineApplication { get { return Fields.IsOnlineApplication[this]; } set { Fields.IsOnlineApplication[this] = value; } }
        public partial class RowFields { public BooleanField IsOnlineApplication; }
        #endregion IsOnlineApplication

        #region Approval Step Id
        [DisplayName("Approval Step Id"), NotNull]
        public Int32? ApprovalStepId { get { return Fields.ApprovalStepId[this]; } set { Fields.ApprovalStepId[this] = value; } }
        public partial class RowFields { public Int32Field ApprovalStepId; }
        #endregion ApprovalStepId

        #region Approver Id
        [DisplayName("Approver Id"), NotNull]
        [Column("ApproverId"), ForeignKey("[dbo].[PRM_EmploymentInfo]", "id"), LeftJoin("jEmploymentInfo"), TextualField("EmploymentInfoFullName")]

        public Int32? ApproverId { get { return Fields.ApproverId[this]; } set { Fields.ApproverId[this] = value; } }
        public partial class RowFields { public Int32Field ApproverId; }
        #endregion ApproverId

        #region Approval Status Id
        [DisplayName("Approval Status Id")]
        public Int32? ApprovalStatusId { get { return Fields.ApprovalStatusId[this]; } set { Fields.ApprovalStatusId[this] = value; } }
        public partial class RowFields { public Int32Field ApprovalStatusId; }
        #endregion ApprovalStatusId

        #region Approver Comments
        [DisplayName("Approver Comments"), QuickSearch]
        public String ApproverComments { get { return Fields.ApproverComments[this]; } set { Fields.ApproverComments[this] = value; } }
        public partial class RowFields { public StringField ApproverComments; }
        #endregion ApproverComments

        #region I User
        [DisplayName("I User"), Size(50), NotNull]
        public String IUser { get { return Fields.IUser[this]; } set { Fields.IUser[this] = value; } }
        public partial class RowFields { public StringField IUser; }
        #endregion IUser

        #region I Date
        [DisplayName("I Date"), NotNull]
        public DateTime? IDate { get { return Fields.IDate[this]; } set { Fields.IDate[this] = value; } }
        public partial class RowFields { public DateTimeField IDate; }
        #endregion IDate

        #region E User
        [DisplayName("E User"), Size(50)]
        public String EUser { get { return Fields.EUser[this]; } set { Fields.EUser[this] = value; } }
        public partial class RowFields { public StringField EUser; }
        #endregion EUser

        #region E Date
        [DisplayName("E Date")]
        public DateTime? EDate { get { return Fields.EDate[this]; } set { Fields.EDate[this] = value; } }
        public partial class RowFields { public DateTimeField EDate; }
        #endregion EDate

        [NotMapped]
        public String ForwordBy { get { return Fields.ForwordBy[this]; } set { Fields.ForwordBy[this] = value; } }
        public partial class RowFields { public StringField ForwordBy; }

        [NotMapped]
        public String Status { get { return Fields.Status[this]; } set { Fields.Status[this] = value; } }
        public partial class RowFields { public StringField Status; }

        #region Foreign Fields
        //[DisplayName("Forword By")]
        //[MinSelectLevel(SelectLevel.List)]
        //public String ForwordBy { get { return Fields.ForwordBy[this]; } set { Fields.ForwordBy[this] = value; } }
        //public partial class RowFields { public StringField ForwordBy; }


        [DisplayName("Approver Name"), Expression("jEmploymentInfo.[FullName]")]
        [MinSelectLevel(SelectLevel.List)]
        public String EmploymentInfoFullName { get { return Fields.EmploymentInfoFullName[this]; } set { Fields.EmploymentInfoFullName[this] = value; } }
        public partial class RowFields { public StringField EmploymentInfoFullName; }

        [DisplayName("Approver Code"), Expression("jEmploymentInfo.[EmpID]")]
        [MinSelectLevel(SelectLevel.List)]
        public String ApproverCode { get { return Fields.ApproverCode[this]; } set { Fields.ApproverCode[this] = value; } }
        public partial class RowFields { public StringField ApproverCode; }
        #endregion Foreign Fields

        #region Id and Name fields
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.ApproverComments; }
        }
        #endregion Id and Name fields

        #region Constructor
        public ApvApplicationInformationRow()
        : base(Fields)
        {
        }
        #endregion Constructor

        #region RowFields
        public static readonly RowFields Fields = new RowFields().Init();

        public partial class RowFields : RowFieldsBase
        {
            public RowFields()
            : base("[dbo].[APV_ApplicationInformation]")
            {
                LocalTextPrefix = "Transaction.ApvApplicationInformation";
            }
        }
        #endregion RowFields
    }
}
