const cep = document.querySelector('#cep');
const logadouro = document.querySelector('#logadouro');
const bairro = document.querySelector('#bairro');
const localidade = document.querySelector('#localidade');
const uf = document.querySelector('#uf');

cep.addEventListener('focusout', async () => {
    const response = await fetch(`https://viacep.com.br/ws/${cep.value}/json/`);

    const responseCep = await response.json();

    logadouro.value = responseCep.logradouro;
    bairro.value = responseCep.bairro;
    localidade.value = responseCep.localidade;
    uf.value = responseCep.uf;
});