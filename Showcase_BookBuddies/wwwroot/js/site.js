// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//class BookListItem extends HTMLElement {
//    //constructor(bookTitle, bookAuthor) {
//    //    super();
//    //    this.shadowRoot = this.attachShadow({ mode: 'open' });
//    //    this.addBook(bookTitle, bookAuthor);

//    //    addBook(bookTitle, bookAuthor){
//    //        const book = alert.(this.shadowRoot.querySelector('h1'))
//    //        this.shadowRoot.appendChild(..);
//    //    }
//    //    this.shadowRoot.innerHTML = `
//    //            <div class="book-info">
//    //                <h2>{bookTitle}</h2>
//    //                <p>by book1author</p>
//    //            </div>
//    //    `;
//    //}
//    constructor() {
//        super();
//        this.attachShadow({ mode: 'open' });
//        this.shadowRoot.innerHTML = `
//                <div class="book-info">
//                    <h2>bookTitle</h2>
//                    <p>by book1author</p>
//                </div>
//        `;
//    }
//}

//customElements.define('book-list-item', BookListItem);

//class BookList extends HTMLElement {
//    constructor() {
//        super();
//        this.attachShadow({ mode: 'open' });
//        this.shadowRoot.innerHTML = `
//          <h1>Dit wordt een boekenlijst</h1>
//          <button>Click me to add your list!</button>
//        `;
//    }

//    attachEventListeners() {
//        this.shadowRoot.addEventListener('click', function () {
//            console.log('Button clicked');
//        })
//    }
//}

//customElements.define('book-list', BookList);

//const template = document.getElementById("toevoegen-boekenlijst-tpl")

//class BookList extends HTMLElement {
//    constructor() {
//        super;
//        this.shadowroot = this.attachShadow({ mode: 'open' });

//        const contentBooklist = template.content.cloneNode(true);
//        this.shadowRoot.appendChild(contentBooklist);

//        const form = this.shadowRoot.querySelector("form");
//        event.preventDefault;

//        const titel = form.querySelector("input[name='lijstTitel']").value;
//        const beschrijving = form.querySelector("input[name='lijstBeschrijving']").value;

//        const boekenlijst = document.createElement("boekenlijst");
//        boekenlijst.setAttribute("titel", titel);
//        boekenlijst.setAttribute("beschrijving", beschrijving);
//        document.body.appendChild(boekenlijst;)
//    }
//}

//    connectedCallback() {
//        this.applyTemplate();
//        this.attachEventListeners();
//    }

//    attachEventListeners() {
//        let form = this.shadowRoot.querySelector('toevoegenBoekenlijst');

//        form.addEventListener('boekenlijstToevoegen', (event) => {
//            event.preventDefault();
//            let formData = new FormData(form)

//            for (const d of formData.entries()) {
//                console.log(d.toString())
//            }

//            let obj = Object.fromEntries(formData)
//            console.log(obj)

//        })
//    }

//    applyTemplate() {
//        const template = document.getElementById('toevoegen-boekenlijst-tpl');
//        let clone = template.content.cloneNode(true);
//        this.shadowRoot.appendChild(clone);
//    }
//}


//customElements.define('boekenlijst', BookList);



//// Create a new custom element
//class BoekenlijstToevoegen extends HTMLElement {
//    constructor() {
//        super();

//        // Attach the shadow DOM to the custom element
//        this.attachShadow({ mode: "open" });

//        // Clone the template and append it to the shadow DOM
//        const shadowRoot = this.shadowRoot;
//        const content = template.content.cloneNode(true);
//        shadowRoot.appendChild(content);
//    }
//}

//// Define the custom element
//customElements.define("boekenlijst-toevoegen", BoekenlijstToevoegen);


class AddBookList extends HTMLElement {

    shadowRoot;

    constructor() {
        super();
        this.shadowRoot = this.attachShadow({ mode: 'open' });
    }

    connectedCallback() {
        this.applyTemplate();
        this.attachEventListeners();
    }

    attachEventListeners() {
        let form = this.shadowRoot.querySelector('form');

        form.addEventListener('submit', (event) => {
            event.preventDefault();
            let formBoekenlijstToevoegen = new FormData(form)

            let obj = Object.fromEntries(formBoekenlijstToevoegen);

            // Haal het element op waar de gegevens worden weergegeven
      let boekenlijstGegevensElement = this.shadowRoot.querySelector('#boekenlijst-gegevens');

      // Maak een string met de gegevens
      let boekenlijstGegevens = `
        <h2>Nieuwe boekenlijst toegevoegd</h2>
        <ul>
          <li>Titel: ${obj.lijstTitel}</li>
          <li>Beschrijving: ${obj.lijstBeschrijving}</li>
        </ul>
      `;

      // Voeg de string toe aan het element
      boekenlijstGegevensElement.innerHTML = boekenlijstGegevens;

        })
    }

    applyTemplate() {
        const template = document.getElementById('boekenlijst-toevoegen-form-tpl');
        let clone = template.content.cloneNode(true);
        this.shadowRoot.appendChild(clone);
    }

}

customElements.define('boekenlijst-toevoegen-form', AddBookList);