$(function () {
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
    $("#Cnpj").hide();
    $("#Cpf").show();
    $("#input-cpf").prop('required', true);
    $("#rg").show();
    $("#input-rg").prop('required', true);
    $("#dataNascimento").show();
    $("#input-dataNascimento").prop('required', true);
    //checkbox para escolher o tipo da pessoa. 
    $("#checkbox-pessoa-fisica").on('click', function () {
        $("#Cnpj").hide();
        $("#Cpf").show();
        $("#rg").show();
        $("#dataNascimento").show();
        $("#input-cnpj").val("");
        //$("#validacao-cnpj").prop('disabled', true);
    });

    $("#checkbox-pessoa-juridica").on('click', function () {
        $("#Cpf").hide();
        $("#rg").hide();
        $("#dataNascimento").hide();
        $("#Cnpj").show();
        $("#input-cpf").val("");
        $("#input-rg").val("");
        $("#input-dataNascimento").val("");
        $("#input-cnpj").prop('required', true);
    });
});
