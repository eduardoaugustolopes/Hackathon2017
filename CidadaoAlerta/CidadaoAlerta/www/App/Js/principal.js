function criarTelaPrincipal() {
    $("#main").html(
        "<nav>"+
            "<div class='nav-wrapper'>"+
                "<a class='brand-logo'>Lista de Ocorrências</a>"+
                "<a data-activates='menu-mobile' class='button-collapse'>"+
                    "<i class='fa fa-bars'></i>"+
                "</a>"+
                "<ul class='right hide-on-med-and-down'>"+
                    "<li><a href='#'>Ocorrências</a></li>"+
                    "<li><a href='tel:3732619150'>Emergências</a></li>"+
                    "<li><a href='#'>Polícia Militar</a></li>"+
                    "<li><a href='#'>Polícia Ambiental</a></li>"+
                    "<li><a href='#'>Polícia Cívil</a></li>"+
                "</ul>"+
                "<ul class='side-nav' id='menu-mobile'>"+
                    "<li><a href='#'>Ocorrências</a></li>"+
                    "<li><a href='tel:37988174539'>Emergências</a></li>"+
                    "<li><a href='#'>Polícia Militar</a></li>" +
                    "<li><a href='#'>Polícia Ambiental</a></li>" +
                    "<li><a href='#'>Polícia Cívil</a></li>" +
                "</ul>"+
                "<ul class='side-nav' id='menu-mobile'>"+
                    "<li><a onclick='criaTelaIncluirDelito();'>Nova Ocorrência</a></li>"+
                "</ul>"+
            "</div>"+
        "</nav>"+
        "<div id='conteudo' class='container' style='padding-botton: 10px'>"+
            "<table id='tabelaOcorrencias'>"+
                "<thead>"+
                    "<tr>"+
                        "<th>Data</th>"+
                        "<th>Descrição</th>"+
                    "</tr>"+
                "</thead>"+
                "<tbody>"+
                    "<tr>"+
                        "<td>15/07/2017</td>"+
                        "<td>Carro roubado</td>"+
                    "</tr>"+
                "</tbody>"+
            "</table>"+
        "</div>"
    );
    $(".button-collapse").sideNav({
        closeOnClick: true // Closes side-nav on <a> clicks, useful for Angular/Meteor
    });

    getOcorrencias();
}

function getOcorrencias() {
    $.xhr = $.ajax({
        type: "POST",
        url: WS_CidadaoAlerta() + "/Api/Ocorrencia/Get",
        cache: false,
        contentType: "application/json",
        headers: { "Authorization": "Bearer " + localStorage.getItem("jtoken") },
        success: function (retorno) {
            preencheTabelaOcorrencias(retorno.ListaOcorrencias);
        },
        error: function (retorno) {
            alert(JSON.parse(retorno.responseText).Message);
        }
    });
}

function preencheTabelaOcorrencias(Ocorrencias) {

    $("#tabelaOcorrencias > tbody").empty();
    for (var i = 0; i < Ocorrencias.length; i++) {
        var descricao = Ocorrencias[i].Descricao;
        var data = new Date(Ocorrencias[i].Data).toLocaleDateString();
        
        $("#tabelaOcorrencias > tbody").append(
            "<tr id='" + Ocorrencias[i].Id + "' onclick='onClickOcorrencia(" + Ocorrencias[i].Id + ")'>" +
                "<td>" + data + "</td>" +
                "<td>" + descricao + "</td>" +
            "</tr>");
    }
}

function onClickOcorrencia(id) {
    $.xhr = $.ajax({
        type: "GET",
        url: WS_CidadaoAlerta() + "/Api/Ocorrencia/GetPorId?ocorrenciaId=" + id,
        contentType: "application/json",
        headers: { "Authorization": "Bearer " + localStorage.getItem("jtoken") },
        success: function (retorno) {
            alert("ok");
        },
        error: function (retorno) {
            alert(JSON.parse(retorno.responseText).Message);
        }
    });
}

function desenhaTelaOcorrencia(ocorrencia) {
    $("#conteudo").html(
        "<div id='exibeOcorrencia'  class='container' style='padding-top: 100px'>" +
            "<form class='form-horizontal'>" +
                "<div class='form-group'>" +
                    "<label class='col-sm-2' for='descricao'>Descrição</label>" +
                    "<div class='col-sm-10'>" +
                        "<p class='form-control-static'>" + ocorrencia.descricao + "</p > " +
                    "</div>" +

                    "<label class='col-sm-2' for='data'>Data</label>" +
                    "<div class='col-sm-10'>" +
                        "<p class='form-control-static'>" + ocorrencia.data + "</p>" +
                    "</div>" +

                    "<label class='col-sm-2' for='tipo'>Tipo de ocorrência</label>" +
                    "<div class='col-sm-10'>" +
                        "<p class='form-control-static'>" + ocorrencia.tipo + "</p>" +
                    "</div>" +
                "</div>" +
            "</form> " +
        "</div>"
    );
}

function retornaDescricaoTipoOcorrencia(tipo) {
    if (tipo == 1) {
        return "Assalto"
    } else if (tipo == 2) {
        return "Indivíduo Suspeito"
    } else if (tipo == 3) {
        return "Briga"
    }
}

function retornaDescricaoTipoItem(tipo) {
    if (tipo == 1) {
        return "Carro"
    } else if (tipo == 2) {
        return "Casa"
    } else if (tipo == 3) {
        return "Pessoa"
    }
}