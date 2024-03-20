class BookListComponent extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
    }

    connectedCallback() {
        const listTitle = this.getAttribute('list-title');
        const listDescription = this.getAttribute('list-description');

        const shadowRoot = this.shadowRoot;
        shadowRoot.innerHTML = `
        <h2>${listTitle}</h2>
        <p>${listDescription}</p>
        `;
    }
}

customElements.define('book-list', BookListComponent);

class BookComponent extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
    }

    connectedCallback() {
        const bookTitle = this.getAttribute('book-title');
        const bookAuthor = this.getAttribute('book-author');

        const shadowRoot = this.shadowRoot;
        shadowRoot.innerHTML = `
        <p>${bookTitle}</p>
        <p>${bookAuthor}</p>
        `;
    }
}

customElements.define('book-s', BookComponent);

const button = document.getElementById('buttonAddBook');
button.addEventListener('click', () => {
    addBooksFormVisible();
});

function addBooksFormVisible() {
    document.getElementById('add-books-form').style.visibility = "visible";
}




//class AddBookList extends HTMLElement {

//    shadowRoot;

//    constructor() {
//        super();
//        this.shadowRoot = this.attachShadow({ mode: 'open' });
//    }

//    connectedCallback() {
//        this.applyTemplate();
//        this.attachEventListeners();
//    }

//    attachEventListeners() {
//        let form = this.shadowRoot.querySelector('form');

//        form.addEventListener('submit', (event) => {
//            event.preventDefault();
//            let formAddBookList = new FormData(form)

//            let obj = Object.fromEntries(formAddBookList);

//            // Haal het element op waar de gegevens worden weergegeven
//            let bookListDataElement = this.shadowRoot.querySelector('#boekenlijst-gegevens');

//            // Maak een string met de gegevens
//            let boekenlijstGegevens = `
//                <h2>Nieuwe boekenlijst toegevoegd</h2>
//                <ul>
//                <li>Titel: ${obj.listTitle}</li>
//                <li>Beschrijving: ${obj.listDescription}</li>
//                </ul>
//            `;

//            //List<Book> testje = new List<Book>();
//            //bookList.Add(new Book { Titel = obj.title, Author = obj.listDescription });
//            //testje.Add(new Book { Titel = "The Lord of the Rings", Author = "J.R.R. Tolkien" });
//            //BookList myList = new BookList(obj.listTitle, obj.listDescription, bookList);



//            // Voeg de string toe aan het element
//            bookListDataElement.innerHTML = boekenlijstGegevens;

//        })
//    }

//    applyTemplate() {
//        const template = document.getElementById('boekenlijst-toevoegen-form-tpl');
//        let clone = template.content.cloneNode(true);
//        this.shadowRoot.appendChild(clone);
//    }

//}

//customElements.define('boekenlijst-toevoegen-form', AddBookList);