// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    toastr.options.positionClass = 'toast-top-right';
    toastr.options.extendedTimeOut = 0; //1000;
    toastr.options.timeOut = 1000;
    //toastr.options.fadeOut = 250;
    //toastr.options.fadeIn = 250;
});

var sms = new function () {
    function GetMessage(genericResult) {
        if (genericResult == null || typeof genericResult != "object") return "";
        if (typeof genericResult.EnumResultType != "number") return "";

        var msg = "";
        if (typeof genericResult.Data == "string") msg += genericResult.Data;

        if (genericResult.MessageList != null && typeof genericResult.MessageList == "object")
            for (var i = 0; i < genericResult.MessageList.length; i++)
                msg += (i > 0 ? "<br/>" : "") + genericResult.MessageList[i];

        return msg;
    }
    this.toastGenericResult = function (result) {
        if (typeof result != "object") return;
        if (typeof result.EnumResultType != "number") return;
        /*  Success = 1,
        Error = 2,
        Warning = 3,
        UserSafeError = 4*/

        switch (result.EnumResultType) {
            case 1: toastr.success(GetMessage(result), "Success");
                break;
            case 2: toastr.error("An error occurred.", "Error");
                break;
            case 2: toastr.warning(GetMessage(), "Warning");
                break;
            case 4: toastr.error(GetMessage(result), "Error");
                break;
            default:
        }
    }
}();