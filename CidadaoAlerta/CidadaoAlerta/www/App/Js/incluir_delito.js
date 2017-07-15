function criaTelaIncluirDelito(){
    $('#conteudo').html(
        "<div class='row'>" +
            "<div class='input-field col s12'>"+
                "<select id='TipoOcorrencia'>"+
                    "<option value='' disabled selected>Escolha uma Opção</option>"+
                    "<option value='1'>Assalto</option>"+
                    "<option value='2'>Indivíduo Suspeito</option>"+
                    "<option value='3'>Briga</option>"+
                "</select>"+
                "<label>O que aconteceu?</label>"+
            "</div>" +
        "</div>"+

        "<div class='row'>" +
            "<div class='input-field col s12'>" +
                "<select id='TipoItem'>" +
                    "<option value='' disabled selected>Escolha uma Opção</option>" +
                    "<option value='1'>Carro</option>" +
                    "<option value='2'>Casa</option>" +
                    "<option value='3'>Pessoa</option>" +
                "</select>" +
                "<label>O que aconteceu?</label>" +
            "</div>" +
        "</div>" +

        "<div class='row'>"+
            "<div class='input-field col s12'>"+
                "<textarea id='Descricao' class='materialize-textarea'></textarea>"+
                "<label for='textarea1'>Descrição</label>"+
            "</div>"+
        "</div>" + 

        "<div class='row'>" +
            "<button class='btn waves-effect waves-light' type='submit' name='action' onclick='cadastraOcorrencia();'>Confirmar</button>" +
        "</div>"
    );

    $('#TipoOcorrencia').material_select();
    $('#TipoItem').material_select();
}

function cadastraOcorrencia() {
    localizarumavez(executaCadastraOcorrencia);
}

function executaCadastraOcorrencia(position) {
    $.ajax({
        type: "POST",
        url: WS_CidadaoAlerta() + "/Api/Ocorrencia/Create",
        data: JSON.stringify(retornaDadosTelaOcorrencia(position)),
        cache: false,
        contentType: "application/json;charset=utf-8",
        headers: { "Authorization": "Bearer " + localStorage.getItem("jtoken") },
        success: function (retorno) {
            if (retorno.Type == "Success") {
                alert("Ocorrência informada!");
            }
            else {
                alert(retorno.Message);
            }
        },
        error: function (retorno) {
            alert(JSON.parse(retorno.responseText).Message);
        }
    });
}

function retornaDadosTelaOcorrencia(position) {
    
    data = {
        TipoOcorrencia: $("#TipoOcorrencia").val(),
        TipoItem: $("#TipoItem").val(),
        Descricao: $("#Descricao").val(),
        Latitude: position.coords.latitude,
        Longitude: position.coords.longitude
    }

    return data;
}