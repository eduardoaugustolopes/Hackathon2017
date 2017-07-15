function criaTelaLogin() {
    $("#main").html(
        "<div class='row'>"+
            "<div class='col-md-6 col-md-offset-3'>"+
                "<div class='panel panel-login'>"+
                    "<div class='panel-heading'>"+
                        "<div class='row'>"+
                            "<div class='col-lg-12 text-center'>"+
                                "<a href='#' class='active' id='login-form-link'>Login</a>"+
                            "</div>"+
                        "</div>"+
                        "<hr>"+
                    "</div>"+
                    "<div class='panel-body'>"+
                        "<div class='row'>"+
                            "<div class='col-lg-12'>"+
                                "<form id='login-form' role='form' style='display: block;'>"+
                                    "<div class='form-group'>"+
                                        "<input type='text' name='usuario' id='usuario' class='form-control' placeholder='Usuário' value=''>"+
                                    "</div>"+
                                    "<div class='form-group'>"+
                                        "<input type='password' name='senha' id='senha' class='form-control' placeholder='Senha'>"+
                                    "</div>"+
                                            //"<div class='form-group text-center'>"+
                                            //    "<input type='checkbox' tabindex='3' class='' name='lembrar' id='lembrar'>"+
                                            //    "<label for='remember'> Lembrar Me</label>"+
                                            //"</div>"+
                                            "<div class='form-group'>"+
                                                "<div class='row'>"+
                                                    "<input name='login-submit' id='login-submit' tabindex='4' class='form-control btn btn-login' value='Entrar' onclick='login();'>"+
                                                "</div>"+
                                            "</div>"+
                                        "</div>"+
                                        "<div class='form-group'>"+
                                            "<div class='row'>"+
                                                "<div class='col-lg-12'>"+
                                                    "<div class='text-center'>"+
                                                        "<a tabindex='5' class='forgot-password'>Esqueceu a senha?</a>"+
                                                    "</div>"+
                                                "</div>"+
                                            "</div>"+
                                        "</div>"+
                                "</form>"+
                            "</div>"+
                        "</div>"+
                    "</div>"+
                "</div>"+
            "</div>"+
        "</div>");
}

function login() {
    var dados = {
        grant_type: "password",
        username: $("#usuario").val(),
        password: $("#senha").val()
    };
    $.ajax({
        type: "POST",
        url: WS_CidadaoAlerta() + "/api/security/token",
        data: dados,
        cache: false,
        success: function (retorno) {
            localStorage.setItem("jtoken", retorno.access_token);           
            criarTelaPrincipal();
        },
        error: function (retorno) {
            alert(retorno.responseJSON.error_description);
        }
    });
}