// Função para calcular
document
  .getElementById('buttonSomar')
  .addEventListener('click', function (event) {
    event.preventDefault();
    let tn1 = document.getElementById('valor1');
    let tn2 = document.getElementById('valor2');
    let opc = document.getElementById('operador');
    let operacao = String(opc.value);
    let res = document.getElementById('res');
    let n1 = Number(tn1.value);
    let n2 = Number(tn2.value);
    let total = 0;
    let o = ''; // impressão do tipo de operação

    if (operacao == '+') {
      total = n1 + n2;
      o = 'soma';
    } else if (operacao == '-') {
      total = n1 - n2;
      o = 'subtração';
    } else if (operacao == '*') {
      total = n1 * n2;
      o = 'multiplicação';
    } else if (operacao == '/') {
      total = n1 / n2;
      o = 'divisão';
    }

    res.innerHTML = `<div class="resposta">A ${o} entre ${n1} e ${n2} é igual a <strong>${total}</strong></div>`;
    tn1.value = '';
    tn2.value = '';
    opc.value = '';
  });
