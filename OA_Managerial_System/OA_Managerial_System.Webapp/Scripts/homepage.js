$(function () {
    bindClickEvent();
});
function bindClickEvent() {
    $(".detailLink").click(function () {
        var title = $(this).text();
        var url = $(this).attr("url");
        var isExt = $('#tt').tabs('exists', title);
        if (isExt) {
            $('#tt').tabs('select', title);
            return;
        }
        $('#tt').tabs('add', {
            title: title,
            content: showContent(url),
            closable: true
        });

    });
}
function showContent(url) {
    var str = '<iframe src="' + url + '" width="100%" height="100%" frameborder="0"></iframe>';
    return str
}