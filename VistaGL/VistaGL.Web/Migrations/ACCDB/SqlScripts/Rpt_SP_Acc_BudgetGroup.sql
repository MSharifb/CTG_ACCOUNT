-- SELECT * FROM acc_budget_group
-- SELECT * FROM acc_FundControlInformation
-- DROP PROC Rpt_SP_ACC_BudgetGroup
-- EXEC Rpt_SP_ACC_BudgetGroup 1

CREATE PROC Rpt_SP_ACC_BudgetGroup

	@param_fundcontrolId	INT

AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		bg.Id as Id, bg.ParentId as ParentId, bgparent.GroupName as ParentName, bg.GroupName as HeadName	
		, 0 as IsBudgetHead
		, 0 as IsCOA
		, 0 as IsCostCenter
		, bg.SortingOrder as BGSortOrder	
	FROM acc_budget_group bg
		LEFT JOIN acc_Budget_Group bgParent ON bg.ParentId = bgParent.Id
	where bg.IsActive = 1 AND bg.FundControlId = @param_fundcontrolId

	UNION ALL

	SELECT
		coa.Id as Id, bg.Id as ParentId, bg.GroupName as ParentName, coa.accountName as HeadName	
		, 1 as IsBudgetHead
		, 1 as IsCOA
		, 0 as IsCostCenter
		, bg.SortingOrder as BGSortOrder
	FROM acc_budget_group bg
		INNER join acc_ChartofAccounts coa ON bg.Id = coa.BudgetGroupId
	where bg.IsActive = 1 AND bg.FundControlId = @param_fundcontrolId

	UNION ALL

	SELECT
		cost.Id as Id, bg.Id as ParentId, bg.GroupName as ParentName, cost.name as HeadName	
		, 1 as IsBudgetHead
		, 0 as IsCOA
		, 1 as IsCostCenter
		, bg.SortingOrder as BGSortOrder
	FROM acc_budget_group bg
		INNER join acc_Cost_Centre_or_Institute_Information cost ON bg.Id = cost.BudgetGroupId
	where bg.IsActive = 1 AND bg.FundControlId = @param_fundcontrolId
	order by parentid

END