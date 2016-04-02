(function(){
	'use_strict';
	
	
	var app = angular.module('app', []);
	app.controller('languageController', ['$scope', '$http', languageController]);
	
	function languageController($scope, $http){
		
		$scope.loading = true;
		
		$http.get('/api/languageapi/').success(function(data){
			
			$scope.language = data,
			$scope.loading = false;
		})
		.error(function(){
			$scope.error = "An error occured";
			$scope.loading = false;
		});
	}
})();