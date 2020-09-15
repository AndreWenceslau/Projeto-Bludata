$(function () {

    $("#Cnpj").hide();
    $("#Cpf").hide();
    $("#rg").hide();
    $("#dataNascimento").hide();
    //checkbox para escolher o tipo da pessoa. 
    $("#checkbox-pessoa-fisica").on('click', function () {
        $("#Cnpj").hide();
        $("#Cpf").show();
        $("#rg").show();
        $("#dataNascimento").show();
        //$("#validacao-cnpj").prop('disabled', true);
       



    });

    $("#checkbox-pessoa-juridica").on('click', function () {
        $("#Cpf").hide();
        $("#rg").hide();
        $("#dataNascimento").hide();
        $("#Cnpj").show();
    });


});
