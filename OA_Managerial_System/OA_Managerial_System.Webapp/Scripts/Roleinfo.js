$(function () {
    $("#addDiv").css("display", "none");
    loadData();
});
//加载用户列表
function loadData(pars) {
    $('#tt').datagrid({
        url: '/RoleInfo/GetRoleInfoList',
        title: '角色数据表格',
        width: 700,
        height: 400,
        fitColumns: true, //列自适应
        nowrap: false,
        idField: 'ID',//主键列的列明
        loadMsg: '正在加载角色的信息...',
        pagination: true,//是否有分页
        singleSelect: false,//是否单行选择
        pageSize: 5,//页大小，一页多少条数据
        pageNumber: 1,//当前页，默认的
        pageList: [5, 10, 15],
        queryParams: pars,//往后台传递参数
        columns: [[//c.UserName, c.UserPass, c.Email, c.RegTime
            { field: 'ck', checkbox: true, align: 'left', width: 50 },
            { field: 'ID', title: '编号', width: 80 },
            { field: 'RoleName', title: '角色名称', width: 120 },
            { field: 'Sort', title: '排序', width: 120 },
            { field: 'Remark', title: '备注', width: 120 }
          
        ]],
        toolbar: [{
            id: 'btnDelete',
            text: '删除',
            iconCls: 'icon-remove',
            handler: function () {

                deleteInfo();
            }
        }, {
            id: 'btnAdd',
            text: '添加',
            iconCls: 'icon-add',
            handler: function () {

                addInfo();
            }
        }, {
            id: 'btnEidt',
            text: '编辑',
            iconCls: 'icon-edit',
            handler: function () {

                showEditInfo();
            }
        }, {
            id: 'btnSetUserRole',
            text: '为用户分配角色',
            iconCls: 'icon-edit',
            handler: function () {

                showSetUserRoleInfo();
            }
        }, {
            id: 'btnSetUserAction',
            text: '为用户分配权限',
            iconCls: 'icon-edit',
            handler: function () {

                showSetUserActionInfo();
            }
        }],
    });
};
function addInfo() {
    $("#addDiv").css("display", "block");
    $("#addDiv").dialog({
        title: "Addroleinfo",
        width: 300,
        height: 200,
        collapsible: true,
        modal: true,
        buttons: [{
            text: "OK",
            iconCls: "icon-ok",
            handler: function () {
                var control = $("#addfrom");
                $("#addfrom").submit();
            }
        }, {
            text: "canel",
            handler: function () {
                $("#addDiv").dialog("close");
            }

        }]

    })

}
//完成添加后调用该方法
function afterAdd(data) {
    if (data == "ok") {
        $("#addDiv").dialog("close");
        $("#tt").datagrid("reload");
        $("#addfrom input").val("");
    }

}