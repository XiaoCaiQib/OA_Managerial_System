$(function () {
    $("#addDiv").css("display", "none");
    loadData();
});
function afterAdd(data) {
    if (data == "ok") {
        $('#addDiv').dialog('close');
        $("#tt").datagrid('reload');
        $("#addfrom input").val("");
    }
}
//加载用户列表
function loadData(pars) {
    $('#tt').datagrid({
        url: '/Roleinfo/GetRoleinfoList',
        title: '角色数据表格',
        width: 700,
        height: 400,
        fitColumns: true, //列自适应
        nowrap: false,
        idField: 'ID',//主键列的列明
        loadMsg: '正在加载用户的信息...',
        pagination: true,//是否有分页
        singleSelect: false,//是否单行选择
        pageSize: 5,//页大小，一页多少条数据
        pageNumber: 1,//当前页，默认的
        pageList: [5, 10, 15],
        queryParams: pars,//往后台传递参数
        columns: [[//c.UserName, c.UserPass, c.Email, c.RegTime
            { field: 'ck', checkbox: true, align: 'left', width: 50 },
            { field: 'ID', title: '编号', width: 80 },
            { field: 'RoleName', title: '姓名', width: 120 },
            { field: 'Remark', title: '备注', width: 120 },
            {
                field: 'SubTime', title: '时间', width: 80, align: 'right',
                formatter: function (value, row, index) {
                    return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d");
                }
            }
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
}

//删除数据
function deleteInfo() {
    var row = $("#tt").datagrid('getSelections');
    if ( row.length != 1) {
        $.messager.alert("提示", "请选择要删除的行", "error")
        return;

    }
    else {
        $.messager.confirm("提示", "确定要删除吗？", function (r) {
    
            strId = row[0].ID;
            $.post("/RoleInfo/DeleteInfo", { "strID": strId }, function (data) {

                if (data == "ok") {
                    $("#tt").datagrid('reload');

                } else {

                    $.messager.alert("提示", "删除失败", "error");
                }
            })
        })

    }

}
function addInfo() {
    $("#addDiv").css("display", "block");
    $("#addDiv").dialog({
        title: "AddRoleInfo",
        width: 300,
        height: 200,
        collapsible: true,
        modal: true,
        buttons: [{
            text: "OK",
            iconCls: "icon-ok",
            handler: function () {
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
