var alfabetoApp = function (options) {
	var componente = {
		url: '/Home',
	}

	this.construct = function (options) {
		debugger
		options.input = $(options.contenedor).find("#txtPalabra");
		options.spanPalabra = $(options.contenedor).find("#palabra");
		options.spanValorPalabra = $(options.contenedor).find("#valorPalabra");

		$.extend(componente, options);
	}

	this.init = function () {
		componente.input.val('');
		componente.spanPalabra.text('');
		componente.spanValorPalabra.text('');

		componente.contenedor.on('click', '#btnCalcular', function () {
			procesarPalabra()
		})
	}


	var procesarPalabra = function () {
		$.post(componente.url + '/ProcesarPalabra', { palabra: componente.input.val() }, function (respuesta) {
			if (respuesta.valido) {
				componente.spanPalabra.text(respuesta.palabra);
				componente.spanValorPalabra.text(respuesta.sumatoria);
				componente.input.val('')
			} else {
				alert("error inesperado :(")
			}
		})
	}


	this.construct(options)
}