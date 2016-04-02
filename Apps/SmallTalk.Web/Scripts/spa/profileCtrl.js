(function(){
	'use_strict';
	
	
	var app = angular.module('app', []);
	app.controller('profileController', ['$scope', '$http', profileController]);
	
	function profileController($scope, $http){
		
		$scope.loading = true;
		
<<<<<<< HEAD:Apps/SmallTalk.Web/Scripts/spa/profile/profileCtrl.js
		$scope.get = function(var id){
		
			$http.get('api/profileapi/1').success(function(data){
			
				$scope.profile = data,
				$scope.loading = false;
			})
			.error(function(){
				$scope.error = "An error occured";
				$scope.loading = false;
			});
		};
		
		
		
		
		
		$scope.toggleEdit = function(){
			this.profile.editMode = !this.profile.editMode;
		};
		
		$scope.save = function(){
			$scope.loading = true;
=======
		$http.get('/api/profileapi/1').success(function(data){
>>>>>>> 79bedd8b67ee08759665c97f1588b8593a6b310a:Apps/SmallTalk.Web/Scripts/spa/profileCtrl.js
			
			$http.post("")
		};
	}
})();