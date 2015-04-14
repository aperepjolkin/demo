app.service("angularService", function ($http) {

    this.getRate = function () {
        return $http.get("/Home/GetRates");
    };

    //Save (Update)  
    this.update = function (rate) {
        var response = $http({
            method: "post",
            url: "/Home/UpdateRates",
            data: JSON.stringify(rate),
            dataType: "json"
        });
        return response;
    }

    //Delete 
    this.Delete = function (rateID) {
        var response = $http({
            method: "post",
            url: "/Home/Delete",
            params: {
                id: rateID
            }
        });
        return response;
    }

    //Add 
    this.Add = function (rate) {
        var response = $http({
            method: "post",
            url: "/Home/Add",
            data: JSON.stringify(rate),
            dataType: "json"

        });
        return response;
    }

});