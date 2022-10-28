'use strict';

$(function () {
	FormUtility.fillCascadingDropdown({
		sourceDropdown: '#subjects',
		getData: function (subjectId) {
			return { subjectId: subjectId }
		},
		url: '/Tutee/Add?handler=courses',
		type: 'GET',
		destinationDropdown: "#courses",
	});	
	//FormUtility.fillCascadingDropdown({
	//	sourceDropdown: '#subjects',
	//	getData: function (sourceId) {
	//		return { stateId: sourceId }
	//	},
	//	url: '/Identity/RegisterCarrier?handler=courses',
	//	type: 'GET',
	//	destinationDropdown: "#courses",
	//});
});
