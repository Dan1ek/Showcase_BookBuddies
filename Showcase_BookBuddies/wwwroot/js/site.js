class AddBookList extends HTMLElement {

    shadowRoot;

    constructor() {
        super();
        this.shadowRoot = this.attachShadow({ mode: 'open' });
    }

    connectedCallback() {
        //this.applyTemplate();
        this.attachEventListeners();
    }

    attachEventListeners() {
        //let form = this.shadowRoot.querySelector('form');

        //form.addEventListener('submit', (event) => {
        //    event.preventDefault();
        //    let formAddBookList = new FormData(form)

        //    let obj = Object.fromEntries(formAddBookList);

        //    // Haal het element op waar de gegevens worden weergegeven
        //    let bookListDataElement = this.shadowRoot.querySelector('#boekenlijst-gegevens');

            // Maak een string met de gegevens
            let boekenlijstGegevens = `
                <h2>Nieuwe boekenlijst toegevoegd</h2>
                <ul>
                <li>Titel: ${obj.listTitle}</li>
                <li>Beschrijving: ${obj.listDescription}</li>
                </ul>
            `;

            // Voeg de string toe aan het element
            bookListDataElement.innerHTML = boekenlijstGegevens;

        //})
    }

    //applyTemplate() {
    //    const template = document.getElementById('boekenlijst-toevoegen-form-tpl');
     //   let clone = template.content.cloneNode(true);
     //   this.shadowRoot.appendChild(clone);
    //}

}

customElements.define('boekenlijst-toevoegen-form', AddBookList);