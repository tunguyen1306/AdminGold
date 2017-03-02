var infoWindow;
var map;
var markers = [];
var mappo;
$(function () {
    LoadPolygon(59, 1);
    GetCity();
    loadmap();
    setInterval(function () {
        GetTracking();
    }, 5000)
  
});

///Load Map
function loadmap() {
    try {

        var mapid = document.getElementById('map');
        map = new google.maps.Map(mapid, {
            zoom: 12,
            center: { lat: 10.76025245, lng: 106.689502 },
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });
   
        GetTracking();
        var t = [{ lat: 11.160161, lng: 106.456955 }, { lat: 11.1558809, lng: 106.469604 }, { lat: 11.1432467, lng: 106.472054 }, { lat: 11.1419792, lng: 106.50621 }, { lat: 11.1213474, lng: 106.524635 }, { lat: 11.108182, lng: 106.5269 }, { lat: 11.1010885, lng: 106.51635 }, { lat: 11.0885506, lng: 106.533844 }, { lat: 11.0746708, lng: 106.523972 }, { lat: 11.0562649, lng: 106.53643 }, { lat: 11.0456123, lng: 106.553459 }, { lat: 11.0513067, lng: 106.575813 }, { lat: 11.0362854, lng: 106.588867 }, { lat: 11.0405741, lng: 106.603165 }, { lat: 11.016613, lng: 106.597511 }, { lat: 11.00637, lng: 106.620712 }, { lat: 10.9921207, lng: 106.615913 }, { lat: 10.9793682, lng: 106.627319 }, { lat: 10.97888, lng: 106.649155 }, { lat: 10.9312754, lng: 106.651756 }, { lat: 10.9212961, lng: 106.684669 }, { lat: 10.898036, lng: 106.694344 }, { lat: 10.8791285, lng: 106.690506 }, { lat: 10.8673038, lng: 106.701561 }, { lat: 10.87168, lng: 106.721443 }, { lat: 10.8942976, lng: 106.716393 }, { lat: 10.8814974, lng: 106.744896 }, { lat: 10.8654289, lng: 106.749313 }, { lat: 10.86727, lng: 106.7622 }, { lat: 10.8915377, lng: 106.766884 }, { lat: 10.8672609, lng: 106.784676 }, { lat: 10.8730507, lng: 106.808487 }, { lat: 10.89838, lng: 106.837891 }, { lat: 10.8471689, lng: 106.854088 }, { lat: 10.81358, lng: 106.881332 }, { lat: 10.78804, lng: 106.86454 }, { lat: 10.7696714, lng: 106.874878 }, { lat: 10.7642078, lng: 106.868484 }, { lat: 10.77534, lng: 106.844315 }, { lat: 10.7600527, lng: 106.828133 }, { lat: 10.777709, lng: 106.825294 }, { lat: 10.7778044, lng: 106.813393 }, { lat: 10.7270269, lng: 106.753693 }, { lat: 10.6977386, lng: 106.75444 }, { lat: 10.6584368, lng: 106.804779 }, { lat: 10.6284494, lng: 106.824547 }, { lat: 10.6477795, lng: 106.8822 }, { lat: 10.6095228, lng: 106.910019 }, { lat: 10.5800753, lng: 106.982338 }, { lat: 10.53047, lng: 106.987343 }, { lat: 10.5203629, lng: 107.012794 }, { lat: 10.4908781, lng: 106.99855 }, { lat: 10.4553862, lng: 107.022675 }, { lat: 10.4280558, lng: 107.018059 }, { lat: 10.4133062, lng: 107.004646 }, { lat: 10.3603439, lng: 106.873863 }, { lat: 10.3776026, lng: 106.82682 }, { lat: 10.4718256, lng: 106.751137 }, { lat: 10.5761213, lng: 106.74575 }, { lat: 10.58732, lng: 106.724159 }, { lat: 10.6060667, lng: 106.71904 }, { lat: 10.6092567, lng: 106.729294 }, { lat: 10.6338387, lng: 106.731369 }, { lat: 10.6442051, lng: 106.723274 }, { lat: 10.6543074, lng: 106.688164 }, { lat: 10.6263351, lng: 106.635918 }, { lat: 10.6578169, lng: 106.607635 }, { lat: 10.6486864, lng: 106.558517 }, { lat: 10.6574326, lng: 106.548935 }, { lat: 10.6818113, lng: 106.551308 }, { lat: 10.688303, lng: 106.533905 }, { lat: 10.7161579, lng: 106.529282 }, { lat: 10.7339773, lng: 106.483849 }, { lat: 10.7565212, lng: 106.463661 }, { lat: 10.78892, lng: 106.504547 }, { lat: 10.8977242, lng: 106.531815 }, { lat: 10.9736071, lng: 106.411911 }, { lat: 10.9700651, lng: 106.37719 }, { lat: 10.9918957, lng: 106.356331 }, { lat: 11.0090189, lng: 106.412682 }, { lat: 11.0911493, lng: 106.426033 }, { lat: 11.1466074, lng: 106.458038 }, { lat: 11.160161, lng: 106.456955 }];
        mappo = new google.maps.Polygon({
            paths: t,
            strokeColor: '#FF0000',
            strokeOpacity: 0.9,
            strokeWeight: 1,
            fillColor: 'ffffff',
            fillOpacity: 0.1
        });

    } catch (e) {

    }

}


