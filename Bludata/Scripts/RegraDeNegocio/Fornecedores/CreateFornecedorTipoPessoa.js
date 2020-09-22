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

    $("#Cnpj").hide(); // campo cnpj invisivel
    $("#Cpf").show(); // campo cpf visível
    $("#rg").show();  // campo rg visível
    $("#dataNascimento").show(); // campo Data de nascimento visível

    //requerimento dos campos
    $("#input-cpf").prop('required', true);
    $("#input-rg").prop('required', true);
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

    // caso o usuário escolha pessoa jurídica
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
