
$(function () {
    initMap();


});





/////Load Map
function initMap() {
    var myLatLng = { lat: -25.363, lng: 131.044 };

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 4,
        center: myLatLng
    });

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'Hello World!'
    });
}

/////Load City
function LoadCity() {

    var urlLoad = '/Geo/LoadCity';
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: urlLoad,
        data:'',
        dataType: "json",

        success: function (result) {

      
        }
    });
}
