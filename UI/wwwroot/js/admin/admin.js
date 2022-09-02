$(() => {
	$('body').on('click', '.delete-object-button', function (clickEvent) {
		var result = confirm('Вы уверены, что хотите безвозвратно удалить объект?');
		if (!result) {
			clickEvent.stopImmediatePropagation();
			clickEvent.preventDefault();
		}
	});
});
