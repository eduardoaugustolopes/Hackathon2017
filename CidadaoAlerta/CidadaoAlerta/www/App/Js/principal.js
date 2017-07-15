function criarTelaPrincipal() {
    $("#main").html(
        "<nav>"+
            "<div class='nav-wrapper'>"+
                "<a href='#' class='brand-logo'>Lista de Ocorrências</a>"+
                "<a href='#' data-activates='menu-mobile' class='button-collapse'>"+
                    "<i class='fa fa-bars'></i>"+
                "</a>"+
                "<ul class='right hide-on-med-and-down'>"+
                    "<li><a href='#'>Ocorrências</a></li>"+
                    "<li><a href='tel:37988174539'>Emergências</a></li>"+
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
            "</div>"+
        "</nav>"+
        "<div id='conteudo' class='container'>"+
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
    $(".button-collapse").sideNav();
}