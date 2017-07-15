function criaTelaIncluirDelito(){
    $('#main').html(
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

        //"<div class='row'>"+
            "<form class='col s12'>"+
                "<div class='row'>"+
                    "<div class='input-field col s12'>"+
                        "<textarea id='textarea1' class='materialize-textarea'></textarea>"+
                        "<label for='textarea1'>Descrição</label>"+
                    "</div>"+
                "</div>"+
            "</form>"+
        "</div>"
    );

    $('#TipoOcorrencia').material_select();
    $('#TipoItem').material_select();
}