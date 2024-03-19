//class AddBookList extends HTMLElement {

//import { extend } from "jquery";

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
