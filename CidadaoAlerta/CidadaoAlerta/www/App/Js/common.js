function WS_CidadaoAlerta() {
    return "http://localhost:61571";
}

//function onSuccessLocation(position) {
//    coordenadas = position;
//}
function onErrorLocation(error) {
    alert('code: ' + error.code + '\n' +
        'message: ' + error.message + '\n');
}
function localizarumavez(callback) {
    navigator.geolocation.getCurrentPosition(callback, onErrorLocation);
}
function localizarsempre() {
    var watchID = navigator.geolocation.watchPosition(onSuccessLocation, onErrorLocation, { maximumAge: 3000, timeout: 5000, enableHighAccuracy: true });
}
function localizarsemprepausar() {
    navigator.geolocation.clearWatch(watchID);
}