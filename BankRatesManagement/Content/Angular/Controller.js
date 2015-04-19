app.controller("BankRatesCtrl", function ($scope, angularService) {
    $scope.divRateModification = false;
    $scope.addNew = false;
    $scope.rates = [];
    GetAllRates();
   
    $scope.editingData = [];

    for (var i = 0, length = $scope.rates.length; i < length; i++) {
        $scope.editingData[$scope.rates[i].RateID] = false;
    }

    //To Get All Records  
    function GetAllRates() {
        var Data = angularService.getRate();
        Data.then(function (rate) {
            $scope.rates = rate.data;
        }, function () {
            alert('Error');
        });
    }

    $scope.edit = function (rate) {
        $scope.editingData[rate.RateID] = true;
        $scope.RateID = rate.RateID;
        $scope.Name = rate.Name;
        $scope.Value = rate.Value;
        $scope.Operation = "Update";
        $scope.divRateModification = true;
    }

    $scope.add = function () {
        $scope.RateID = "";
        $scope.RateName = "";
        $scope.RateValue = "";
        $scope.Operation = "Add";
        $scope.addNew = true;
    }

    $scope.save = function (rate) {
       
        var Rate = {
            RateID: rate.RateID,
            Name: rate.Name,
            Value: rate.Value
        };
        var Operation = $scope.Operation;

        if (Operation == "Update") {
            var getMSG = angularService.update(Rate);
            getMSG.then(function (messagefromController) {
                GetAllRates();
                alert(messagefromController.data);
                $scope.divRateModification = false;
            }, function () {
                alert('Update Error');
            });
        }
        else {
            var getMSG = angularService.Add(Rate);
            getMSG.then(function (messagefromController) {
                GetAllRates();
                alert(messagefromController.data);
                $scope.divRateModification = false;
                $scope.addNew = false;
            }, function () {
                alert('Insert Error');
            });
        }
        $scope.editingData[rate.RateID] = false;
    }

    $scope.delete = function (rate) {
        alert(rate.RateID);
        var getMSG = angularService.Delete(rate.RateID);
        getMSG.then(function (messagefromController) {
            GetAllRates();
            alert(messagefromController.data);
        }, function () {
            alert('Delete Error');
        });
    }
});