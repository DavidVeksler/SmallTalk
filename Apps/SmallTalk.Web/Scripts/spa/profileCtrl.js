(function(){
	'use_strict';
	
	
	var app = angular.module('app', []);
	app.controller('profileController', ['$scope', '$http', profileController]);
	
	function profileController($scope, $http){
		
		$scope.loading = true;
		
		$http.get('/api/profileapi/1').success(function(data){
			
			$scope.profile = data,
			$scope.loading = false;
		})
		.error(function(){
			$scope.error = "An error occured";
			$scope.loading = false;
		});
	}
})();