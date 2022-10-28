"use script";

$(function () {
	$(".js-status").on('click', toggleUserStatus);

});
var toggleUserStatus = function (event) {
	event.preventDefault();
	var $element = $(this);
	var isActive = $element.data("activate").toLowerCase() == "true";
	var linkText = isActive ? "De Activating..." : 'Activating...';
	$element.html(linkText);
	$element.off('click', () => { return false; });
	var profileId = $element.data("id");
	$.ajax({
		url: '/Identity/ChangeStatus',
		type: 'POST',
		data: { profileId } ,
		headers: {
			"RequestVerificationToken":
				$('input[name="__RequestVerificationToken"]').val()
		}
		
	})
		.then(function (response) {
			var name = $.data('name');
			var path = `${window.location.pathname}?msg=${name} `;
			location.href = path;
			//isActive = !isActive;
			//var text = isActive ? "De Activate" : "Activate";
			//$element.html(text);
		})
		.catch(function (error) {
			var text = isActive ? "De Activate" : "Activate";
			$element.html(text);
			console.log(error);
		})
		
}

