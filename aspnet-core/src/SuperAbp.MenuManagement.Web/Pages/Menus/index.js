(function ($) {
    var l = abp.localization.getResource('SuperAbpMenuManagement');

    var _menuAppService = superAbp.menuManagement.menus.menu;

    var _createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Menus/CreateModal'
    });
    var _editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Menus/EditModal'
    });

    var _dataTable = null;
    function initParams() {
        var date = $('#search_date').val();
        return {
        };
    }
    $(function () {
        var _$wrapper = $('#MenusWrapper');
        var _$table = _$wrapper.find('table');
        _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                order: [[3, 'desc']],
                processing: true,
                serverSide: true,
                searching: false,
                scrollX: true,
                paging: true,
                ajax: abp.libs.datatables.createAjax(_menuAppService.getList, function () {
                    return initParams();
                }),
                columnDefs: [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: [
                                //{
                                //    text: l('View'),
                                //    action: function (data) {
                                //        _detailModal.open({
                                //            id: data.record.id,
                                //        });
                                //    },
                                //},
                                //{
                                //    text: l('Edit'),
                                //    action: function (data) {
                                //        _editModal.open({
                                //            id: data.record.id,
                                //        });
                                //    },
                                //},
                            ]
                        }
                    },
                    {
                        title: l('Name'),
                        data: 'name'
                    },
                    {
                        title: l('Route'),
                        data: 'route',
                    },
                    {
                        title: l('Sort'),
                        data: 'sort',
                    },
                    {
                        title: l('Icon'),
                        data: 'icon',
                    }
                    ,
                    {
                        title: l('Permission'),
                        data: 'permission',
                    }
                    ,
                    {
                        title: l('Group'),
                        data: 'group',
                    },
                    {
                        title: l('HideInBreadcrumb'),
                        data: 'hideInBreadcrumb',
                    },
                    {
                        title: l('ParentName'),
                        data: 'parentName',
                    }
                ]
            })
        );

        $('#CreateNewMenuButtonId').click(function () {
            _createModal.open();
        });

        _createModal.onClose(function () {
            _dataTable.ajax.reload();
        });

        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });
    });
})(jQuery);