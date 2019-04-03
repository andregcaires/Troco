/*
 * Validações dos inputs da página Index
 */

document.querySelector('input').oninput = checkKey;
document.getElementById("PaidValue").oninput = checkKey;
document.getElementById("TotalValue").onpaste = checkKey;
document.getElementById("PaidValue").onpaste = checkKey;

function checkKey() {

    // permite apenas caracteres numéricos
    var clean = this.value.replace(/[^0-9,]/g, "")
        .replace(/(,.*?),(.*,)?/, "$1");

    if (clean !== this.value) this.value = clean;

    // impede que usuário digite mais de duas casas decimais
    var paidValue = this.value.split(",");
    if (typeof paidValue[1] !== 'undefined' && paidValue[1].length > 2) {
        this.value = this.value.slice(0, -1);
    }

    // garante que números grandes não serão colados após a vírgula, mantendo a regra 
    // das casas decimais
    if (typeof paidValue[1] !== 'undefined' && paidValue[1].length > 3) {
        var index = this.value.indexOf(",") + 3;
        this.value = this.value.slice(0, index);
    }
}