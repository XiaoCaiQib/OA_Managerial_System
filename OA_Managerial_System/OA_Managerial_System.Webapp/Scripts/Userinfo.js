$(function () {
    $("#addDiv").css("display", "none");
    $("#editDiv").css("display", "none");
    $("#setUsrRoleDiv").css("display", "none");
    $("#setUsrActionDiv").css("display", "none");
    //给搜索按钮加一个单击事件
    $("#btnSearch").click(function () {
        //获取用户输入的搜索数据.
        var pars = {
            name: $("#txtSearchName").val(),
            remark: $("#txtSearchRemark").val()
        };
        //将获取的搜索的数据发送到服务端。
        loadData(pars)
    });
    loadData();
});
//加载用户列表
function loadData(pars) {
    $('#tt').datagrid({
        url: '/UserInfo/GetUserInfoList',
        title: '用户数据表格',
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
            { field: 'UName', title: '姓名', width: 120 },
            { field: 'UPwd', title: '密码', width: 120 },
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
//为用户分配权限
function showSetUserActionInfo() {
    //判断一下用户是否选择了要修改的数据
    var rows = $('#tt').datagrid('getSelections');//获取所选择的行
    if (rows.length != 1) {
        $.messager.alert("提示", "请选择要分配权限的用户", "error");
        return;
    }
    $("#setUserActionFrame").attr("src", "/UserInfo/ShowUserAction/?userId=" + rows[0].ID);
    $("#setUsrActionDiv").css("display", "block");
    $('#setUsrActionDiv').dialog({
        title: '为用户分配权限数据',
        width: 400,
        height: 300,
        collapsible: true,
        maximizable: true,
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function () {

            }
        }, {
            text: 'Cancel',
            handler: function () {
                $('#setUsrActionDiv').dialog('close');
            }
        }]
    });
}


//为用户配置角色.
function showSetUserRoleInfo() {
    //判断一下用户是否选择了要修改的数据
    var rows = $('#tt').datagrid('getSelections');//获取所选择的行
    if (rows.length != 1) {
        $.messager.alert("提示", "请选择要分配角色的用户", "error");
        return;
    }
    $("#setUserRoleFrame").attr("src", "/UserInfo/ShowUserRoleInfo/?id=" + rows[0].ID);
    $("#setUsrRoleDiv").css("display", "block");
    $('#setUsrRoleDiv').dialog({
        title: '为用户分配角色数据',
        width: 300,
        height: 200,
        collapsible: true,
        maximizable: true,
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function () {
                var childWindow = $("#setUserRoleFrame")[0].contentWindow;
                childWindow.subForm();
            }
        }, {
            text: 'Cancel',
            handler: function () {
                $('#setUsrRoleDiv').dialog('close');
            }
        }]
    });
}
//为用户分配完成角色以后调用的方法。
function afterSetUserRole(data) {
    if (data == "ok") {
        $('#setUsrRoleDiv').dialog('close');
    }

}

//删除数据
function deleteInfo(){
var row=$("#tt").datagrid('getSelections');
if(!row||row.length==0){
$.messager.alert("提示","请选择要删除的行","error")
return;

}else{
$.messager.confirm("提示","确定要删除吗？",function(r){
var rowlength=row.length;
var strId="";
for (var i = 0; i < rowlength; i++){

strId=strId+row[i].ID+","
}
strId= strId.substr(0,strId.length-1);
$.post("/UserInfo/DeleteInfo",{"strID":strId},function(data){

      if(data=="ok"){
        $("#tt").datagrid('reload');
 
      }else{

        $.messager.alert("提示","删除失败","error");
      }
})
})

}

}

function addInfo(){
$("#addDiv").css("display","block");
$("#addDiv").dialog({
title:"AdduserInfo",
width:300,
height:200,
collapsible:true,
modal:true,
buttons:[{
text:"OK",
iconCls:"icon-ok",
handler:function(){
    var control=$("#addfrom");
    validateInfo();
    $("#addfrom").submit();
}
},{
    text:"canel",
    handler:function(){
        $("#addDiv").dialog("close");
    }

}]

})

}
//完成添加后调用该方法
function afterAdd(data){
if(data=="ok"){
 $("#addDiv").dialog("close");
$("#tt").datagrid("reload");
$("#addfrom input").val("");
}

}
//表单校验
function validateInfo() {
    $("#addfrom").validate({//表示对哪个form表单进行校验，获取form标签的id属性的值
        rules: {//表示验证规则
            UName: "required",//表示对哪个表单元素进行校验，要写具体的表单元素的name属性的值
            Remark: {
                required: true
            },
            UPwd: {
                required: true,
                minlength: 1
            },
            Sort: {
                required: true
            }
        },
        messages: {
            UName: "请输入用户名",
            Remark: {
                required: "请输入备注"
            },
            UPwd: {
                required: "请输入密码",
            },
            Sort: {
                required: "请输入排序"
            }
        }
    });
}
//展示一下要修改的数据.
function showEditInfo() {
    //判断一下用户是否选择了要修改的数据
    var rows = $('#tt').datagrid('getSelections');//获取所选择的行
    if (rows.length != 1) {
        $.messager.alert("提示", "请选择要修改的数据", "error");
        return;
    }
    //将要修改的数据查询出来，显示到文本框中。
    var id = rows[0].ID;
    $.post("/UserInfo/ShowEditInfo", { "id": id }, function (data) {
        $("#txtUName").val(data.UName);
        $("#txtUPwd").val(data.UPwd);
        $("#txtRemark").val(data.Remark);
        $("#txtSort").val(data.Sort);
        $("#txtSubTime").val(ChangeDateFormat(data.SubTime));
        $("#txtDelFlag").val(data.DelFlag);
        $("#txtId").val(data.ID);
    });
    $("#editDiv").css("display", "block");
    $('#editDiv').dialog({
        title: '编辑用户数据',
        width: 300,
        height: 200,
        collapsible: true,
        maximizable: true,
        resizable: true,
        modal: true,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function () {
                //表单校验
                validateInfo($("#editForm"));
                $("#editForm").submit();//提交表单
            }
        }, {
            text: 'Cancel',
            handler: function () {
                $('#editDiv').dialog('close');
            }
        }]
    });
}
//更新以后调用该方法.
function afterEdit(data) {
    if (data == "ok") {
        $('#editDiv').dialog('close');
        $('#tt').datagrid('reload');//加载表格不会跳到第一页。
    } else {
        $.messager.alert("提示", "修改的数据失败", "error");
    }
}
//将序列化成json格式后日期(毫秒数)转成日期格式
function ChangeDateFormat(cellval) {
    var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    return date.getFullYear() + "-" + month + "-" + currentDate;
}

