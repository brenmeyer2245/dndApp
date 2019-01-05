var DnDApp = DnDApp || {};
console.log("Hello!!!");
DnDApp.Ajax = (function () {

    var ajaxGet = function(url, success, failure) {
        var request = new XMLHttpRequest();
        request.open('GET', url, true);

        request.onload = function () {
            if (request.status >= 200 && request.status <= 400) {
                success(request.statusText)
            } else {
                failure(request.statusText)
            }
        }
        console.log("Here?")
        request.send();
    }

    var ajaxReload = function (message) {
        location.reload();
    }
    var ajaxfailure = (message) => {
        console.log(message);
    }

    return {
        Init: function () { },
        ChangeCharacterNameToBrendan: function (characterId) {
            ajaxGet('/api/CharacterApi/ChangePlayerNameBrendan/' + characterId, ajaxReload, ajaxfailure)
        }

    }
})()
