$(function () {

    // máscaras
    $("#input-cpf").inputmask("mask", {
        "mask": "999.999.999-99"
    }, {
            reverse: true
        });

    $("#input-rg").inputmask("mask", {
        "mask": "9.999.999"
    }, {
            reverse: true
        });

    $("#input-telefone").inputmask("mask", {
        "mask": "(99)9999-9999"
    }, {
            reverse: true
        });

    $("#input-cnpj").inputmask("mask", {
        "mask": "99.999.999/9999-99"
    }, {
            reverse: true
        });

    if ($('#input-cnpj').val() == "") {
        $("#Cnpj").hide();
    }
     if ($('#input-cpf').val() == "") {
        $("#Cnpj").show();
        $("#Cpf").hide();
        $("#rg").hide();
        $("#dataNascimento").hide();
    }
});