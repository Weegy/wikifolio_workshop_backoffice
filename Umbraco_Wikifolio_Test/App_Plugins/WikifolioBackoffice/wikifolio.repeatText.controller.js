angular.module("umbraco").controller("wikifolio.repeatText.controller", function ($scope) {

    if (!angular.isArray($scope.model.value.savedItems)) {
        $scope.model.value.savedItems = [];
    }

    $scope.saveTheItem = function () {
        this.model.value.savedItems.push(this.model.value.newText);
        this.model.value.newText = "";
    };
});