
$(function () {
    
    $("#acode").on("click", function () {
        $("#img").attr("src", $("img").attr("src") + 1);
        return false;
    }),
        $("#login").on("click", function () {
        var name = $("#uname").val();
        var pwd = $("#upwd").val();
        var vcode = $("#code").val();
        var logininfo = { name: name, pwd: pwd, vcode: vcode };
        $.ajax({
            url: "login/login",
            type: "Post",
            data: logininfo,
            success: function (data) {
                if (data == "ok") {
                    window.location.href = "/userinfo/index";
                }
                else {
                    window.location.href = "~/error.html";
                }
            }
        })
    })

})