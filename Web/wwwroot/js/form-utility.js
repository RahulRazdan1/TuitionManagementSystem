"use strict";
var FormUtility = (function () {
	var reveal = {};
	reveal.fillCascadingDropdown = function (options) {
		var defaultsettings = {
			mapData: function (responseData) {
				var mappedData = [];
				$.each(responseData, function (_index, lookup) {
					mappedData.push({ value: lookup.key, name: lookup.value });
				});
				return mappedData;
			}
		}
		var settings = $.extend({}, defaultsettings, options);
		$(settings.sourceDropdown).on('change', function () {
			var $element = $(this);
			var sourceId = $element.val();
			$.ajax({
				url: settings.url,
				type: settings.type,
				data: settings.getData(sourceId),
				contentType: 'application/json; charset=utf-8',
				dataType: 'json'
			})
				.then(function (response) {
					var destination = $(settings.destinationDropdown);
					destination.empty();
					destination.append($("<option></option>").val('').html('Select'));
					var mappedData = settings.mapData(response);
					$.each(mappedData, function (_key, lookup) {
						destination.append(
							$("<option></option>").val(lookup.value).html(lookup.name));
					});

				})
				.catch(function (error) {
					console.log(error);
				});
		});
	};
	
	return reveal;

})();