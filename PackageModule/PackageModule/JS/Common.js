//This function will call when session or Token will finish
function SessionEndManager() {
    window.location.href = "/Admin/Home/Signup";
}
//this function will check textbox blank value
function BlankChecker(IDCollection) {
    
    var status = true;
    for (var i = 0; i < IDCollection.length; i++) {
        if ($("#" + IDCollection[i]).val() == "") {
            status = false;
            $("#" + IDCollection[i]).addClass("errorClass");
        }
    }
    return status;
}