function initMap() {
    var mapid = document.getElementById('map');
    map = new google.maps.Map(mapid, {
        zoom: 12,
        center: { lat: 10.76025245, lng: 106.689502 },
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    GetTracking();
    var t = [{lat:11.160161,lng:106.456955},{lat:11.1558809,lng:106.469604},{lat:11.1432467,lng:106.472054},{lat:11.1419792,lng:106.50621},{lat:11.1213474,lng:106.524635},{lat:11.108182,lng:106.5269},{lat:11.1010885,lng:106.51635},{lat:11.0885506,lng:106.533844},{lat:11.0746708,lng:106.523972},{lat:11.0562649,lng:106.53643},{lat:11.0456123,lng:106.553459},{lat:11.0513067,lng:106.575813},{lat:11.0362854,lng:106.588867},{lat:11.0405741,lng:106.603165},{lat:11.016613,lng:106.597511},{lat:11.00637,lng:106.620712},{lat:10.9921207,lng:106.615913},{lat:10.9793682,lng:106.627319},{lat:10.97888,lng:106.649155},{lat:10.9312754,lng:106.651756},{lat:10.9212961,lng:106.684669},{lat:10.898036,lng:106.694344},{lat:10.8791285,lng:106.690506},{lat:10.8673038,lng:106.701561},{lat:10.87168,lng:106.721443},{lat:10.8942976,lng:106.716393},{lat:10.8814974,lng:106.744896},{lat:10.8654289,lng:106.749313},{lat:10.86727,lng:106.7622},{lat:10.8915377,lng:106.766884},{lat:10.8672609,lng:106.784676},{lat:10.8730507,lng:106.808487},{lat:10.89838,lng:106.837891},{lat:10.8471689,lng:106.854088},{lat:10.81358,lng:106.881332},{lat:10.78804,lng:106.86454},{lat:10.7696714,lng:106.874878},{lat:10.7642078,lng:106.868484},{lat:10.77534,lng:106.844315},{lat:10.7600527,lng:106.828133},{lat:10.777709,lng:106.825294},{lat:10.7778044,lng:106.813393},{lat:10.7270269,lng:106.753693},{lat:10.6977386,lng:106.75444},{lat:10.6584368,lng:106.804779},{lat:10.6284494,lng:106.824547},{lat:10.6477795,lng:106.8822},{lat:10.6095228,lng:106.910019},{lat:10.5800753,lng:106.982338},{lat:10.53047,lng:106.987343},{lat:10.5203629,lng:107.012794},{lat:10.4908781,lng:106.99855},{lat:10.4553862,lng:107.022675},{lat:10.4280558,lng:107.018059},{lat:10.4133062,lng:107.004646},{lat:10.3603439,lng:106.873863},{lat:10.3776026,lng:106.82682},{lat:10.4718256,lng:106.751137},{lat:10.5761213,lng:106.74575},{lat:10.58732,lng:106.724159},{lat:10.6060667,lng:106.71904},{lat:10.6092567,lng:106.729294},{lat:10.6338387,lng:106.731369},{lat:10.6442051,lng:106.723274},{lat:10.6543074,lng:106.688164},{lat:10.6263351,lng:106.635918},{lat:10.6578169,lng:106.607635},{lat:10.6486864,lng:106.558517},{lat:10.6574326,lng:106.548935},{lat:10.6818113,lng:106.551308},{lat:10.688303,lng:106.533905},{lat:10.7161579,lng:106.529282},{lat:10.7339773,lng:106.483849},{lat:10.7565212,lng:106.463661},{lat:10.78892,lng:106.504547},{lat:10.8977242,lng:106.531815},{lat:10.9736071,lng:106.411911},{lat:10.9700651,lng:106.37719},{lat:10.9918957,lng:106.356331},{lat:11.0090189,lng:106.412682},{lat:11.0911493,lng:106.426033},{lat:11.1466074,lng:106.458038},{lat:11.160161,lng:106.456955}];
    mappo = new google.maps.Polygon({
        paths:t,
        strokeColor: '#FF0000',
        strokeOpacity: 0.9,
        strokeWeight: 1,
        fillColor: 'ffffff',
        fillOpacity: 0.1
    });
 
}

function LoadPolygon(id,key) {
    var url = "/Geo/GetPolygon";
    var obj = {};
    obj.id = id;
    obj.key = key;
    $.ajax
   ({
       type: "POST",
       url: url,
       data: JSON.stringify(obj),
       dataType: "json",
       contentType: "application/json;charset=utf-8",
       success: function (data) {
           var myJsonString = JSON.stringify(data);
           var t = $.parseJSON(myJsonString);
           mappo.setMap(null);
           mappo = new google.maps.Polygon({
               paths: t,
               strokeColor: '#FF0000',
               strokeOpacity: 0.9,
               strokeWeight: 1,
               fillColor: '#ffffff',
               fillOpacity: 0.1
           });
           mappo.setMap(map);
           infoWindow = new google.maps.InfoWindow;
       }
   });
    

}
function toggleBounce() {
    if (markers.getAnimation() !== null) {
        markers.setAnimation(null);
    } else {
        markers.setAnimation(google.maps.Animation.BOUNCE);
    }
}
function removeMarkers() {
    for (i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }
}
/////Load City
function GetCity() {
    var url = "/Geo/GetCity";
    var stringCity = "<option value=\"0\">Chọn tỉnh/thành</option>";
    $.ajax
   ({
       type: "POST",
       url: url,
       data: '',
       dataType: "json",
       contentType: "application/json;charset=utf-8",
       success: function (data) {
       
           $.each(data, function (i, o) {
               stringCity += "<option value=" + o.IdCity + '_' + o.LatitudeCity + '_' + o.LongtitudeCity + ">" + o.NameCity + "</option>";

           });
           $('.dropCity').html(stringCity);
           $('.dropCity').change(function () {
               var valCity = $(".dropCity option:selected").val();
               var arrCity = valCity.split('_');
               var IdCity = arrCity[0];
               var LatCity = arrCity[1];
               var LongCity = arrCity[2];
               var latlng = new google.maps.LatLng(LatCity, LongCity);
               map.setCenter(latlng);
               LoadPolygon(IdCity,1);
               map.setZoom(9);
               GetDistrict(IdCity);
               if (IdCity == 0) {
                   LoadPolygon(59, 1);
                   $('.divDistrict').addClass('hidden');
                   GetWard(0);
                   $('.divWard').addClass('hidden');
               }
               else {
                   $('.divDistrict').removeClass('hidden');
               }
           });
       }
   });
}

/////Load District
function GetDistrict(_id) {
   
    var url = "/Geo/GetDistrict";
    var stringCity = "<option value=\"0\">Chọn quận/huyện</option>";

    var obj = {};
    obj.id = _id;
    $('.dropDistrict').html('');
    $.ajax
   ({
       type: "POST",
       url: url,
       data: JSON.stringify(obj),
       dataType: "json",
       contentType: "application/json;charset=utf-8",
       success: function (data) {

           $.each(data, function (i, o) {

               stringCity += "<option value=" + o.IdDistrict + '_' + o.LatitudeDistrict + '_' + o.LongtitudeDistrict + ">" + o.NameDistrict + "</option>";

           });
           $('.dropDistrict').html(stringCity);
           $('.dropDistrict').change(function () {
               var valDistrict = $(".dropDistrict option:selected").val();
               var arrDistrict = valDistrict.split('_');
               var IdDistrict = arrDistrict[0];
               var LatDistrict = arrDistrict[1];
               var LongDistrict = arrDistrict[2];
               var latlng = new google.maps.LatLng(LatDistrict, LongDistrict);
               map.setCenter(latlng);
               //removeMarkers();
               //markers.setPosition(latlng);
               //markers.setMap(map);
               map.setCenter(latlng);
               map.setZoom(12);
               GetWard(IdDistrict);
               LoadPolygon(IdDistrict, 2);
               if (IdDistrict == 0) {
                   $('.divWard').addClass('hidden');
               }
               else {
                   $('.divWard').removeClass('hidden');
               }
           });
       }
   });
}

/////Load Ward
function GetWard(_id) {
    var url = "/Geo/GetWard";
    var stringCity = "<option value=\"0\">Chọn phường/xã</option>";
 
    var obj = {};
    obj.id = _id;
    $('.dropWard').html('');
    $.ajax
   ({
       type: "POST",
       url: url,
       data: JSON.stringify(obj),
       dataType: "json",
       contentType: "application/json;charset=utf-8",
       success: function (data) {
           $.each(data, function (i, o) {
               stringCity += "<option value=" + o.IdWard + '_' + o.LatitudeWard + '_' + o.LongtitudeWard + ">" + o.NameWard + "</option>";
           });
           $('.dropWard').html(stringCity);
           $('.dropWard').change(function () {
               var valWard = $(".dropWard option:selected").val();
               var arrWard = valWard.split('_');
               var IdWard = arrWard[0];
               var LatWard = arrWard[1];
               var LongWard = arrWard[2];
               var latlng = new google.maps.LatLng(LatWard, LongWard);
               map.setCenter(latlng);
               //removeMarkers();
               //markers.setPosition(latlng);
               //markers.setMap(map);
               map.setCenter(latlng);
               map.setZoom(14);
               LoadPolygon(IdWard, 3);
           });
       }
   });
}
/////Load CreateMarker
function CreateMarker(text,latlong)
{
    removeMarkers();
    markers = new google.maps.Marker({
        map: map,

        draggable: true,
        animation: google.maps.Animation.DROP,
        position: latlong,
        label: {
            color: 'red',
            fontWeight: 'bold',
            text: text,
        },
        icon: {
            labelOrigin: new google.maps.Point(11, 50),
            url: 'http://bus.vangia.net/img/iconbus.png',
            origin: new google.maps.Point(0, 0),
            anchor: new google.maps.Point(11, 40),
        }

    });
    return markers;
}
/////Load Tracking
function GetTracking() {
    var url = "/Geo/GetPositionBus";
    
    removeMarkers();
    $.ajax
   ({
       type: "POST",
       url: url,
       data: '',
       dataType: "json",
       contentType: "application/json;charset=utf-8",
       success: function (data) {
           console.log(data.length);
           $.each(data, function (i, o) {
              
               var lat = JSON.stringify(o.Lat);
               var lng = JSON.stringify(o.lng);
               var latlng = new google.maps.LatLng(lat, lng);
              
               if (markers == null || markers=='') {
                   CreateMarker(o.MaXe, latlng).setMap(map);
               } else {
                   
                   markers.setPosition(latlng);
                   markers.setMap(map);
               }
               
           });
           
       }
   });
}
