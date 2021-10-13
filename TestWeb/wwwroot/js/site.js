window.baseUrlArg = document.getElementsByTagName('base')[0].href.split('/');
window.barg = [baseUrlArg[0], baseUrlArg[1], baseUrlArg[2]];
window.host = baseUrlArg[0] + '/';
window.baseUrl = barg.join('/') + '/';
window.apiUrl = 'https://localhost:52924';
window.form = undefined;
window.objValidator = undefined;
window.$ = jQuery;
window.$.fn.dataTable.defaults.language = {
	"decimal": ",",
	"thousands": ".",
	"info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
	"infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
	"infoPostFix": "",
	"infoFiltered": "(filtrado de un total de _MAX_ registros)",
	"loadingRecords": "Cargando...",
	"lengthMenu": "Mostrar _MENU_ registros",
	"paginate": {
		"first": "Primero",
		"last": "Último",
		"next": "Siguiente",
		"previous": "Anterior"
	},
	"processing": "Procesando...",
	"search": "Buscar:",
	"searchPlaceholder": "Término de búsqueda",
	"zeroRecords": "No se encontraron resultados",
	"emptyTable": "Ningún dato disponible en esta tabla",
	"aria": {
		"sortAscending": ": Activar para ordenar la columna de manera ascendente",
		"sortDescending": ": Activar para ordenar la columna de manera descendente"
	},
	//only works for built-in buttons, not for custom buttons
	"buttons": {
		"create": "Nuevo",
		"edit": "Cambiar",
		"remove": "Borrar",
		"copy": "Copiar",
		"csv": "fichero CSV",
		"excel": "tabla Excel",
		"pdf": "documento PDF",
		"print": "Imprimir",
		"colvis": "Visibilidad columnas",
		"collection": "Colección",
		"upload": "Seleccione fichero...."
	},
	"select": {
		"rows": {
			_: '%d filas seleccionadas',
			0: 'clic fila para seleccionar',
			1: 'una fila seleccionada'
		}
	}
};
window.$.fn.dataTable.defaults.order = false;
window.$.fn.select2.defaults.set("theme", "bootstrap4");
(function ($) {
	"use strict";
	var path = window.location.href;
	$("#accordionSidebar a.nav-link").each(function () {
		if (this.href === path) {
			$(this).addClass("active");
			$($(this).parent()).addClass("active");
			$.each($($(this).siblings('.collapse')).find('a'), function (index, item) {
				if (item.href === path) {
					$(item).addClass("active");
				}
			});
		}
	});
	window.moment.updateLocale('es', {
		meridiem: function (hour, minute, isLowerCase) {
			if (hour < 12) {
				return 'a.m.';
			} else {
				return 'p.m.';
			}
		}
	});
	$("#sidebarToggle, #sidebarToggleTop").on('click', function (e) {
		$("body").toggleClass("sidebar-toggled");
		$(".sidebar").toggleClass("toggled");
		if ($(".sidebar").hasClass("toggled")) {
			$('.sidebar .collapse').collapse('hide');
		}
	});
	$(window).resize(function () {
		if ($(window).width() < 768) {
			$('.sidebar .collapse').collapse('hide');
		}
		if ($(window).width() < 480 && !$(".sidebar").hasClass("toggled")) {
			$("body").addClass("sidebar-toggled");
			$(".sidebar").addClass("toggled");
			$('.sidebar .collapse').collapse('hide');
		}
	});
	$('body.fixed-nav .sidebar').on('mousewheel DOMMouseScroll wheel', function (e) {
		if ($(window).width() > 768) {
			var e0 = e.originalEvent,
				delta = e0.wheelDelta || -e0.detail;
			this.scrollTop += (delta < 0 ? 1 : -1) * 30;
			e.preventDefault();
		}
	});
	$(document).on('scroll', function () {
		var scrollDistance = $(this).scrollTop();
		if (scrollDistance > 100) {
			$('.scroll-to-top').fadeIn();
		} else {
			$('.scroll-to-top').fadeOut();
		}
	});
	$(document).on('click', 'a.scroll-to-top', function (e) {
		var $anchor = $(this);
		$('html, body').stop().animate({
			scrollTop: ($($anchor.attr('href')).offset().top)
		}, 1000, 'easeInOutExpo');
		e.preventDefault();
	});
	jQuery.validator.setDefaults({
		ignore: ':hidden:not(.do-not-ignore)',
		onfocusout: function (e) {
			this.element(e);
		},
		highlight: function (element) {
			if ($(element).hasClass('wysiwyg-control') || $(element).hasClass('wysiwyg-control-custom')) {
				$(element).next('div').removeClass('is-valid');
				$(element).next().addClass('is-invalid');
			} else
				jQuery(element).closest('.form-control').addClass('is-invalid');
		},
		unhighlight: function (element) {
			if ($(element).hasClass('wysiwyg-control') || $(element).hasClass('wysiwyg-control-custom')) {
				$(element).next('div').removeClass('is-invalid');
				$(element).next('div').addClass('is-valid');
			} else {
				jQuery(element).closest('.form-control').removeClass('is-invalid');
				jQuery(element).closest('.form-control').addClass('is-valid');
			}
		},
		errorElement: 'div',
		errorClass: 'invalid-feedback',
		errorPlacement: function (error, element) {
			if ($(element).hasClass('wysiwyg-control') || $(element).hasClass('select2-hidden-accessible')) {
				error.insertAfter($(element).next());
			} else if (element.parent('.input-group-prepend').length) {
				$(element).siblings(".invalid-feedback").append(error);
				//error.insertAfter(element.parent());
			} else {
				error.insertAfter(element);
			}
		},
	});
	$.fn.button = function (action) {
		if (action === 'loading' && this.data('loading-text')) {
			this.data('original-text', this.html()).html(this.data('loading-text')).prop('disabled', true);
		}
		if (action === 'reset' && this.data('original-text')) {
			this.html(this.data('original-text')).prop('disabled', false);
		}
	}
	$.errorAlert = function ($msg, $bootstrap) {
		$.alert({
			title: 'Error!',
			icon: 'fa fa-exclamation-circle ',
			content: $msg,
			type: 'red',
			typeAnimated: true,
			useBootstrap: $bootstrap,
			boxWidth: '20%'
		});
	}
	$.customConfirm = function (title, msg, $callback, btnOK, state, bootstrap, $cancelCallBack) {
		$cancelCallBack = typeof $cancelCallBack !== 'undefined' ? $cancelCallBack : undefined;
		var options = {};
		if (btnOK) {
			options = {
				Ok: function () {
					if ($callback)
						$callback();
				},
				cerrar: function () {
					if ($cancelCallBack)
						$cancelCallBack();
				}
			};
		}
		else {
			options = {
				cerrar: function () {

				}
			};
		}
		$.confirm({
			title: title,
			content: msg,
			boxWidth: '20%',
			useBootstrap: bootstrap,
			type: state === 'ok' ? 'green' : state === 'alert' ? 'orange' : 'red',
			buttons: options
		});
	}
	$.customConfirmNoCancel = function (title, msg, _callback, btnOK, state, bootstrap, _cancelCallBack) {
		_cancelCallBack = typeof _cancelCallBack !== 'undefined' ? _cancelCallBack : undefined;
		var options = {};
		if (btnOK)
			options = {
				Ok: function () {
					if (_callback)
						_callback();
				}
			};

		$.confirm({
			title: title,
			content: msg,
			boxWidth: '20%',
			useBootstrap: bootstrap,
			type: state === 'ok' ? 'green' : state === 'alert' ? 'orange' : 'red',
			buttons: options
		});
	}
	$.customFormConfirm = function (title, msg, _callback, btnOK, state, bootstrap, _cancelCallBack) {
		var options = {};
		if (btnOK)
			options = {
				formSubmit: {
					text: 'Enviar',
					btnClass: 'btn-blue',
					action: function () {
						window.form = $('#confirm_form_pop')
						window.objValidator = form.validate();
						window.promptValue = this.$content.find('.name').val();
						if (form.valid()) {
							if (_callback)
								_callback();
						} else {
							return false;
						}
					}
				},
				Cancelar: function () {
					if (_cancelCallBack)
						_cancelCallBack();
				}
			};
		else
			options = {
				Cerrar: function () {

				}
			};

		$.confirm({
			title: title,
			content: msg,
			boxWidth: '20%',
			useBootstrap: bootstrap,
			type: state === 'ok' ? 'green' : state === 'alert' ? 'orange' : 'red',
			buttons: options
		});
	}
	$('.money').maskMoney();
	$('[rel=select2]').select2();
	$('[rel=dataTable]').DataTable();

}(jQuery));