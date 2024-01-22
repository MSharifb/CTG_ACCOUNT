
namespace VistaGL.Transaction {

    import fld = AccVoucherInformationRow.Fields;

    @Serenity.Decorators.registerClass()
    export class VoucherApprovalGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey() { return 'Transaction.VoucherApproval'; }
        protected getDialogType() { return VoucherApprovalDialog; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getService() { return VoucherApprovalService.baseUrl; }

        private rowSelection: Serenity.GridRowSelectionMixin;
        private pendingChanges: Q.Dictionary<any> = {};

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Voucher Approval");
        }

        onViewSubmit(): boolean {

            if (!super.onViewSubmit()) {
                return false;
            }

            $('.s-FilterDisplayBar .reset').show();
            $('.s-FilterDisplayBar .current').show();

            var request = this.view.params as Serenity.ListRequest;

            if (request.EqualityFilter['approveStatus'].toString() == ApprovalStatus.Regret.toString()) {
                request.Criteria = Serenity.Criteria.and(request.Criteria,
                    [['approveStatus'], '=', ApprovalStatus.Regret.toString()]);

                $('.s-FilterDisplayBar .current .txt').html('[Approve Status = Regret]');
            } else if (request.EqualityFilter['approveStatus'].toString() == ApprovalStatus.Cancel.toString()) {

                request.Criteria = Serenity.Criteria.and(request.Criteria,
                    [['approveStatus'], '=', ApprovalStatus.Cancel.toString()]);

                $('.s-FilterDisplayBar .current .txt').html('[Approve Status = Cancel]');

            } else {

                let approvalCriteria = Serenity.Criteria.or([['approveStatus'], '=', ApprovalStatus.Submit.toString()],
                    [['approveStatus'], '=', ApprovalStatus.Recommend.toString()]);

                request.Criteria = Serenity.Criteria.and(request.Criteria, approvalCriteria);

                if (request.EqualityFilter['approveStatus'].toString() == "")
                    $('.s-FilterDisplayBar .current .txt')
                        .html('[Approve Status = Submit or Approve Status = Recommend]');
                else
                    $('.s-FilterDisplayBar .current .txt').html('[Approve Status = ' +
                        ApprovalStatus[request.EqualityFilter['approveStatus']] +
                        ']');
            }


            return true;
        }

        usePager(): boolean { return false; }

        protected onViewProcessData(response: Serenity.ListResponse<AccVoucherInformationRow>) {

            response = super.onViewProcessData(response);

            $('.approve-button').show();
            $('.recommend-button').show();

            if (response.Entities.length == 0) {
                return response;
            }

            let entity = response.Entities.filter(e => e.ApprovalAction != "")[0];
            if (entity == undefined) {
                entity = response.Entities[0];
            }

            var approvalActionLookup = $('#ddl11');

            if (approvalActionLookup.length == 0) {

                $('.buttons-inner').append('');

                var ddl = $('<select />');
                ddl.addClass('selectApprover');
                ddl.attr('id', 'ddl11');
                ddl.css("width", 250);
                
                let currentApproverType = "Recommender";
                let defaultTextinDDL = '';
                Transaction.VoucherApprovalService.IsVoucherApprover({}, response => {
                    if (response.IsApprover) {
                        currentApproverType = "Approver";
                        defaultTextinDDL = '--- Send To/Forward To ---';
                    }
                    else {
                        defaultTextinDDL = '--- Forward To ---';
                    }

                    if (currentApproverType == "Approver") { // Approver can recommend also!
                        $('.approve-button').show();
                        $('.recommend-button').show();
                        
                        $('<option />', { value: '', text: defaultTextinDDL }).appendTo(ddl);
                        
                        Transaction.VoucherApprovalService.GetPostingSendTo({ Id: entity.Id }, r => {
                            //
                            var items = r.Entities;
                            for (let item of items) {
                                //if (item.ApproverTypeName == "Main")
                                {
                                    $('<option />', { value: item.Id.toString(), text: item.FullName }).appendTo(ddl);
                                }
                            }
                        });

                        Transaction.VoucherApprovalService.GetNextApprover({ Id: entity.Id }, r => {
                            var items = r.Entities;
                            for (var item of items) {
                                $('<option />', { value: item.Id.toString(), text: item.FullName }).appendTo(ddl);
                            }
                        });
                    }
                    else if (currentApproverType == "Recommender") {
                        //--
                        $('.approve-button').hide();
                        
                        $('<option />', { value: '', text: defaultTextinDDL }).appendTo(ddl);

                        Transaction.VoucherApprovalService.GetNextApprover({ Id: entity.Id }, r => {
                            var items = r.Entities;
                            for (var item of items) {
                                $('<option />', { value: item.Id.toString(), text: item.FullName }).appendTo(ddl);
                            }
                        });
                    }


                    ddl.appendTo('.buttons-inner');
                    (<any>$('select.selectApprover')).select2();
                    (<any>$('select.selectApprover')).select2('data', { id: '', text: defaultTextinDDL })
                });              
                
            }

            return response;
        }

