
namespace VistaGL.Configurations.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ACCDB"), Module("Configurations"), TableName("[dbo].[acc_FundControl_ZoneWise_Approver]")]
    [DisplayName("Fund Control and Zone Wise Approver"), InstanceName("Fund Control Zone Wise Approver")]
    [ReadPermission("?")]
    [InsertPermission("Configurations:AccFundControlZoneWiseApprover:Insert")]
    [UpdatePermission("Configurations:AccFundControlZoneWiseApprover:Update")]
    [DeletePermission("Configurations:AccFundControlZoneWiseApprover:Delete")]
    [LookupScript("Configurations.AccFundControlZoneWiseApprover", Permission = "?", Expiration = -1)]
    public sealed class AccFundControlZoneWiseApproverRow : Row, IIdRow
    {

        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Fund Control"), ForeignKey("[dbo].[acc_FundControlInformation]", "id"), LeftJoin("jFundControl"), TextualField("FundControlCode"), LookupInclude]
        [LookupEditor(typeof(AccFundControlInformationRow))]
        public Int32? FundControlId
        {
            get { return Fields.FundControlId[this]; }
            set { Fields.FundControlId[this] = value; }
        }

        [DisplayName("Zone Info"), ForeignKey("[dbo].[PRM_ZoneInfo]", "Id"), LeftJoin("jZoneInfo"), TextualField("ZoneInfoZoneName"), LookupInclude]
        [LookupEditor(typeof(PrmZoneInfoRow))]
        public Int32? ZoneInfoId
        {
            get { return Fields.ZoneInfoId[this]; }
            set { Fields.ZoneInfoId[this] = value; }
        }

        [DisplayName("Approver"), ForeignKey("[dbo].[PRM_EmploymentInfo]", "Id"), LeftJoin("jApprover"), TextualField("ApproverEmpId"), LookupInclude]
        [LookupEditor(typeof(PrmEmploymentInfoRow))]
        public Int32? ApproverId
        {
            get { return Fields.ApproverId[this]; }
            set { Fields.ApproverId[this] = value; }
        }

        [DisplayName("Posting By"), ForeignKey("[dbo].[PRM_EmploymentInfo]", "Id"), LeftJoin("jPostingBy"), TextualField("PostingByEmpId"),LookupInclude]
        [LookupEditor(typeof(PrmEmploymentInfoRow))]
        public Int32? PostingById
        {
            get { return Fields.PostingById[this]; }
            set { Fields.PostingById[this] = value; }
        }

        [DisplayName("Fund Control Code"), Expression("jFundControl.[code]")]
        public String FundControlCode
        {
            get { return Fields.FundControlCode[this]; }
            set { Fields.FundControlCode[this] = value; }
        }

        [DisplayName("Fund Control Fund Control Name"), Expression("jFundControl.[fundControlName]")]
        public String FundControlFundControlName
        {
            get { return Fields.FundControlFundControlName[this]; }
            set { Fields.FundControlFundControlName[this] = value; }
        }

        [DisplayName("Fund Control Booking Date"), Expression("jFundControl.[bookingDate]")]
        public DateTime? FundControlBookingDate
        {
            get { return Fields.FundControlBookingDate[this]; }
            set { Fields.FundControlBookingDate[this] = value; }
        }

        [DisplayName("Fund Control Currency Id"), Expression("jFundControl.[currencyId]")]
        public Int32? FundControlCurrencyId
        {
            get { return Fields.FundControlCurrencyId[this]; }
            set { Fields.FundControlCurrencyId[this] = value; }
        }

        [DisplayName("Fund Control Address"), Expression("jFundControl.[address]")]
        public String FundControlAddress
        {
            get { return Fields.FundControlAddress[this]; }
            set { Fields.FundControlAddress[this] = value; }
        }

        [DisplayName("Fund Control Phone"), Expression("jFundControl.[phone]")]
        public String FundControlPhone
        {
            get { return Fields.FundControlPhone[this]; }
            set { Fields.FundControlPhone[this] = value; }
        }

        [DisplayName("Fund Control Mobile"), Expression("jFundControl.[mobile]")]
        public String FundControlMobile
        {
            get { return Fields.FundControlMobile[this]; }
            set { Fields.FundControlMobile[this] = value; }
        }

        [DisplayName("Fund Control Fax"), Expression("jFundControl.[fax]")]
        public String FundControlFax
        {
            get { return Fields.FundControlFax[this]; }
            set { Fields.FundControlFax[this] = value; }
        }

        [DisplayName("Fund Control Email"), Expression("jFundControl.[email]")]
        public String FundControlEmail
        {
            get { return Fields.FundControlEmail[this]; }
            set { Fields.FundControlEmail[this] = value; }
        }

        [DisplayName("Fund Control Web Url"), Expression("jFundControl.[webUrl]")]
        public String FundControlWebUrl
        {
            get { return Fields.FundControlWebUrl[this]; }
            set { Fields.FundControlWebUrl[this] = value; }
        }

        [DisplayName("Fund Control Remarks"), Expression("jFundControl.[remarks]")]
        public String FundControlRemarks
        {
            get { return Fields.FundControlRemarks[this]; }
            set { Fields.FundControlRemarks[this] = value; }
        }

        [DisplayName("Fund Control Zone Info Id"), Expression("jFundControl.[ZoneInfoId]")]
        public Int32? FundControlZoneInfoId
        {
            get { return Fields.FundControlZoneInfoId[this]; }
            set { Fields.FundControlZoneInfoId[this] = value; }
        }



        [DisplayName("Zone Info Zone Name"), Expression("jZoneInfo.[ZoneName]")]
        public String ZoneInfoZoneName
        {
            get { return Fields.ZoneInfoZoneName[this]; }
            set { Fields.ZoneInfoZoneName[this] = value; }
        }

        [DisplayName("Zone Info Zone Name In Bengali"), Expression("jZoneInfo.[ZoneNameInBengali]")]
        public String ZoneInfoZoneNameInBengali
        {
            get { return Fields.ZoneInfoZoneNameInBengali[this]; }
            set { Fields.ZoneInfoZoneNameInBengali[this] = value; }
        }

        [DisplayName("Zone Info Zone Code"), Expression("jZoneInfo.[ZoneCode]")]
        public String ZoneInfoZoneCode
        {
            get { return Fields.ZoneInfoZoneCode[this]; }
            set { Fields.ZoneInfoZoneCode[this] = value; }
        }

        [DisplayName("Zone Info Sort Order"), Expression("jZoneInfo.[SortOrder]")]
        public Int32? ZoneInfoSortOrder
        {
            get { return Fields.ZoneInfoSortOrder[this]; }
            set { Fields.ZoneInfoSortOrder[this] = value; }
        }

        [DisplayName("Zone Info Organogram Category Type Id"), Expression("jZoneInfo.[OrganogramCategoryTypeId]")]
        public Int32? ZoneInfoOrganogramCategoryTypeId
        {
            get { return Fields.ZoneInfoOrganogramCategoryTypeId[this]; }
            set { Fields.ZoneInfoOrganogramCategoryTypeId[this] = value; }
        }

        [DisplayName("Zone Info Zone Address"), Expression("jZoneInfo.[ZoneAddress]")]
        public String ZoneInfoZoneAddress
        {
            get { return Fields.ZoneInfoZoneAddress[this]; }
            set { Fields.ZoneInfoZoneAddress[this] = value; }
        }

        [DisplayName("Zone Info Zone Address In Bengali"), Expression("jZoneInfo.[ZoneAddressInBengali]")]
        public String ZoneInfoZoneAddressInBengali
        {
            get { return Fields.ZoneInfoZoneAddressInBengali[this]; }
            set { Fields.ZoneInfoZoneAddressInBengali[this] = value; }
        }

        [DisplayName("Zone Info Prefix"), Expression("jZoneInfo.[Prefix]")]
        public String ZoneInfoPrefix
        {
            get { return Fields.ZoneInfoPrefix[this]; }
            set { Fields.ZoneInfoPrefix[this] = value; }
        }

        [DisplayName("Zone Info Is Head Office"), Expression("jZoneInfo.[IsHeadOffice]")]
        public Boolean? ZoneInfoIsHeadOffice
        {
            get { return Fields.ZoneInfoIsHeadOffice[this]; }
            set { Fields.ZoneInfoIsHeadOffice[this] = value; }
        }

        [DisplayName("Zone Info Zone Code For Billing System"), Expression("jZoneInfo.[ZoneCodeForBillingSystem]")]
        public String ZoneInfoZoneCodeForBillingSystem
        {
            get { return Fields.ZoneInfoZoneCodeForBillingSystem[this]; }
            set { Fields.ZoneInfoZoneCodeForBillingSystem[this] = value; }
        }



        [DisplayName("Approver Emp Id"), Expression("jApprover.[EmpID]")]
        public String ApproverEmpId
        {
            get { return Fields.ApproverEmpId[this]; }
            set { Fields.ApproverEmpId[this] = value; }
        }

        [DisplayName("Approver Employee Initial"), Expression("jApprover.[EmployeeInitial]")]
        public String ApproverEmployeeInitial
        {
            get { return Fields.ApproverEmployeeInitial[this]; }
            set { Fields.ApproverEmployeeInitial[this] = value; }
        }

        [DisplayName("Approver Title Id"), Expression("jApprover.[TitleId]")]
        public Int32? ApproverTitleId
        {
            get { return Fields.ApproverTitleId[this]; }
            set { Fields.ApproverTitleId[this] = value; }
        }

        [DisplayName("Approver First Name"), Expression("jApprover.[FirstName]")]
        public String ApproverFirstName
        {
            get { return Fields.ApproverFirstName[this]; }
            set { Fields.ApproverFirstName[this] = value; }
        }

        [DisplayName("Approver Middle Name"), Expression("jApprover.[MiddleName]")]
        public String ApproverMiddleName
        {
            get { return Fields.ApproverMiddleName[this]; }
            set { Fields.ApproverMiddleName[this] = value; }
        }

        [DisplayName("Approver Last Name"), Expression("jApprover.[LastName]")]
        public String ApproverLastName
        {
            get { return Fields.ApproverLastName[this]; }
            set { Fields.ApproverLastName[this] = value; }
        }

        [DisplayName("Approver Full Name"), Expression("jApprover.[FullName]")]
        public String ApproverFullName
        {
            get { return Fields.ApproverFullName[this]; }
            set { Fields.ApproverFullName[this] = value; }
        }

        [DisplayName("Approver Full Name Bangla"), Expression("jApprover.[FullNameBangla]")]
        public String ApproverFullNameBangla
        {
            get { return Fields.ApproverFullNameBangla[this]; }
            set { Fields.ApproverFullNameBangla[this] = value; }
        }

        [DisplayName("Approver Dateof Joining"), Expression("jApprover.[DateofJoining]")]
        public DateTime? ApproverDateofJoining
        {
            get { return Fields.ApproverDateofJoining[this]; }
            set { Fields.ApproverDateofJoining[this] = value; }
        }

        [DisplayName("Approver Provision Month"), Expression("jApprover.[ProvisionMonth]")]
        public Int32? ApproverProvisionMonth
        {
            get { return Fields.ApproverProvisionMonth[this]; }
            set { Fields.ApproverProvisionMonth[this] = value; }
        }

        [DisplayName("Approver Dateof Confirmation"), Expression("jApprover.[DateofConfirmation]")]
        public DateTime? ApproverDateofConfirmation
        {
            get { return Fields.ApproverDateofConfirmation[this]; }
            set { Fields.ApproverDateofConfirmation[this] = value; }
        }

        [DisplayName("Approver Dateof Position"), Expression("jApprover.[DateofPosition]")]
        public DateTime? ApproverDateofPosition
        {
            get { return Fields.ApproverDateofPosition[this]; }
            set { Fields.ApproverDateofPosition[this] = value; }
        }

        [DisplayName("Approver Designation Id"), Expression("jApprover.[DesignationId]")]
        public Int32? ApproverDesignationId
        {
            get { return Fields.ApproverDesignationId[this]; }
            set { Fields.ApproverDesignationId[this] = value; }
        }

        [DisplayName("Approver Status Designation Id"), Expression("jApprover.[StatusDesignationId]")]
        public Int32? ApproverStatusDesignationId
        {
            get { return Fields.ApproverStatusDesignationId[this]; }
            set { Fields.ApproverStatusDesignationId[this] = value; }
        }

        [DisplayName("Approver Discipline Id"), Expression("jApprover.[DisciplineId]")]
        public Int32? ApproverDisciplineId
        {
            get { return Fields.ApproverDisciplineId[this]; }
            set { Fields.ApproverDisciplineId[this] = value; }
        }

        [DisplayName("Approver Division Id"), Expression("jApprover.[DivisionId]")]
        public Int32? ApproverDivisionId
        {
            get { return Fields.ApproverDivisionId[this]; }
            set { Fields.ApproverDivisionId[this] = value; }
        }

        [DisplayName("Approver Section Id"), Expression("jApprover.[SectionId]")]
        public Int32? ApproverSectionId
        {
            get { return Fields.ApproverSectionId[this]; }
            set { Fields.ApproverSectionId[this] = value; }
        }

        [DisplayName("Approver Sub Section Id"), Expression("jApprover.[SubSectionId]")]
        public Int32? ApproverSubSectionId
        {
            get { return Fields.ApproverSubSectionId[this]; }
            set { Fields.ApproverSubSectionId[this] = value; }
        }

        [DisplayName("Approver Job Location Id"), Expression("jApprover.[JobLocationId]")]
        public Int32? ApproverJobLocationId
        {
            get { return Fields.ApproverJobLocationId[this]; }
            set { Fields.ApproverJobLocationId[this] = value; }
        }

        [DisplayName("Approver Resource Level Id"), Expression("jApprover.[ResourceLevelId]")]
        public Int32? ApproverResourceLevelId
        {
            get { return Fields.ApproverResourceLevelId[this]; }
            set { Fields.ApproverResourceLevelId[this] = value; }
        }

        [DisplayName("Approver Staff Category Id"), Expression("jApprover.[StaffCategoryId]")]
        public Int32? ApproverStaffCategoryId
        {
            get { return Fields.ApproverStaffCategoryId[this]; }
            set { Fields.ApproverStaffCategoryId[this] = value; }
        }

        [DisplayName("Approver Employment Type Id"), Expression("jApprover.[EmploymentTypeId]")]
        public Int32? ApproverEmploymentTypeId
        {
            get { return Fields.ApproverEmploymentTypeId[this]; }
            set { Fields.ApproverEmploymentTypeId[this] = value; }
        }

        [DisplayName("Approver Religion Id"), Expression("jApprover.[ReligionId]")]
        public Int32? ApproverReligionId
        {
            get { return Fields.ApproverReligionId[this]; }
            set { Fields.ApproverReligionId[this] = value; }
        }

        [DisplayName("Approver Is Contractual"), Expression("jApprover.[IsContractual]")]
        public Boolean? ApproverIsContractual
        {
            get { return Fields.ApproverIsContractual[this]; }
            set { Fields.ApproverIsContractual[this] = value; }
        }

        [DisplayName("Approver Overtime Rate"), Expression("jApprover.[OvertimeRate]")]
        public Decimal? ApproverOvertimeRate
        {
            get { return Fields.ApproverOvertimeRate[this]; }
            set { Fields.ApproverOvertimeRate[this] = value; }
        }

        [DisplayName("Approver Mobile No"), Expression("jApprover.[MobileNo]")]
        public String ApproverMobileNo
        {
            get { return Fields.ApproverMobileNo[this]; }
            set { Fields.ApproverMobileNo[this] = value; }
        }

        [DisplayName("Approver Emial Address"), Expression("jApprover.[EmialAddress]")]
        public String ApproverEmialAddress
        {
            get { return Fields.ApproverEmialAddress[this]; }
            set { Fields.ApproverEmialAddress[this] = value; }
        }

        [DisplayName("Approver Bank Id"), Expression("jApprover.[BankId]")]
        public Int32? ApproverBankId
        {
            get { return Fields.ApproverBankId[this]; }
            set { Fields.ApproverBankId[this] = value; }
        }

        [DisplayName("Approver Bank Branch Id"), Expression("jApprover.[BankBranchId]")]
        public Int32? ApproverBankBranchId
        {
            get { return Fields.ApproverBankBranchId[this]; }
            set { Fields.ApproverBankBranchId[this] = value; }
        }

        [DisplayName("Approver Bank Account No"), Expression("jApprover.[BankAccountNo]")]
        public String ApproverBankAccountNo
        {
            get { return Fields.ApproverBankAccountNo[this]; }
            set { Fields.ApproverBankAccountNo[this] = value; }
        }

        [DisplayName("Approver Employment Status Id"), Expression("jApprover.[EmploymentStatusId]")]
        public Int32? ApproverEmploymentStatusId
        {
            get { return Fields.ApproverEmploymentStatusId[this]; }
            set { Fields.ApproverEmploymentStatusId[this] = value; }
        }

        [DisplayName("Approver Dateof Inactive"), Expression("jApprover.[DateofInactive]")]
        public DateTime? ApproverDateofInactive
        {
            get { return Fields.ApproverDateofInactive[this]; }
            set { Fields.ApproverDateofInactive[this] = value; }
        }

        [DisplayName("Approver Is Consultant"), Expression("jApprover.[IsConsultant]")]
        public Boolean? ApproverIsConsultant
        {
            get { return Fields.ApproverIsConsultant[this]; }
            set { Fields.ApproverIsConsultant[this] = value; }
        }

        [DisplayName("Approver Is Overtime Eligible"), Expression("jApprover.[IsOvertimeEligible]")]
        public Boolean? ApproverIsOvertimeEligible
        {
            get { return Fields.ApproverIsOvertimeEligible[this]; }
            set { Fields.ApproverIsOvertimeEligible[this] = value; }
        }

        [DisplayName("Approver Is Refreshment Eligible"), Expression("jApprover.[IsRefreshmentEligible]")]
        public Boolean? ApproverIsRefreshmentEligible
        {
            get { return Fields.ApproverIsRefreshmentEligible[this]; }
            set { Fields.ApproverIsRefreshmentEligible[this] = value; }
        }

        [DisplayName("Approver Is Bonus Eligible"), Expression("jApprover.[IsBonusEligible]")]
        public Boolean? ApproverIsBonusEligible
        {
            get { return Fields.ApproverIsBonusEligible[this]; }
            set { Fields.ApproverIsBonusEligible[this] = value; }
        }

        [DisplayName("Approver Is Eligible For Cpf"), Expression("jApprover.[IsEligibleForCpf]")]
        public Boolean? ApproverIsEligibleForCpf
        {
            get { return Fields.ApproverIsEligibleForCpf[this]; }
            set { Fields.ApproverIsEligibleForCpf[this] = value; }
        }

        [DisplayName("Approver Is Gpf Eligible"), Expression("jApprover.[IsGPFEligible]")]
        public Boolean? ApproverIsGpfEligible
        {
            get { return Fields.ApproverIsGpfEligible[this]; }
            set { Fields.ApproverIsGpfEligible[this] = value; }
        }

        [DisplayName("Approver Is Pension Eligible"), Expression("jApprover.[IsPensionEligible]")]
        public Boolean? ApproverIsPensionEligible
        {
            get { return Fields.ApproverIsPensionEligible[this]; }
            set { Fields.ApproverIsPensionEligible[this] = value; }
        }

        [DisplayName("Approver Is Leverage Eligible"), Expression("jApprover.[IsLeverageEligible]")]
        public Boolean? ApproverIsLeverageEligible
        {
            get { return Fields.ApproverIsLeverageEligible[this]; }
            set { Fields.ApproverIsLeverageEligible[this] = value; }
        }

        [DisplayName("Approver Is General Shifted"), Expression("jApprover.[IsGeneralShifted]")]
        public Boolean? ApproverIsGeneralShifted
        {
            get { return Fields.ApproverIsGeneralShifted[this]; }
            set { Fields.ApproverIsGeneralShifted[this] = value; }
        }

        [DisplayName("Approver Salary Scale Id"), Expression("jApprover.[SalaryScaleId]")]
        public Int32? ApproverSalaryScaleId
        {
            get { return Fields.ApproverSalaryScaleId[this]; }
            set { Fields.ApproverSalaryScaleId[this] = value; }
        }

        [DisplayName("Approver Job Grade Id"), Expression("jApprover.[JobGradeId]")]
        public Int32? ApproverJobGradeId
        {
            get { return Fields.ApproverJobGradeId[this]; }
            set { Fields.ApproverJobGradeId[this] = value; }
        }

        [DisplayName("Approver Gender"), Expression("jApprover.[Gender]")]
        public String ApproverGender
        {
            get { return Fields.ApproverGender[this]; }
            set { Fields.ApproverGender[this] = value; }
        }

        [DisplayName("Approver Contract Expire Date"), Expression("jApprover.[ContractExpireDate]")]
        public DateTime? ApproverContractExpireDate
        {
            get { return Fields.ApproverContractExpireDate[this]; }
            set { Fields.ApproverContractExpireDate[this] = value; }
        }

        [DisplayName("Approver Dateof Birth"), Expression("jApprover.[DateofBirth]")]
        public DateTime? ApproverDateofBirth
        {
            get { return Fields.ApproverDateofBirth[this]; }
            set { Fields.ApproverDateofBirth[this] = value; }
        }

        [DisplayName("Approver Contract Duration"), Expression("jApprover.[ContractDuration]")]
        public Decimal? ApproverContractDuration
        {
            get { return Fields.ApproverContractDuration[this]; }
            set { Fields.ApproverContractDuration[this] = value; }
        }

        [DisplayName("Approver Contract Type"), Expression("jApprover.[ContractType]")]
        public Int32? ApproverContractType
        {
            get { return Fields.ApproverContractType[this]; }
            set { Fields.ApproverContractType[this] = value; }
        }

        [DisplayName("Approver Organogram Level Id"), Expression("jApprover.[OrganogramLevelId]")]
        public Int32? ApproverOrganogramLevelId
        {
            get { return Fields.ApproverOrganogramLevelId[this]; }
            set { Fields.ApproverOrganogramLevelId[this] = value; }
        }

        [DisplayName("Approver Dateof Appointment"), Expression("jApprover.[DateofAppointment]")]
        public DateTime? ApproverDateofAppointment
        {
            get { return Fields.ApproverDateofAppointment[this]; }
            set { Fields.ApproverDateofAppointment[this] = value; }
        }

        [DisplayName("Approver Order No"), Expression("jApprover.[OrderNo]")]
        public String ApproverOrderNo
        {
            get { return Fields.ApproverOrderNo[this]; }
            set { Fields.ApproverOrderNo[this] = value; }
        }

        [DisplayName("Approver Quota Id"), Expression("jApprover.[QuotaId]")]
        public Int32? ApproverQuotaId
        {
            get { return Fields.ApproverQuotaId[this]; }
            set { Fields.ApproverQuotaId[this] = value; }
        }

        [DisplayName("Approver Employee Class Id"), Expression("jApprover.[EmployeeClassId]")]
        public Int32? ApproverEmployeeClassId
        {
            get { return Fields.ApproverEmployeeClassId[this]; }
            set { Fields.ApproverEmployeeClassId[this] = value; }
        }

        [DisplayName("Approver Employment Process Id"), Expression("jApprover.[EmploymentProcessId]")]
        public Int32? ApproverEmploymentProcessId
        {
            get { return Fields.ApproverEmploymentProcessId[this]; }
            set { Fields.ApproverEmploymentProcessId[this] = value; }
        }

        [DisplayName("Approver Seniority Position"), Expression("jApprover.[SeniorityPosition]")]
        public String ApproverSeniorityPosition
        {
            get { return Fields.ApproverSeniorityPosition[this]; }
            set { Fields.ApproverSeniorityPosition[this] = value; }
        }

        [DisplayName("Approver Dateof Seniority"), Expression("jApprover.[DateofSeniority]")]
        public DateTime? ApproverDateofSeniority
        {
            get { return Fields.ApproverDateofSeniority[this]; }
            set { Fields.ApproverDateofSeniority[this] = value; }
        }

        [DisplayName("Approver Prl Date"), Expression("jApprover.[PRLDate]")]
        public DateTime? ApproverPrlDate
        {
            get { return Fields.ApproverPrlDate[this]; }
            set { Fields.ApproverPrlDate[this] = value; }
        }

        [DisplayName("Approver Card No"), Expression("jApprover.[CardNo]")]
        public String ApproverCardNo
        {
            get { return Fields.ApproverCardNo[this]; }
            set { Fields.ApproverCardNo[this] = value; }
        }

        [DisplayName("Approver Finger Print Identiy No"), Expression("jApprover.[FingerPrintIdentiyNo]")]
        public String ApproverFingerPrintIdentiyNo
        {
            get { return Fields.ApproverFingerPrintIdentiyNo[this]; }
            set { Fields.ApproverFingerPrintIdentiyNo[this] = value; }
        }

        [DisplayName("Approver Attendance Effective Date"), Expression("jApprover.[AttendanceEffectiveDate]")]
        public DateTime? ApproverAttendanceEffectiveDate
        {
            get { return Fields.ApproverAttendanceEffectiveDate[this]; }
            set { Fields.ApproverAttendanceEffectiveDate[this] = value; }
        }

        [DisplayName("Approver Attendance Status"), Expression("jApprover.[AttendanceStatus]")]
        public Boolean? ApproverAttendanceStatus
        {
            get { return Fields.ApproverAttendanceStatus[this]; }
            set { Fields.ApproverAttendanceStatus[this] = value; }
        }

        [DisplayName("Approver Zone Info Id"), Expression("jApprover.[ZoneInfoId]")]
        public Int32? ApproverZoneInfoId
        {
            get { return Fields.ApproverZoneInfoId[this]; }
            set { Fields.ApproverZoneInfoId[this] = value; }
        }

        [DisplayName("Approver Telephone Office"), Expression("jApprover.[TelephoneOffice]")]
        public String ApproverTelephoneOffice
        {
            get { return Fields.ApproverTelephoneOffice[this]; }
            set { Fields.ApproverTelephoneOffice[this] = value; }
        }

        [DisplayName("Approver Intercom"), Expression("jApprover.[Intercom]")]
        public String ApproverIntercom
        {
            get { return Fields.ApproverIntercom[this]; }
            set { Fields.ApproverIntercom[this] = value; }
        }

        [DisplayName("Approver Honorary Degree"), Expression("jApprover.[HonoraryDegree]")]
        public String ApproverHonoraryDegree
        {
            get { return Fields.ApproverHonoraryDegree[this]; }
            set { Fields.ApproverHonoraryDegree[this] = value; }
        }

        [DisplayName("Approver Tax Region Id"), Expression("jApprover.[TaxRegionId]")]
        public Int32? ApproverTaxRegionId
        {
            get { return Fields.ApproverTaxRegionId[this]; }
            set { Fields.ApproverTaxRegionId[this] = value; }
        }

        [DisplayName("Approver Tax Assessee Type"), Expression("jApprover.[TaxAssesseeType]")]
        public Int16? ApproverTaxAssesseeType
        {
            get { return Fields.ApproverTaxAssesseeType[this]; }
            set { Fields.ApproverTaxAssesseeType[this] = value; }
        }

        [DisplayName("Approver Having Child With Disability"), Expression("jApprover.[HavingChildWithDisability]")]
        public Boolean? ApproverHavingChildWithDisability
        {
            get { return Fields.ApproverHavingChildWithDisability[this]; }
            set { Fields.ApproverHavingChildWithDisability[this] = value; }
        }

        [DisplayName("Approver Dateof Retirement"), Expression("jApprover.[DateofRetirement]")]
        public DateTime? ApproverDateofRetirement
        {
            get { return Fields.ApproverDateofRetirement[this]; }
            set { Fields.ApproverDateofRetirement[this] = value; }
        }

        [DisplayName("Approver Salary Withdraw From Zone Id"), Expression("jApprover.[SalaryWithdrawFromZoneId]")]
        public Int32? ApproverSalaryWithdrawFromZoneId
        {
            get { return Fields.ApproverSalaryWithdrawFromZoneId[this]; }
            set { Fields.ApproverSalaryWithdrawFromZoneId[this] = value; }
        }

        [DisplayName("Approver Region Id"), Expression("jApprover.[RegionId]")]
        public Int32? ApproverRegionId
        {
            get { return Fields.ApproverRegionId[this]; }
            set { Fields.ApproverRegionId[this] = value; }
        }

        [DisplayName("Approver Etin"), Expression("jApprover.[ETIN]")]
        public String ApproverEtin
        {
            get { return Fields.ApproverEtin[this]; }
            set { Fields.ApproverEtin[this] = value; }
        }

        [DisplayName("Approver I User"), Expression("jApprover.[IUser]")]
        public String ApproverIUser
        {
            get { return Fields.ApproverIUser[this]; }
            set { Fields.ApproverIUser[this] = value; }
        }

        [DisplayName("Approver I Date"), Expression("jApprover.[IDate]")]
        public DateTime? ApproverIDate
        {
            get { return Fields.ApproverIDate[this]; }
            set { Fields.ApproverIDate[this] = value; }
        }

        [DisplayName("Approver E User"), Expression("jApprover.[EUser]")]
        public String ApproverEUser
        {
            get { return Fields.ApproverEUser[this]; }
            set { Fields.ApproverEUser[this] = value; }
        }

        [DisplayName("Approver E Date"), Expression("jApprover.[EDate]")]
        public DateTime? ApproverEDate
        {
            get { return Fields.ApproverEDate[this]; }
            set { Fields.ApproverEDate[this] = value; }
        }



        [DisplayName("Posting By Emp Id"), Expression("jPostingBy.[EmpID]")]
        public String PostingByEmpId
        {
            get { return Fields.PostingByEmpId[this]; }
            set { Fields.PostingByEmpId[this] = value; }
        }

        [DisplayName("Posting By Employee Initial"), Expression("jPostingBy.[EmployeeInitial]")]
        public String PostingByEmployeeInitial
        {
            get { return Fields.PostingByEmployeeInitial[this]; }
            set { Fields.PostingByEmployeeInitial[this] = value; }
        }

        [DisplayName("Posting By Title Id"), Expression("jPostingBy.[TitleId]")]
        public Int32? PostingByTitleId
        {
            get { return Fields.PostingByTitleId[this]; }
            set { Fields.PostingByTitleId[this] = value; }
        }

        [DisplayName("Posting By First Name"), Expression("jPostingBy.[FirstName]")]
        public String PostingByFirstName
        {
            get { return Fields.PostingByFirstName[this]; }
            set { Fields.PostingByFirstName[this] = value; }
        }

        [DisplayName("Posting By Middle Name"), Expression("jPostingBy.[MiddleName]")]
        public String PostingByMiddleName
        {
            get { return Fields.PostingByMiddleName[this]; }
            set { Fields.PostingByMiddleName[this] = value; }
        }

        [DisplayName("Posting By Last Name"), Expression("jPostingBy.[LastName]")]
        public String PostingByLastName
        {
            get { return Fields.PostingByLastName[this]; }
            set { Fields.PostingByLastName[this] = value; }
        }

        [DisplayName("Posting By Full Name"), Expression("jPostingBy.[FullName]")]
        public String PostingByFullName
        {
            get { return Fields.PostingByFullName[this]; }
            set { Fields.PostingByFullName[this] = value; }
        }

        [DisplayName("Posting By Full Name Bangla"), Expression("jPostingBy.[FullNameBangla]")]
        public String PostingByFullNameBangla
        {
            get { return Fields.PostingByFullNameBangla[this]; }
            set { Fields.PostingByFullNameBangla[this] = value; }
        }

        [DisplayName("Posting By Dateof Joining"), Expression("jPostingBy.[DateofJoining]")]
        public DateTime? PostingByDateofJoining
        {
            get { return Fields.PostingByDateofJoining[this]; }
            set { Fields.PostingByDateofJoining[this] = value; }
        }

        [DisplayName("Posting By Provision Month"), Expression("jPostingBy.[ProvisionMonth]")]
        public Int32? PostingByProvisionMonth
        {
            get { return Fields.PostingByProvisionMonth[this]; }
            set { Fields.PostingByProvisionMonth[this] = value; }
        }

        [DisplayName("Posting By Dateof Confirmation"), Expression("jPostingBy.[DateofConfirmation]")]
        public DateTime? PostingByDateofConfirmation
        {
            get { return Fields.PostingByDateofConfirmation[this]; }
            set { Fields.PostingByDateofConfirmation[this] = value; }
        }

        [DisplayName("Posting By Dateof Position"), Expression("jPostingBy.[DateofPosition]")]
        public DateTime? PostingByDateofPosition
        {
            get { return Fields.PostingByDateofPosition[this]; }
            set { Fields.PostingByDateofPosition[this] = value; }
        }

        [DisplayName("Posting By Designation Id"), Expression("jPostingBy.[DesignationId]")]
        public Int32? PostingByDesignationId
        {
            get { return Fields.PostingByDesignationId[this]; }
            set { Fields.PostingByDesignationId[this] = value; }
        }

        [DisplayName("Posting By Status Designation Id"), Expression("jPostingBy.[StatusDesignationId]")]
        public Int32? PostingByStatusDesignationId
        {
            get { return Fields.PostingByStatusDesignationId[this]; }
            set { Fields.PostingByStatusDesignationId[this] = value; }
        }

        [DisplayName("Posting By Discipline Id"), Expression("jPostingBy.[DisciplineId]")]
        public Int32? PostingByDisciplineId
        {
            get { return Fields.PostingByDisciplineId[this]; }
            set { Fields.PostingByDisciplineId[this] = value; }
        }

        [DisplayName("Posting By Division Id"), Expression("jPostingBy.[DivisionId]")]
        public Int32? PostingByDivisionId
        {
            get { return Fields.PostingByDivisionId[this]; }
            set { Fields.PostingByDivisionId[this] = value; }
        }

        [DisplayName("Posting By Section Id"), Expression("jPostingBy.[SectionId]")]
        public Int32? PostingBySectionId
        {
            get { return Fields.PostingBySectionId[this]; }
            set { Fields.PostingBySectionId[this] = value; }
        }

        [DisplayName("Posting By Sub Section Id"), Expression("jPostingBy.[SubSectionId]")]
        public Int32? PostingBySubSectionId
        {
            get { return Fields.PostingBySubSectionId[this]; }
            set { Fields.PostingBySubSectionId[this] = value; }
        }

        [DisplayName("Posting By Job Location Id"), Expression("jPostingBy.[JobLocationId]")]
        public Int32? PostingByJobLocationId
        {
            get { return Fields.PostingByJobLocationId[this]; }
            set { Fields.PostingByJobLocationId[this] = value; }
        }

        [DisplayName("Posting By Resource Level Id"), Expression("jPostingBy.[ResourceLevelId]")]
        public Int32? PostingByResourceLevelId
        {
            get { return Fields.PostingByResourceLevelId[this]; }
            set { Fields.PostingByResourceLevelId[this] = value; }
        }

        [DisplayName("Posting By Staff Category Id"), Expression("jPostingBy.[StaffCategoryId]")]
        public Int32? PostingByStaffCategoryId
        {
            get { return Fields.PostingByStaffCategoryId[this]; }
            set { Fields.PostingByStaffCategoryId[this] = value; }
        }

        [DisplayName("Posting By Employment Type Id"), Expression("jPostingBy.[EmploymentTypeId]")]
        public Int32? PostingByEmploymentTypeId
        {
            get { return Fields.PostingByEmploymentTypeId[this]; }
            set { Fields.PostingByEmploymentTypeId[this] = value; }
        }

        [DisplayName("Posting By Religion Id"), Expression("jPostingBy.[ReligionId]")]
        public Int32? PostingByReligionId
        {
            get { return Fields.PostingByReligionId[this]; }
            set { Fields.PostingByReligionId[this] = value; }
        }

        [DisplayName("Posting By Is Contractual"), Expression("jPostingBy.[IsContractual]")]
        public Boolean? PostingByIsContractual
        {
            get { return Fields.PostingByIsContractual[this]; }
            set { Fields.PostingByIsContractual[this] = value; }
        }

        [DisplayName("Posting By Overtime Rate"), Expression("jPostingBy.[OvertimeRate]")]
        public Decimal? PostingByOvertimeRate
        {
            get { return Fields.PostingByOvertimeRate[this]; }
            set { Fields.PostingByOvertimeRate[this] = value; }
        }

        [DisplayName("Posting By Mobile No"), Expression("jPostingBy.[MobileNo]")]
        public String PostingByMobileNo
        {
            get { return Fields.PostingByMobileNo[this]; }
            set { Fields.PostingByMobileNo[this] = value; }
        }

        [DisplayName("Posting By Emial Address"), Expression("jPostingBy.[EmialAddress]")]
        public String PostingByEmialAddress
        {
            get { return Fields.PostingByEmialAddress[this]; }
            set { Fields.PostingByEmialAddress[this] = value; }
        }

        [DisplayName("Posting By Bank Id"), Expression("jPostingBy.[BankId]")]
        public Int32? PostingByBankId
        {
            get { return Fields.PostingByBankId[this]; }
            set { Fields.PostingByBankId[this] = value; }
        }

        [DisplayName("Posting By Bank Branch Id"), Expression("jPostingBy.[BankBranchId]")]
        public Int32? PostingByBankBranchId
        {
            get { return Fields.PostingByBankBranchId[this]; }
            set { Fields.PostingByBankBranchId[this] = value; }
        }

        [DisplayName("Posting By Bank Account No"), Expression("jPostingBy.[BankAccountNo]")]
        public String PostingByBankAccountNo
        {
            get { return Fields.PostingByBankAccountNo[this]; }
            set { Fields.PostingByBankAccountNo[this] = value; }
        }

        [DisplayName("Posting By Employment Status Id"), Expression("jPostingBy.[EmploymentStatusId]")]
        public Int32? PostingByEmploymentStatusId
        {
            get { return Fields.PostingByEmploymentStatusId[this]; }
            set { Fields.PostingByEmploymentStatusId[this] = value; }
        }

        [DisplayName("Posting By Dateof Inactive"), Expression("jPostingBy.[DateofInactive]")]
        public DateTime? PostingByDateofInactive
        {
            get { return Fields.PostingByDateofInactive[this]; }
            set { Fields.PostingByDateofInactive[this] = value; }
        }

        [DisplayName("Posting By Is Consultant"), Expression("jPostingBy.[IsConsultant]")]
        public Boolean? PostingByIsConsultant
        {
            get { return Fields.PostingByIsConsultant[this]; }
            set { Fields.PostingByIsConsultant[this] = value; }
        }

        [DisplayName("Posting By Is Overtime Eligible"), Expression("jPostingBy.[IsOvertimeEligible]")]
        public Boolean? PostingByIsOvertimeEligible
        {
            get { return Fields.PostingByIsOvertimeEligible[this]; }
            set { Fields.PostingByIsOvertimeEligible[this] = value; }
        }

        [DisplayName("Posting By Is Refreshment Eligible"), Expression("jPostingBy.[IsRefreshmentEligible]")]
        public Boolean? PostingByIsRefreshmentEligible
        {
            get { return Fields.PostingByIsRefreshmentEligible[this]; }
            set { Fields.PostingByIsRefreshmentEligible[this] = value; }
        }

        [DisplayName("Posting By Is Bonus Eligible"), Expression("jPostingBy.[IsBonusEligible]")]
        public Boolean? PostingByIsBonusEligible
        {
            get { return Fields.PostingByIsBonusEligible[this]; }
            set { Fields.PostingByIsBonusEligible[this] = value; }
        }

        [DisplayName("Posting By Is Eligible For Cpf"), Expression("jPostingBy.[IsEligibleForCpf]")]
        public Boolean? PostingByIsEligibleForCpf
        {
            get { return Fields.PostingByIsEligibleForCpf[this]; }
            set { Fields.PostingByIsEligibleForCpf[this] = value; }
        }

        [DisplayName("Posting By Is Gpf Eligible"), Expression("jPostingBy.[IsGPFEligible]")]
        public Boolean? PostingByIsGpfEligible
        {
            get { return Fields.PostingByIsGpfEligible[this]; }
            set { Fields.PostingByIsGpfEligible[this] = value; }
        }

        [DisplayName("Posting By Is Pension Eligible"), Expression("jPostingBy.[IsPensionEligible]")]
        public Boolean? PostingByIsPensionEligible
        {
            get { return Fields.PostingByIsPensionEligible[this]; }
            set { Fields.PostingByIsPensionEligible[this] = value; }
        }

        [DisplayName("Posting By Is Leverage Eligible"), Expression("jPostingBy.[IsLeverageEligible]")]
        public Boolean? PostingByIsLeverageEligible
        {
            get { return Fields.PostingByIsLeverageEligible[this]; }
            set { Fields.PostingByIsLeverageEligible[this] = value; }
        }

        [DisplayName("Posting By Is General Shifted"), Expression("jPostingBy.[IsGeneralShifted]")]
        public Boolean? PostingByIsGeneralShifted
        {
            get { return Fields.PostingByIsGeneralShifted[this]; }
            set { Fields.PostingByIsGeneralShifted[this] = value; }
        }

        [DisplayName("Posting By Salary Scale Id"), Expression("jPostingBy.[SalaryScaleId]")]
        public Int32? PostingBySalaryScaleId
        {
            get { return Fields.PostingBySalaryScaleId[this]; }
            set { Fields.PostingBySalaryScaleId[this] = value; }
        }

        [DisplayName("Posting By Job Grade Id"), Expression("jPostingBy.[JobGradeId]")]
        public Int32? PostingByJobGradeId
        {
            get { return Fields.PostingByJobGradeId[this]; }
            set { Fields.PostingByJobGradeId[this] = value; }
        }

        [DisplayName("Posting By Gender"), Expression("jPostingBy.[Gender]")]
        public String PostingByGender
        {
            get { return Fields.PostingByGender[this]; }
            set { Fields.PostingByGender[this] = value; }
        }

        [DisplayName("Posting By Contract Expire Date"), Expression("jPostingBy.[ContractExpireDate]")]
        public DateTime? PostingByContractExpireDate
        {
            get { return Fields.PostingByContractExpireDate[this]; }
            set { Fields.PostingByContractExpireDate[this] = value; }
        }

        [DisplayName("Posting By Dateof Birth"), Expression("jPostingBy.[DateofBirth]")]
        public DateTime? PostingByDateofBirth
        {
            get { return Fields.PostingByDateofBirth[this]; }
            set { Fields.PostingByDateofBirth[this] = value; }
        }

        [DisplayName("Posting By Contract Duration"), Expression("jPostingBy.[ContractDuration]")]
        public Decimal? PostingByContractDuration
        {
            get { return Fields.PostingByContractDuration[this]; }
            set { Fields.PostingByContractDuration[this] = value; }
        }

        [DisplayName("Posting By Contract Type"), Expression("jPostingBy.[ContractType]")]
        public Int32? PostingByContractType
        {
            get { return Fields.PostingByContractType[this]; }
            set { Fields.PostingByContractType[this] = value; }
        }

        [DisplayName("Posting By Organogram Level Id"), Expression("jPostingBy.[OrganogramLevelId]")]
        public Int32? PostingByOrganogramLevelId
        {
            get { return Fields.PostingByOrganogramLevelId[this]; }
            set { Fields.PostingByOrganogramLevelId[this] = value; }
        }

        [DisplayName("Posting By Dateof Appointment"), Expression("jPostingBy.[DateofAppointment]")]
        public DateTime? PostingByDateofAppointment
        {
            get { return Fields.PostingByDateofAppointment[this]; }
            set { Fields.PostingByDateofAppointment[this] = value; }
        }

        [DisplayName("Posting By Order No"), Expression("jPostingBy.[OrderNo]")]
        public String PostingByOrderNo
        {
            get { return Fields.PostingByOrderNo[this]; }
            set { Fields.PostingByOrderNo[this] = value; }
        }

        [DisplayName("Posting By Quota Id"), Expression("jPostingBy.[QuotaId]")]
        public Int32? PostingByQuotaId
        {
            get { return Fields.PostingByQuotaId[this]; }
            set { Fields.PostingByQuotaId[this] = value; }
        }

        [DisplayName("Posting By Employee Class Id"), Expression("jPostingBy.[EmployeeClassId]")]
        public Int32? PostingByEmployeeClassId
        {
            get { return Fields.PostingByEmployeeClassId[this]; }
            set { Fields.PostingByEmployeeClassId[this] = value; }
        }

        [DisplayName("Posting By Employment Process Id"), Expression("jPostingBy.[EmploymentProcessId]")]
        public Int32? PostingByEmploymentProcessId
        {
            get { return Fields.PostingByEmploymentProcessId[this]; }
            set { Fields.PostingByEmploymentProcessId[this] = value; }
        }

        [DisplayName("Posting By Seniority Position"), Expression("jPostingBy.[SeniorityPosition]")]
        public String PostingBySeniorityPosition
        {
            get { return Fields.PostingBySeniorityPosition[this]; }
            set { Fields.PostingBySeniorityPosition[this] = value; }
        }

        [DisplayName("Posting By Dateof Seniority"), Expression("jPostingBy.[DateofSeniority]")]
        public DateTime? PostingByDateofSeniority
        {
            get { return Fields.PostingByDateofSeniority[this]; }
            set { Fields.PostingByDateofSeniority[this] = value; }
        }

        [DisplayName("Posting By Prl Date"), Expression("jPostingBy.[PRLDate]")]
        public DateTime? PostingByPrlDate
        {
            get { return Fields.PostingByPrlDate[this]; }
            set { Fields.PostingByPrlDate[this] = value; }
        }

        [DisplayName("Posting By Card No"), Expression("jPostingBy.[CardNo]")]
        public String PostingByCardNo
        {
            get { return Fields.PostingByCardNo[this]; }
            set { Fields.PostingByCardNo[this] = value; }
        }

        [DisplayName("Posting By Finger Print Identiy No"), Expression("jPostingBy.[FingerPrintIdentiyNo]")]
        public String PostingByFingerPrintIdentiyNo
        {
            get { return Fields.PostingByFingerPrintIdentiyNo[this]; }
            set { Fields.PostingByFingerPrintIdentiyNo[this] = value; }
        }

        [DisplayName("Posting By Attendance Effective Date"), Expression("jPostingBy.[AttendanceEffectiveDate]")]
        public DateTime? PostingByAttendanceEffectiveDate
        {
            get { return Fields.PostingByAttendanceEffectiveDate[this]; }
            set { Fields.PostingByAttendanceEffectiveDate[this] = value; }
        }

        [DisplayName("Posting By Attendance Status"), Expression("jPostingBy.[AttendanceStatus]")]
        public Boolean? PostingByAttendanceStatus
        {
            get { return Fields.PostingByAttendanceStatus[this]; }
            set { Fields.PostingByAttendanceStatus[this] = value; }
        }

        [DisplayName("Posting By Zone Info Id"), Expression("jPostingBy.[ZoneInfoId]")]
        public Int32? PostingByZoneInfoId
        {
            get { return Fields.PostingByZoneInfoId[this]; }
            set { Fields.PostingByZoneInfoId[this] = value; }
        }

        [DisplayName("Posting By Telephone Office"), Expression("jPostingBy.[TelephoneOffice]")]
        public String PostingByTelephoneOffice
        {
            get { return Fields.PostingByTelephoneOffice[this]; }
            set { Fields.PostingByTelephoneOffice[this] = value; }
        }

        [DisplayName("Posting By Intercom"), Expression("jPostingBy.[Intercom]")]
        public String PostingByIntercom
        {
            get { return Fields.PostingByIntercom[this]; }
            set { Fields.PostingByIntercom[this] = value; }
        }

        [DisplayName("Posting By Honorary Degree"), Expression("jPostingBy.[HonoraryDegree]")]
        public String PostingByHonoraryDegree
        {
            get { return Fields.PostingByHonoraryDegree[this]; }
            set { Fields.PostingByHonoraryDegree[this] = value; }
        }

        [DisplayName("Posting By Tax Region Id"), Expression("jPostingBy.[TaxRegionId]")]
        public Int32? PostingByTaxRegionId
        {
            get { return Fields.PostingByTaxRegionId[this]; }
            set { Fields.PostingByTaxRegionId[this] = value; }
        }

        [DisplayName("Posting By Tax Assessee Type"), Expression("jPostingBy.[TaxAssesseeType]")]
        public Int16? PostingByTaxAssesseeType
        {
            get { return Fields.PostingByTaxAssesseeType[this]; }
            set { Fields.PostingByTaxAssesseeType[this] = value; }
        }

        [DisplayName("Posting By Having Child With Disability"), Expression("jPostingBy.[HavingChildWithDisability]")]
        public Boolean? PostingByHavingChildWithDisability
        {
            get { return Fields.PostingByHavingChildWithDisability[this]; }
            set { Fields.PostingByHavingChildWithDisability[this] = value; }
        }

        [DisplayName("Posting By Dateof Retirement"), Expression("jPostingBy.[DateofRetirement]")]
        public DateTime? PostingByDateofRetirement
        {
            get { return Fields.PostingByDateofRetirement[this]; }
            set { Fields.PostingByDateofRetirement[this] = value; }
        }

        [DisplayName("Posting By Salary Withdraw From Zone Id"), Expression("jPostingBy.[SalaryWithdrawFromZoneId]")]
        public Int32? PostingBySalaryWithdrawFromZoneId
        {
            get { return Fields.PostingBySalaryWithdrawFromZoneId[this]; }
            set { Fields.PostingBySalaryWithdrawFromZoneId[this] = value; }
        }

        [DisplayName("Posting By Region Id"), Expression("jPostingBy.[RegionId]")]
        public Int32? PostingByRegionId
        {
            get { return Fields.PostingByRegionId[this]; }
            set { Fields.PostingByRegionId[this] = value; }
        }

        [DisplayName("Posting By Etin"), Expression("jPostingBy.[ETIN]")]
        public String PostingByEtin
        {
            get { return Fields.PostingByEtin[this]; }
            set { Fields.PostingByEtin[this] = value; }
        }

        [DisplayName("Posting By I User"), Expression("jPostingBy.[IUser]")]
        public String PostingByIUser
        {
            get { return Fields.PostingByIUser[this]; }
            set { Fields.PostingByIUser[this] = value; }
        }

        [DisplayName("Posting By I Date"), Expression("jPostingBy.[IDate]")]
        public DateTime? PostingByIDate
        {
            get { return Fields.PostingByIDate[this]; }
            set { Fields.PostingByIDate[this] = value; }
        }

        [DisplayName("Posting By E User"), Expression("jPostingBy.[EUser]")]
        public String PostingByEUser
        {
            get { return Fields.PostingByEUser[this]; }
            set { Fields.PostingByEUser[this] = value; }
        }

        [DisplayName("Posting By E Date"), Expression("jPostingBy.[EDate]")]
        public DateTime? PostingByEDate
        {
            get { return Fields.PostingByEDate[this]; }
            set { Fields.PostingByEDate[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AccFundControlZoneWiseApproverRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field Id;

            public Int32Field FundControlId;

            public Int32Field ZoneInfoId;

            public Int32Field ApproverId;

            public Int32Field PostingById;



            public StringField FundControlCode;

            public StringField FundControlFundControlName;

            public DateTimeField FundControlBookingDate;

            public Int32Field FundControlCurrencyId;

            public StringField FundControlAddress;

            public StringField FundControlPhone;

            public StringField FundControlMobile;

            public StringField FundControlFax;

            public StringField FundControlEmail;

            public StringField FundControlWebUrl;

            public StringField FundControlRemarks;

            public Int32Field FundControlZoneInfoId;



            public StringField ZoneInfoZoneName;

            public StringField ZoneInfoZoneNameInBengali;

            public StringField ZoneInfoZoneCode;

            public Int32Field ZoneInfoSortOrder;

            public Int32Field ZoneInfoOrganogramCategoryTypeId;

            public StringField ZoneInfoZoneAddress;

            public StringField ZoneInfoZoneAddressInBengali;

            public StringField ZoneInfoPrefix;

            public BooleanField ZoneInfoIsHeadOffice;

            public StringField ZoneInfoZoneCodeForBillingSystem;



            public StringField ApproverEmpId;

            public StringField ApproverEmployeeInitial;

            public Int32Field ApproverTitleId;

            public StringField ApproverFirstName;

            public StringField ApproverMiddleName;

            public StringField ApproverLastName;

            public StringField ApproverFullName;

            public StringField ApproverFullNameBangla;

            public DateTimeField ApproverDateofJoining;

            public Int32Field ApproverProvisionMonth;

            public DateTimeField ApproverDateofConfirmation;

            public DateTimeField ApproverDateofPosition;

            public Int32Field ApproverDesignationId;

            public Int32Field ApproverStatusDesignationId;

            public Int32Field ApproverDisciplineId;

            public Int32Field ApproverDivisionId;

            public Int32Field ApproverSectionId;

            public Int32Field ApproverSubSectionId;

            public Int32Field ApproverJobLocationId;

            public Int32Field ApproverResourceLevelId;

            public Int32Field ApproverStaffCategoryId;

            public Int32Field ApproverEmploymentTypeId;

            public Int32Field ApproverReligionId;

            public BooleanField ApproverIsContractual;

            public DecimalField ApproverOvertimeRate;

            public StringField ApproverMobileNo;

            public StringField ApproverEmialAddress;

            public Int32Field ApproverBankId;

            public Int32Field ApproverBankBranchId;

            public StringField ApproverBankAccountNo;

            public Int32Field ApproverEmploymentStatusId;

            public DateTimeField ApproverDateofInactive;

            public BooleanField ApproverIsConsultant;

            public BooleanField ApproverIsOvertimeEligible;

            public BooleanField ApproverIsRefreshmentEligible;

            public BooleanField ApproverIsBonusEligible;

            public BooleanField ApproverIsEligibleForCpf;

            public BooleanField ApproverIsGpfEligible;

            public BooleanField ApproverIsPensionEligible;

            public BooleanField ApproverIsLeverageEligible;

            public BooleanField ApproverIsGeneralShifted;

            public Int32Field ApproverSalaryScaleId;

            public Int32Field ApproverJobGradeId;

            public StringField ApproverGender;

            public DateTimeField ApproverContractExpireDate;

            public DateTimeField ApproverDateofBirth;

            public DecimalField ApproverContractDuration;

            public Int32Field ApproverContractType;

            public Int32Field ApproverOrganogramLevelId;

            public DateTimeField ApproverDateofAppointment;

            public StringField ApproverOrderNo;

            public Int32Field ApproverQuotaId;

            public Int32Field ApproverEmployeeClassId;

            public Int32Field ApproverEmploymentProcessId;

            public StringField ApproverSeniorityPosition;

            public DateTimeField ApproverDateofSeniority;

            public DateTimeField ApproverPrlDate;

            public StringField ApproverCardNo;

            public StringField ApproverFingerPrintIdentiyNo;

            public DateTimeField ApproverAttendanceEffectiveDate;

            public BooleanField ApproverAttendanceStatus;

            public Int32Field ApproverZoneInfoId;

            public StringField ApproverTelephoneOffice;

            public StringField ApproverIntercom;

            public StringField ApproverHonoraryDegree;

            public Int32Field ApproverTaxRegionId;

            public Int16Field ApproverTaxAssesseeType;

            public BooleanField ApproverHavingChildWithDisability;

            public DateTimeField ApproverDateofRetirement;

            public Int32Field ApproverSalaryWithdrawFromZoneId;

            public Int32Field ApproverRegionId;

            public StringField ApproverEtin;

            public StringField ApproverIUser;

            public DateTimeField ApproverIDate;

            public StringField ApproverEUser;

            public DateTimeField ApproverEDate;



            public StringField PostingByEmpId;

            public StringField PostingByEmployeeInitial;

            public Int32Field PostingByTitleId;

            public StringField PostingByFirstName;

            public StringField PostingByMiddleName;

            public StringField PostingByLastName;

            public StringField PostingByFullName;

            public StringField PostingByFullNameBangla;

            public DateTimeField PostingByDateofJoining;

            public Int32Field PostingByProvisionMonth;

            public DateTimeField PostingByDateofConfirmation;

            public DateTimeField PostingByDateofPosition;

            public Int32Field PostingByDesignationId;

            public Int32Field PostingByStatusDesignationId;

            public Int32Field PostingByDisciplineId;

            public Int32Field PostingByDivisionId;

            public Int32Field PostingBySectionId;

            public Int32Field PostingBySubSectionId;

            public Int32Field PostingByJobLocationId;

            public Int32Field PostingByResourceLevelId;

            public Int32Field PostingByStaffCategoryId;

            public Int32Field PostingByEmploymentTypeId;

            public Int32Field PostingByReligionId;

            public BooleanField PostingByIsContractual;

            public DecimalField PostingByOvertimeRate;

            public StringField PostingByMobileNo;

            public StringField PostingByEmialAddress;

            public Int32Field PostingByBankId;

            public Int32Field PostingByBankBranchId;

            public StringField PostingByBankAccountNo;

            public Int32Field PostingByEmploymentStatusId;

            public DateTimeField PostingByDateofInactive;

            public BooleanField PostingByIsConsultant;

            public BooleanField PostingByIsOvertimeEligible;

            public BooleanField PostingByIsRefreshmentEligible;

            public BooleanField PostingByIsBonusEligible;

            public BooleanField PostingByIsEligibleForCpf;

            public BooleanField PostingByIsGpfEligible;

            public BooleanField PostingByIsPensionEligible;

            public BooleanField PostingByIsLeverageEligible;

            public BooleanField PostingByIsGeneralShifted;

            public Int32Field PostingBySalaryScaleId;

            public Int32Field PostingByJobGradeId;

            public StringField PostingByGender;

            public DateTimeField PostingByContractExpireDate;

            public DateTimeField PostingByDateofBirth;

            public DecimalField PostingByContractDuration;

            public Int32Field PostingByContractType;

            public Int32Field PostingByOrganogramLevelId;

            public DateTimeField PostingByDateofAppointment;

            public StringField PostingByOrderNo;

            public Int32Field PostingByQuotaId;

            public Int32Field PostingByEmployeeClassId;

            public Int32Field PostingByEmploymentProcessId;

            public StringField PostingBySeniorityPosition;

            public DateTimeField PostingByDateofSeniority;

            public DateTimeField PostingByPrlDate;

            public StringField PostingByCardNo;

            public StringField PostingByFingerPrintIdentiyNo;

            public DateTimeField PostingByAttendanceEffectiveDate;

            public BooleanField PostingByAttendanceStatus;

            public Int32Field PostingByZoneInfoId;

            public StringField PostingByTelephoneOffice;

            public StringField PostingByIntercom;

            public StringField PostingByHonoraryDegree;

            public Int32Field PostingByTaxRegionId;

            public Int16Field PostingByTaxAssesseeType;

            public BooleanField PostingByHavingChildWithDisability;

            public DateTimeField PostingByDateofRetirement;

            public Int32Field PostingBySalaryWithdrawFromZoneId;

            public Int32Field PostingByRegionId;

            public StringField PostingByEtin;

            public StringField PostingByIUser;

            public DateTimeField PostingByIDate;

            public StringField PostingByEUser;

            public DateTimeField PostingByEDate;


		}
    }
}
