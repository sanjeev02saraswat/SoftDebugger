
$(document).ready(function () {

    $("#CustomerMobile,#ISD,#PopupPhoneNo,#PopupISD,#PopupISD1,#PopupISD2,#PopupISD3,#PopupPhoneNo1,#PopupPhoneNo2,#PopupPhoneNo3").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A, Command+A
             (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right, down, up
             (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }



    });

    $("#btnsubmitresult,#btnsubmitresult1").click(function (e) {
        debugger;
        //e.preventdefault();
        SaveEnquiry();
    });
});


function ValidateContactusEnquiryForm() {
    var flag = true;
    debugger;
    if ($("#CustomerName").val() == "") {
        $("#CustomerName").addClass("errorClass");
        flag = false;
    }

    if ($("#CustomerCompany").val() == "") {
        $("#CustomerCompany").addClass("errorClass");
        flag = false;
    }

    if ($("#CustomerMobile").val() == "") {
        $("#CustomerMobile").addClass("errorClass");
        flag = false;
    }

    if ($("#Email").val() == "") {
        $("#Email").addClass("errorClass");
        flag = false;
    }
    
   
    if ($("#CustomerMessage").val() == "") {
        $("#CustomerMessage").addClass("errorClass");
        flag = false;
    }
    if ($("#ddlCountry")[0].selectedIndex == 0) {
        $("#ddlCountry").addClass("errorClass");
        flag = false;
    }
    
    var validemail = true;
    if ($("#Email").val() != "") {
        var email = $("#Email").val();
        validemail = isEmail(email);
    }

    if (validemail == false && flag == false) {
        $("#contactusspnerrormessage").css("display", "block");
        $("#contactusspnemailmessage").css("display", "block");
    }
    else if (validemail == false) {
        flag = false;
        $("#contactusspnemailmessage").css("display", "block");
    }
    else if (flag == false) {
        $("#contactusspnerrormessage").css("display", "block");
    }   
    return flag;

}

//google map
function initialize() {
    //define map
    var map;
    //lat lng
    myLatlng = new google.maps.LatLng(16.8496189, 96.1288854);
    //define style
    var styles = [
        {
            //set all color
            featureType: "all",
            stylers: [{ hue: "#35a9d8" }]
        },
        {
            //hide business
            featureType: "poi.business",
            elementType: "labels",
            stylers: [{ visibility: "off" }]
        }
    ];
    //map options
    var mapOptions = {
        zoom: 16,
        center: myLatlng,
        mapTypeControlOptions: { mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style'] },
        panControl: false, //hide panControl
        zoomControl: true, //hide zoomControl
        mapTypeControl: false, //hide mapTypeControl
        scaleControl: false, //hide scaleControl
        streetViewControl: false, //hide streetViewControl
        overviewMapControl: false, //hide overviewMapControl
    }
    //adding attribute value
    map = new google.maps.Map(document.getElementById('templatemo_contact_map'), mapOptions);
    var styledMap = new google.maps.StyledMapType(styles, { name: "Styled Map" });
    map.mapTypes.set('map_style', styledMap);
    map.setMapTypeId('map_style');
    //add marker
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Welcome to Yangon'
    });
}
google.maps.event.addDomListener(window, 'load', initialize);
google.maps.event.addDomListener(window, 'resize', initialize);






