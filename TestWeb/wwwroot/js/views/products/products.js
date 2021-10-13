let products = {
    submit: ($obj) => {
        let id = document.getElementById('id').value;
        window.form = $($obj.form);
        window.objValidator = form.validate();
        if (form.valid()) {
            $($obj).button('loading');
            let url = '';
            let data = form.serialize();
            if (id === '0') {
                url = baseUrl + 'Products/Create';
                axios.post(url, data).then((response) => {
                    if (!response.data.error) {
                        $.customConfirmNoCancel('Confirmación!', response.data.msg, function () {
                            $($obj).button('reset');
                            window.location.href = response.data.redirect;
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
            else {
                url = baseUrl + 'Products/Update/' + id;
                axios.put(url, data).then((response) => {
                    if (!response.data.error) {
                        $.customConfirmNoCancel('Confirmación!', response.data.msg, function () {
                            $($obj).button('reset');
                            window.location.href = response.data.redirect;
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
        }
    },
    delete: ($obj, $id) => {
        $($obj).button('loading');
        let url = baseUrl + 'Products/Delete/' + $id;
        $.customConfirm('Confirmación!', '¿Realmente desea borrar este registro?', function () {
            axios.delete(url)
                .then((response) => {
                    if (response.data) {
                        if (!response.data.error) {
                            $.customConfirmNoCancel('Confirmación!', response.data.msg, function () {
                                $($obj).button('reset');
                                window.location.reload();
                            }, true, 'ok', true);
                        } else {
                            $($obj).button('reset');
                            $.errorAlert(response.data.msg, true);
                        }
                    }
                })
                .catch(error => {
                    $($obj).button('reset');
                    $.errorAlert('Error del servidor, por favor contacte al administrador del sistema', true);
                    console.log(error.response)
                });
        }, true, 'alert', true, function () {
            $($obj).button('reset');
        });
    }
}