        protected createToolbarExtensions() {
            super.createToolbarExtensions();
            this.rowSelection = new Serenity.GridRowSelectionMixin(this);
        }

        protected getButtons() {
            var b = super.getButtons();
            b.shift();

            //--
            b.push({
                title: 'Approve',
                cssClass: 'approve-button',
                onClick: (x) => {

                    if ((<any>$('.selectApprover')).select2("val") == "") {
                        Q.notifyError("Select send to from dropdown please!");
                        return;
                    }

                    let message = "Are you sure you want to approve this voucher?";
                    Q.confirm(message, () => {
                        this.saveClick(ApprovalStatus.Approved);
                    });

                },
                separator: true
            });

            //--
            b.push({
                title: 'Recommend',
                cssClass: 'send-button recommend-button',
                onClick: (x) => {

                    if ((<any>$('.selectApprover')).select2("val") == "") {
                        Q.notifyError("Select forward to from dropdown please!");
                        return;
                    }

                    let message = "Are you sure you want to recommend this voucher?";
                    Q.confirm(message, () => {
                        this.saveClick(ApprovalStatus.Recommend);
                    });

                },
                separator: true
            });

            ////--
            //b.push({
            //    title: 'Regret',
            //    cssClass: 'regret-button',
            //    onClick: (x) => {

            //        if ((<any>$('.selectApprover')).select2("val") == "") {
            //            Q.notifyError("Select forward to Please!");
            //            return;
            //        }

            //        let message = "Are you sure you want to regret this voucher?";
            //        Q.confirm(message, () => {
            //            this.saveClick(ApprovalStatus.Regret);
            //        });

            //    },
            //    separator: true
            //});

            ////--
            //b.push({
            //    title: 'Cancel',
            //    cssClass: 'reject-button',
            //    onClick: e => {
            //        let message = "Are you sure you want to Cancel/Reject this voucher?";
            //        Q.confirm(message, () => {
            //            this.saveClick(ApprovalStatus.Cancel);
            //        });

            //    },
            //    separator: true
            //});


            return b;
        }

        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.frozenColumn = 6;

