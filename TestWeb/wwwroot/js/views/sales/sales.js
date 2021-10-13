let sales = {
	submit: ($obj) => {
		window.form = $($obj.form);
		window.objValidator = form.validate();
		if (form.valid()) {
			$($obj).button('loading');
			let url = baseUrl + 'Home/Create';
			let data = form.serialize();
			axios.post(url, data).then((response) => {
				if (!response.data.error) {
					$.customConfirmNoCancel('Confirmación!', response.data.msg, function () {
						$($obj).button('reset');
						window.location.reload();
					}, true, 'ok', true);
				} else {
					$($obj).button('reset');
					$.errorAlert(response.data.msg, true);

				}
			}).catch(error => {
				$($obj).button('reset');
				$.errorAlert('Error del servidor, por favor contacte al administrador del sistema', true);
				console.log(error.response)
			});
		}
	},
	showSaleModal: () => {
		$('#salesModal').modal({
			backdrop: 'static',
			keyboard: false
		});
	}
}