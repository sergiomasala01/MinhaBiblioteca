$(document).ready(function () {
    $('#cep').mask('00000-000');
    $('#phone_with_ddd').mask('(00) 00000-0000');
    $('#cpf').mask('000.000.000-00', {reverse: true });
});
