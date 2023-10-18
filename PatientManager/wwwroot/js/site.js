// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function filterByPersonalId() {
    var filtroSerie = document.getElementById('PersonalIdFilter').value.toLowerCase();

    var rows = document.getElementsByClassName('rowlist');

    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        var nombreSerie = row.querySelector('.PersonalID').textContent.toLowerCase();

        var estado = nombreSerie.includes(filtroSerie);

        if (estado) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    }
}