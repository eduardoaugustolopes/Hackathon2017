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
                "</ul>"+
                "<ul class='side-nav' id='menu-mobile'>"+
                    "<li><a onclick='criaTelaIncluirDelito();'>Nova Ocorrência</a></li>"+
                "</ul>"+
            "</div>"+
        "</nav>"+
        "<div id='conteudo' class='container' style='padding-botton: 10px'>"+
            "<table>"+
                "<thead>"+
                    "<tr>"+
                        "<th>Descrição</th>"+
                        "<th>Data</th>"+
                        "<th>Categoria</th>"+
                    "</tr>"+
                "</thead>"+
                "<tbody>"+
                    "<tr>"+
                        "<td>Carro roubado</td>"+
                        "<td>15/07/2017</td>"+
                        "<td>Roubo</td>"+
                    "</tr>"+
                "</tbody>"+
            "</table>"+
        "</div>"
    );
    $(".button-collapse").sideNav({
        closeOnClick: true // Closes side-nav on <a> clicks, useful for Angular/Meteor
    });
}