            return opt;
        }

        protected getColumns(): Slick.Column[] {
            var columns = super.getColumns();

            columns.splice(0, 0, Serenity.GridRowSelectionMixin.createSelectColumn(() => this.rowSelection));

            columns.splice(1, 0, {
                field: 'Print Voucher',
                name: '',
                format: ctx => '<a class="inline-action Print-link" title="Print Voucher">' +
                    '<i class="fa fa-print text-blue"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            columns.splice(1, 0, {
                field: 'Edit',
                name: '',
                format: ctx => '<a class="inline-action Edit-link" title="Edit Voucher">' +
                    '<i class="fa fa-edit text-red"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });


            Q.first(columns, x => x.field == fld.approveStatus).cssClass += " col-Approve-Status";

            return columns;
        }

        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string {
            let klass: string = "";

            if (item.LinkedWithDebitVoucher) {
                klass += " linked-Journal-Voucher";
            }

            return Q.trimToNull(klass);
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number): void {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented()) {
                return;
            }

            var item = this.itemAt(row);
            var target = $(e.target);

            //-- Print voucher
            if (target.parent().hasClass('Print-link'))
                target = target.parent();

            if (target.hasClass("Print-link")) {
                e.preventDefault();
                if (item.LinkedWithAutoJV && item.LinkedWithAutoJV != null) {
                    var _url = "~/Reports/VoucherPreview/IndexCombineVoucher?id=" + item.Id + "&isCombineVoucher=" + true;
                } else {
                    var _url = "~/Reports/VoucherPreview?id=" + item.Id;
                }
                Q.postToUrl({ url: _url, params: {}, target: "_blank" });
            }


            //-- Edit voucher
            if (target.parent().hasClass('Edit-link'))
                target = target.parent();

            if (target.hasClass("Edit-link")) {
                e.preventDefault();
                if (item.VoucherTypeId == VoucherType.Payment_Voucher) {
                    var _url = "Payment#edit/" + item.Id;
                    Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                }
                else if (item.VoucherTypeId == VoucherType.Receipt_Voucher) {
                    var _url = "Receipt#edit/" + item.Id;
                    Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                }
                else if (item.VoucherTypeId == VoucherType.Journal_Voucher) {
                    var _url = "JournalVoucher#edit/" + item.Id;
                    Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                }
                else if (item.VoucherTypeId == VoucherType.Transfer_Voucher) {
                    var _url = "TransferVoucher#edit/" + item.Id;
                    Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                }
            }

            //-- Select Single
            if (target.hasClass('select-item')) {
                if (target.hasClass('checked')) {
                    delete this.pendingChanges[item.Id];
                } else {
                    var pending = this.pendingChanges[item.Id];
                    if (!pending) {
                        this.pendingChanges[item.Id] = pending = {};
                    }
                }
            }
        }

        private saveClick(approveType: ApprovalStatus) {

            if (Object.keys(this.pendingChanges).length === 0) {
                var selectedItems = this.rowSelection.getSelectedKeys();
                if (selectedItems.length > 0) {
                    for (var i = 0; selectedItems.length > i; i++) {
                        var pending = this.pendingChanges[selectedItems[i]]
                        if (!pending) {
                            this.pendingChanges[selectedItems[i]] = pending = {};
                        }
                    }
                }
                if (Object.keys(this.pendingChanges).length === 0) {
                    Q.notifyError("No row is selected!");
                    return;
                }
            }

            // this calls save service for all modified rows, one by one
            // you could write a batch update service
            var keys = Object.keys(this.pendingChanges);
            var current = -1;
            var self = this;

            (function saveNext() {
                if (++current >= keys.length) {
                    self.refresh();
                    return;
                }

                var key = keys[current];
                var entity = Q.deepClone(self.pendingChanges[key]);
                entity.Id = key;


                switch (approveType) {
                    case ApprovalStatus.Approved:
                        //
                        entity.ApprovalAction = ApprovalStatus.Approved.toString();
                        entity.approveStatus = ApprovalStatus.Approved.toString();
                        entity.postingSendTo = (<any>$('.selectApprover')).select2("val");

                        break;
                    case ApprovalStatus.Recommend:
                        //
                        entity.ApprovalAction = ApprovalStatus.Recommend.toString();
                        entity.approveStatus = ApprovalStatus.Recommend.toString();
                        entity.EmpId = (<any>$('.selectApprover')).select2("val");
                        break;
                    case ApprovalStatus.Regret:
                        //
                        entity.ApprovalAction = ApprovalStatus.Regret.toString();
                        entity.approveStatus = ApprovalStatus.Regret.toString();
                        entity.EmpId = (<any>$('.selectApprover')).select2("val");

                        break;
                    case ApprovalStatus.Cancel:
                        //
                        entity.ApprovalAction = ApprovalStatus.Cancel.toString();
                        entity.approveStatus = ApprovalStatus.Cancel.toString();

                        break;
                    default:
                }

                entity.ApproverId = (<any>$('.selectApprover')).select2("val");

                Q.serviceRequest('Transaction/VoucherApproval/Update', {
                    EntityId: key,
                    Entity: entity
                }, (response) => {
                    delete self.pendingChanges[key];
                    saveNext();
                });
            })();

            Q.notifySuccess('Application has been ' + ApprovalStatus[approveType] + ' successfully.');
        }

        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            let filters = super.getQuickFilters();


            // --
            let filterByChequeNo = Q.tryFirst(filters, x => x.field == fld.ChequeRegisterChequeNo);
            if (filterByChequeNo != null) {
                filterByChequeNo.title = "Cheque No..";
                filterByChequeNo.type = Serenity.StringEditor;
                filterByChequeNo.handler = h => {
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria,
                            [[fld.ChequeRegisterChequeNo], 'like', '%' + h.value + '%']);
                    }
                };
            }

            // --
            let filterByAmount = Q.tryFirst(filters, x => x.field == fld.Amount);
            if (filterByAmount != null) {
                filterByAmount.title = "Amount (Exactly)";
            }
            // --

            Q.first(filters, x => x.field == fld.LinkedWithDebitVoucher).init = w => {
                (w as TrueFalseEditor).value = 'false';
            };

            return filters;
        }

        getQuickSearchFields(): Serenity.QuickSearchField[] {

            let txt = (s) => Q.text("Db." + AccVoucherInformationRow.localTextPrefix + "." + s).toLowerCase();

            return [
                { name: "", title: "all" },
                { name: fld.VoucherNo, title: txt(fld.VoucherNo) },
                { name: fld.Description, title: txt(fld.Description) },
                { name: fld.PaytoOrReciveFrom, title: txt(fld.PaytoOrReciveFrom) },
                { name: fld.ChequeRegisterChequeNo, title: txt(fld.ChequeRegisterChequeNo) },
                { name: fld.Amount, title: txt(fld.Amount) }
            ];

        }
    }
}